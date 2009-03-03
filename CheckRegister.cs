using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;

namespace Checkbook
{
	/// <summary>
	/// Summary description for CheckRegister.
	/// </summary>
	public class CheckRegister : BaseRecord
	{
		public CheckRegister() : base("check_register")
		{
			Fields = new DBField[]
			{
				new DBField("id", FieldType.Text, true, false),
				new DBField("account_id", FieldType.Text, false, false),
				new DBField("trans_date", FieldType.Date, false, false),
				new DBField("trans_type", FieldType.Text, false, false),
				new DBField("check_number", FieldType.Text, false, false),
				new DBField("description", FieldType.Text, false, false),
				new DBField("amount", FieldType.Numeric, false, false),
				new DBField("trans_category", FieldType.Text, false, false),
				new DBField("cleared", FieldType.Numeric, false, false),
				new DBField("comments", FieldType.Text, false, false),
				new DBField("archived", FieldType.Numeric, false, false)
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

		public string AccountId
		{
			get { return (string)GetFieldValue("account_id"); }
			set { SetFieldValue("account_id", value); }
		}

		public DateTime TransDate
		{
			get { return (DateTime)GetFieldValue("trans_date"); }
			set { SetFieldValue("trans_date", value); }
		}

		public string TransDateString
		{
			get
			{
				object obj = GetFieldValue("trans_date");

				if(null != obj)
				{
					return ((DateTime)obj).ToShortDateString();
				}

				return "";
			}
		}

		public string TransType
		{
			get { return (string)GetFieldValue("trans_type"); }
			set { SetFieldValue("trans_type", value); }
		}

		public string CheckNumber
		{
			get { return (string)GetFieldValue("check_number"); }
			set { SetFieldValue("check_number", value); }
		}

		public string Description
		{
			get { return (string)GetFieldValue("description"); }
			set { SetFieldValue("description", value); }
		}

		public double Amount
		{
			get 
			{
				object obj = GetFieldValue("amount");

				if(null == obj)
				{
					return 0;
				}

				return System.Convert.ToDouble(obj);
			}
			set 
			{
				SetFieldValue("amount", value);
			}
		}

		public string TransCategory
		{
			get { return (string)GetFieldValue("trans_category"); }
			set { SetFieldValue("trans_category", value); }
		}

		public int Cleared
		{
			get 
			{ 
				object obj = GetFieldValue("cleared");

				if(null != obj)
				{
					return Convert.ToInt32(obj);
				}

				return 0;
			}
			set { SetFieldValue("cleared", value); }
		}

		public int Archived
		{
			get
			{
				object obj = GetFieldValue("archived");

				if (null != obj)
				{
					return Convert.ToInt32(obj);
				}

				return 0;
			}
			set { SetFieldValue("archived", value); }
		}

		public string Comments
		{
			get { return (string)GetFieldValue("comments"); }
			set { SetFieldValue("comments", value); }
		}
	}
}
