using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;

namespace Checkbook
{
	/// <summary>
	/// Summary description for CheckRegister.
	/// </summary>
	public class Account : BaseRecord
	{
		public Account() : base("accounts")
		{
			Fields = new DBField[]
			{
				new DBField("id", FieldType.Text, true, false),
				new DBField("account_name", FieldType.Text, false, false),
				new DBField("routing_number", FieldType.Text, false, false),
				new DBField("account_number", FieldType.Text, false, false),
				new DBField("comments", FieldType.Text, false, false),
				new DBField("last_import", FieldType.Text, false, false)
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

		public string AccountName
		{
			get { return (string)GetFieldValue("account_name"); }
			set { SetFieldValue("account_name", value); }
		}

		public string RoutingNumber
		{
			get { return (string)GetFieldValue("routing_number"); }
			set { SetFieldValue("routing_number", value); }
		}

		public string AccountNumber
		{
			get { return (string)GetFieldValue("account_number"); }
			set { SetFieldValue("account_number", value); }
		}

		public string Comments
		{
			get { return (string)GetFieldValue("comments"); }
			set { SetFieldValue("comments", value); }
		}

		public string LastImport
		{
			get { return (string)GetFieldValue("last_import"); }
			set { SetFieldValue("last_import", value); }
		}

		public override string ToString()
		{
			return AccountName;
		}
	}
}
