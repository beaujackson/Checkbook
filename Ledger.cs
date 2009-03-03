using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;

namespace Checkbook
{
	/// <summary>
	/// Summary description for Ledger.
	/// </summary>
	public class Ledger : BaseRecord
	{
		public Ledger() : base("ledger")
		{
			Fields = new DBField[]
			{
				new DBField("id", FieldType.Numeric, true, true),
				new DBField("business_id", FieldType.Numeric, false, false),
				new DBField("entry_date", FieldType.Date, false, false),
				new DBField("entry_type", FieldType.Text, false, false),
				new DBField("entry_amount", FieldType.Numeric, false, false),
				new DBField("entry_account", FieldType.Text, false, false),
				new DBField("description", FieldType.Text, false, false),
				new DBField("comments", FieldType.Text, false, false)
			};
		}

		public override void Store(OleDbConnection writeConnection)
		{
			if(false == CanUpdate)
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

		public int BusinessId
		{
			get { return (int)GetFieldValue("business_id"); }
			set { SetFieldValue("business_id", value); }
		}

		public DateTime EntryDate
		{
			get { return (DateTime)GetFieldValue("entry_date"); }
			set { SetFieldValue("entry_date", value); }
		}

		public string EntryDateString
		{
			get
			{
				object obj = GetFieldValue("entry_date");

				if(null != obj)
				{
					return ((DateTime)obj).ToShortDateString();
				}

				return "";
			}
		}

		public string EntryType
		{
			get { return (string)GetFieldValue("entry_type"); }
			set { SetFieldValue("entry_type", value); }
		}

		public double EntryAmount
		{
			get
			{
				object obj = GetFieldValue("entry_amount");

				if (null == obj)
				{
					return 0;
				}

				return System.Convert.ToDouble(obj);
			}
			set
			{
				SetFieldValue("entry_amount", value);
			}
		}

		public string EntryAccount
		{
			get { return (string)GetFieldValue("entry_account"); }
			set { SetFieldValue("entry_account", value); }
		}

		public string Description
		{
			get { return (string)GetFieldValue("description"); }
			set { SetFieldValue("description", value); }
		}

		public string Comments
		{
			get { return (string)GetFieldValue("comments"); }
			set { SetFieldValue("comments", value); }
		}
	}
}
