using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using System.Text;

namespace Checkbook
{
	/// <summary>
	/// BaseRecord is used as an abstract base class to force "table" classes to 
	/// support a given set of functons
	/// </summary>
	[Serializable]
	public abstract class BaseRecord
	{
		private string m_tableName;
		private DBField[] m_fields;
		private Hashtable m_lookup;
		private string m_updateWhere = "";
		private bool m_canUpdate = false;
		private bool m_loadChildren = true;
		private object m_tag = null;
        private bool m_isNew = true;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="tableName">The name of the table that this record is from</param>
		public BaseRecord(string tableName)
		{
			m_tableName = tableName;
		}

		public object Tag
		{
			get { return m_tag; }
			set { m_tag = value; }
		}

		/// <summary>
		/// The name of the table being used
		/// </summary>
		public string TableName
		{
			get { return m_tableName; }
		}

		/// <summary>
		/// The where clause that will be used to update the record if this
		/// record was loaded from the database.
		/// </summary>
		public bool CanUpdate
		{
			get { return m_canUpdate; }
		}

        public bool IsNew
        {
            get { return m_isNew; }
            set { m_isNew = value; }
        }

		/// <summary>
		/// Flag indicating child records need to be loaded.  True by default.
		/// Set to False before calling Load() to prevent child records from
		/// being loaded.
		/// </summary>
		public bool LoadChildRecords
		{
			get { return m_loadChildren; }
			set { m_loadChildren = value; }
		}

		public DBField[] Fields
		{
			get { return m_fields; }
			set 
			{ 
				m_fields = value; 

				m_lookup = new Hashtable();

				int index = 0;
				foreach(DBField field in m_fields)
				{
					m_lookup[field.Name] = index;
					index++;
				}
			}
		}

		/// <summary>
		/// Load from database by record id - used to load a single record, and all of its child records
		/// </summary>
		public void Load(OleDbConnection readConnection, long id)
		{
			string sql = string.Format("select * from {0} where id = {1}", m_tableName, id);
			OleDbDataReader dataReader = null;

			try
			{
				OleDbCommand selectCmd = new OleDbCommand(sql, readConnection);
				dataReader = selectCmd.ExecuteReader();

				while(dataReader.Read())
				{
					Load(dataReader);
				}

				dataReader.Close();

				if(m_loadChildren)
				{
					LoadChildren(readConnection);
				}				
			}
			catch(Exception ex)
			{
				//pass the exception on up the chain
				throw ex;
			}
			finally
			{
				if(null != dataReader)
				{
					if(false == dataReader.IsClosed)
					{
						dataReader.Close();
					}
				}
			}

            m_isNew = false;
		}

		/// <summary>
		/// Load from database by OleDbDataReader - used to load a single record
		/// </summary>
		public void Load(OleDbDataReader dataReader)
		{
			for(int i=0; i<dataReader.FieldCount; i++)
			{
				DBField field = m_fields[(int)m_lookup[dataReader.GetName(i)]];
				field.Value = dataReader[field.Name]; //(null == dataReader[field.Name]) ? null : dataReader[field.Name];
			}

			SetUpdateWhereClause();

            m_isNew = false;
		}

		protected void SetUpdateWhereClause()
		{
			m_canUpdate = false;

			StringBuilder updateWhere = new StringBuilder();
			updateWhere.Append("where ");

			bool firstField = true;

			foreach(DBField field in m_fields)
			{
				if(field.PrimaryKey)
				{
					m_canUpdate = true;

					if(!firstField)
					{
						updateWhere.Append(" and ");
					}

					switch(field.Type)
					{
						case FieldType.Text:
							//handle single quotes that are in the value
							string temp = field.Value.ToString().Replace("'", "''");
							updateWhere.AppendFormat("{0} = '{1}'", field.Name, temp);
							break;

						case FieldType.Date:
						{
							DateTime dt = (DateTime)field.Value;
							updateWhere.AppendFormat("{0} = '{1}'", field.Name, dt.ToShortDateString());
						}
							break;

						case FieldType.Numeric:
							updateWhere.AppendFormat("{0} = {1}", field.Name, field.Value.ToString());
							break;
					}

					firstField = false;
				}
			}

			m_updateWhere = updateWhere.ToString();
		}

		protected string GetInsertSql()
		{
			StringBuilder sql = new StringBuilder();
			StringBuilder values = new StringBuilder();

			sql.AppendFormat("insert into {0} (", m_tableName);

			bool firstField = true;

			foreach(DBField field in m_fields)
			{
				if(null != field.Value)
				{
					if(!firstField)
					{
						sql.Append(", ");
						values.Append(", ");
					}

					sql.Append(field.Name);

					switch(field.Type)
					{
						case FieldType.Text:
							//handle single quotes that are in the value
							string temp = field.Value.ToString().Replace("'", "''");
							values.AppendFormat("'{0}'", temp);
							break;

						case FieldType.Date:
						{
							DateTime dt = (DateTime)field.Value;
							values.AppendFormat("'{0}'", dt.ToShortDateString());
						}
							break;

						case FieldType.Numeric:
							if(false == field.Identity)
							{
								values.AppendFormat("{0}", field.Value.ToString());
							}
							break;
					}
				
					firstField = false;
				}
			}

			sql.Append(") values (");
			sql.Append(values.ToString());
			sql.Append(")");

			return sql.ToString();
		}

		protected string GetUpdateSql()
		{
			if(false == m_canUpdate)
			{
				//HACK need a dbtables specific exception?
				Exception ex = new Exception("The record is not updateable.  Either this record was not loaded directly from the database, has not yet been stored, or no primary fields are defined.");
				throw ex;
			}

			StringBuilder sql = new StringBuilder();

			sql.AppendFormat("update {0} set ", m_tableName);

			bool firstField = true;

			foreach(DBField field in m_fields)
			{
				if(field.Identity)
				{
					//cant' update identity fields
					continue;
				}

				string fieldVal;

				if((null == field.Value) || (DBNull.Value == field.Value))
				{
					fieldVal = "null";
				}
				else
				{
					fieldVal = field.Value.ToString();
				}

				if(!firstField)
				{
					sql.Append(", ");
				}

				switch(field.Type)
				{
					case FieldType.Text:

						if("null" == fieldVal)
						{
							sql.AppendFormat("{0} = null", field.Name);
						}
						else
						{
							string temp = fieldVal.Replace("'", "''");
							sql.AppendFormat("{0} = '{1}'", field.Name, temp);
						}
						break;

					case FieldType.Date:

						if("null" == fieldVal)
						{
							sql.AppendFormat("{0} = null", field.Name);
						}
						else
						{
							DateTime dt = (DateTime)field.Value;
							sql.AppendFormat("{0} = '{1}'", field.Name, dt.ToShortDateString());
						}
						break;

					case FieldType.Numeric:

						sql.AppendFormat("{0} = {1}", field.Name, fieldVal);
						break;
				}
			
				firstField = false;
			}

			sql.AppendFormat(" {0}", m_updateWhere);

			return sql.ToString();
		}

		public int DeleteRecord(OleDbConnection writeConnection)
		{
			string delSql = GetDeleteSql();
			OleDbCommand delCmd = new OleDbCommand(delSql, writeConnection);

			return delCmd.ExecuteNonQuery();
		}

		protected string GetDeleteSql()
		{
			if(false == m_canUpdate)
			{
				//HACK need a dbtables specific exception?
				Exception ex = new Exception("The record is not deleteable.  Either this record was not loaded directly from the database, has not yet been stored, or no primary fields are defined.");
				throw ex;
			}

			string sql = string.Format("delete from {0} {1}", m_tableName, m_updateWhere);

			return sql.ToString();
		}

		/// <summary>
		/// Get the value of the specified field from the Fields collection
		/// </summary>
		/// <param name="fieldName">Name of the field to retrieve</param>
		/// <returns></returns>
		protected object GetFieldValue(string fieldName)
		{
			object retVal = m_fields[(int)m_lookup[fieldName]].Value;

			if(m_fields[(int)m_lookup[fieldName]].Type == FieldType.Date)
			{
				if(DBNull.Value == retVal || null == retVal)
				{
					retVal = new System.DateTime();
					retVal = DateTime.MinValue;
				}
			}
			else if(m_fields[(int)m_lookup[fieldName]].Type == FieldType.Text)
			{
				if(DBNull.Value == retVal || null == retVal)
				{
					retVal = "";
				}
			}
			else
			{
				if(DBNull.Value == retVal || null == retVal)
				{
					retVal = 0;
				}
			}
			
			//return (DBNull.Value == m_fields[(int)m_lookup[fieldName]].Value) ? null : m_fields[(int)m_lookup[fieldName]].Value;
			
			return retVal;			
		}

		/// <summary>
		/// Set the value of the specified field from the Fields collection
		/// </summary>
		/// <param name="fieldName">Name of the field to set</param>
		/// <param name="fieldValue">Value to set the field to</param>
		protected void SetFieldValue(string fieldName, object fieldValue)
		{
			m_fields[(int)m_lookup[fieldName]].Value = fieldValue;
		}

		/// <summary>
		/// Store to the database
		/// </summary>
		public abstract void Store(OleDbConnection writeConnection);

		/// <summary>
		/// Load related child records of this record
		/// </summary>
		public virtual void LoadChildren(OleDbConnection readConnection)
		{
			return;
		}

		/// <summary>
		/// Adds a new record to the table without returning an id value
		/// </summary>
		protected void AddRecord(string sql, OleDbConnection writeConnection)
		{
			try
			{
				OleDbCommand sqlCmd = new OleDbCommand(sql, writeConnection);
				int rowsAffected = sqlCmd.ExecuteNonQuery();

				SetUpdateWhereClause();
			}
			catch(Exception ex)
			{
				//this is mostly for debugging
				string err = ex.Message;

				//pass the exception on up the chain
				throw ex;
			}
		}

		/// <summary>
		/// Adds a new record to the table and returns the generated int id value
		/// </summary>
		protected int AddRecordWithIntId(string sql, OleDbConnection writeConnection)
		{
			int id = 0;

			OleDbDataReader dataReader = null;

			try
			{
				OleDbCommand sqlCmd = new OleDbCommand(sql, writeConnection);
				dataReader = sqlCmd.ExecuteReader();

				while(dataReader.Read())
				{
					id = (int)dataReader[0];
				}
			}
			catch(Exception ex)
			{
				//pass the exception on up the chain
				throw ex;
			}
			finally
			{
				if(null != dataReader)
				{
					if(false == dataReader.IsClosed)
					{
						dataReader.Close();
					}
				}
			}

			return id;
		}

		/// <summary>
		/// Adds a new record to the table and returns the generated long id value
		/// </summary>
		protected long AddRecordWithLongId(string sql, OleDbConnection writeConnection)
		{
			long id = 0;

			OleDbDataReader dataReader = null;

			try
			{
				OleDbCommand sqlCmd = new OleDbCommand(sql, writeConnection);
				dataReader = sqlCmd.ExecuteReader();

				while(dataReader.Read())
				{
					id = (long)dataReader[0];
				}
			}
			catch(Exception ex)
			{
				//pass the exception on up the chain
				throw ex;
			}
			finally
			{
				if(null != dataReader)
				{
					if(false == dataReader.IsClosed)
					{
						dataReader.Close();
					}
				}
			}

			return id;
		}

		/// <summary>
		/// Adds a new record to the table and returns the generated id value
		/// </summary>
		protected void AddRecordWithFields(string sql, ArrayList returnVals, OleDbConnection writeConnection)
		{
			OleDbDataReader dataReader = null;

			try
			{
				OleDbCommand sqlCmd = new OleDbCommand(sql, writeConnection);
				dataReader = sqlCmd.ExecuteReader();

				while(dataReader.Read())
				{
					for(int i=0; i<dataReader.FieldCount; i++)
					{
						returnVals.Add(dataReader[i]);
					}					
				}
			}
			catch(Exception ex)
			{
				//pass the exception on up the chain
				throw ex;
			}
			finally
			{
				if(null != dataReader)
				{
					if(false == dataReader.IsClosed)
					{
						dataReader.Close();
					}
				}
			}
		}

		/// <summary>
		/// Executes an update sql statement.  Returns the number of rows affected
		/// </summary>
		protected int UpdateRecord(string sql, OleDbConnection writeConnection)
		{
			int rowsAffected = 0;

			try
			{
				OleDbCommand sqlCmd = new OleDbCommand(sql, writeConnection);
				rowsAffected = sqlCmd.ExecuteNonQuery();
			}
			catch(Exception ex)
			{
				//this is mostly for debugging
				string err = ex.Message;

				//pass the exception on up the chain
				throw ex;
			}

			SetUpdateWhereClause();

			return rowsAffected;
		}
	}
}
