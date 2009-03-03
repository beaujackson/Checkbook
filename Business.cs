using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;

namespace Checkbook
{
	/// <summary>
	/// Summary description for CheckRegister.
	/// </summary>
	public class Business : BaseRecord
	{
		public Business()
			: base("businesss")
		{
			Fields = new DBField[]
			{
				new DBField("id", FieldType.Text, true, false),
				new DBField("business_name", FieldType.Text, false, false),
				new DBField("taxid_number", FieldType.Text, false, false),
				new DBField("comments", FieldType.Text, false, false),
			};
		}

		public override void Store(OleDbConnection writeConnection)
		{
			if (false == CanUpdate)
			{
				string sql = GetInsertSql();
				AddRecord(sql, writeConnection);
			}
			else
			{
				string sql = GetUpdateSql();
				UpdateRecord(sql, writeConnection);
			}
		}

		public int Id
		{
			get { return (int)GetFieldValue("id"); }
			set { SetFieldValue("id", value); }
		}

		public string BusinessName
		{
			get { return (string)GetFieldValue("business_name"); }
			set { SetFieldValue("business_name", value); }
		}

		public string TaxIdNumber
		{
			get { return (string)GetFieldValue("taxid_number"); }
			set { SetFieldValue("taxid_number", value); }
		}

		public string Comments
		{
			get { return (string)GetFieldValue("comments"); }
			set { SetFieldValue("comments", value); }
		}

		public override string ToString()
		{
			return BusinessName;
		}
	}
}
