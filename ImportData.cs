using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;

namespace Checkbook
{
	/// <summary>
	/// Summary description for ImportData
	/// </summary>
	public class ImportData : BaseRecord
	{
		public ImportData() : base("import_data")
		{
			Fields = new DBField[]
			{
				new DBField("id", FieldType.Text, true, false),
				new DBField("import_date", FieldType.Date, false, false),
				new DBField("account_id", FieldType.Text, false, false),
				new DBField("data", FieldType.Text, false, false)
			};
		}

		public override void Store(OleDbConnection writeConnection)
		{
			if(false == CanUpdate)
			{
				Id = DateTime.Now.Ticks.ToString();

				string sql = GetInsertSql();
				AddRecord(sql, writeConnection);
			}
			else
			{
				string sql = GetUpdateSql();
				UpdateRecord(sql, writeConnection);
			}
		}
		
		public string Id
		{
			get { return (string)GetFieldValue("id"); }
			set { SetFieldValue("id", value); }
		}

        public DateTime ImportDate
        {
            get { return (DateTime)GetFieldValue("import_date"); }
            set { SetFieldValue("import_date", value); }
        }
        
        public string AccountId
		{
            get { return (string)GetFieldValue("account_id"); }
            set { SetFieldValue("account_id", value); }
		}

		public string Data
		{
			get { return (string)GetFieldValue("data"); }
			set { SetFieldValue("data", value); }
		}
	}
}
