using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;

namespace Checkbook
{
	/// <summary>
	/// Summary description for BankTransaction.
	/// </summary>
	public class BankTransaction : BaseRecord
	{
		public BankTransaction() : base("bank_transactions")
		{
			Fields = new DBField[]
			{
				new DBField("transaction_id", FieldType.Text, true, false),
				new DBField("account_id", FieldType.Text, true, false),
				new DBField("check_register_id", FieldType.Text, false, false),
				new DBField("trans_date", FieldType.Date, false, false),
				new DBField("trans_type", FieldType.Text, true, false),
				new DBField("check_number", FieldType.Text, false, false),
				new DBField("trans_name", FieldType.Text, false, false),
				new DBField("description", FieldType.Text, false, false),
				new DBField("trans_amount", FieldType.Numeric, true, false)
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
		
		public string TransactionId
		{
			get { return (string)GetFieldValue("transaction_id"); }
			set { SetFieldValue("transaction_id", value); }
		}

		public string AccountId
		{
			get { return (string)GetFieldValue("account_id"); }
			set { SetFieldValue("account_id", value); }
		}

		public string CheckRegisterId
		{
			get { return (string)GetFieldValue("check_register_id"); }
			set { SetFieldValue("check_register_id", value); }
		}

		public DateTime TransDate
		{
			get { return (DateTime)GetFieldValue("trans_date"); }
			set { SetFieldValue("trans_date", value); }
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

		public string TransName
		{
			get { return (string)GetFieldValue("trans_name"); }
			set { SetFieldValue("trans_name", value); }
		}

		public string Description
		{
			get { return (string)GetFieldValue("description"); }
			set { SetFieldValue("description", value); }
		}

		public double TransAmount
		{
			get { return (double)GetFieldValue("trans_amount"); }
			set { SetFieldValue("trans_amount", value); }
		}
	}
}
