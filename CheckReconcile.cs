using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Checkbook
{
	/// <summary>
	/// Summary description for CheckReconcile.
	/// </summary>
	public class CheckReconcile : CheckbookControl
	{
		private System.Windows.Forms.Button btnNew;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.ComboBox comboType;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TextBox textCheckNumber;
		private System.Windows.Forms.ListView listMatches;
		private System.Windows.Forms.ListView listTransactions;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox textAmount;
		private System.Windows.Forms.Button btnFirst;
		private System.Windows.Forms.Button btnPrevious;
		private System.Windows.Forms.CheckBox checkCleared;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.TextBox textDate;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ComboBox comboDescription;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Button btnLast;
		private System.Windows.Forms.TabControl tabControl;
		private CheckBox checkArchived;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private ArrayList m_registerRecs;

		public CheckReconcile()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			m_registerRecs = new ArrayList();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.listMatches = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.listTransactions = new System.Windows.Forms.ListView();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.btnLast = new System.Windows.Forms.Button();
			this.comboDescription = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textDate = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.checkCleared = new System.Windows.Forms.CheckBox();
			this.btnPrevious = new System.Windows.Forms.Button();
			this.btnFirst = new System.Windows.Forms.Button();
			this.textAmount = new System.Windows.Forms.TextBox();
			this.textCheckNumber = new System.Windows.Forms.TextBox();
			this.comboType = new System.Windows.Forms.ComboBox();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnNew = new System.Windows.Forms.Button();
			this.checkArchived = new System.Windows.Forms.CheckBox();
			this.tabControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPage1);
			this.tabControl.Controls.Add(this.tabPage2);
			this.tabControl.Location = new System.Drawing.Point(0, 88);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(489, 224);
			this.tabControl.TabIndex = 40;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.listMatches);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(481, 198);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Possible matches";
			// 
			// listMatches
			// 
			this.listMatches.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader9,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
			this.listMatches.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listMatches.FullRowSelect = true;
			this.listMatches.HideSelection = false;
			this.listMatches.Location = new System.Drawing.Point(0, 0);
			this.listMatches.MultiSelect = false;
			this.listMatches.Name = "listMatches";
			this.listMatches.Size = new System.Drawing.Size(481, 198);
			this.listMatches.TabIndex = 39;
			this.listMatches.UseCompatibleStateImageBehavior = false;
			this.listMatches.View = System.Windows.Forms.View.Details;
			this.listMatches.DoubleClick += new System.EventHandler(this.listMatches_DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Type";
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "Check #";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Description";
			this.columnHeader2.Width = 200;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Date";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader3.Width = 71;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Amount";
			this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader4.Width = 75;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.listTransactions);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(481, 198);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "What\'s left";
			// 
			// listTransactions
			// 
			this.listTransactions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader10,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
			this.listTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listTransactions.FullRowSelect = true;
			this.listTransactions.HideSelection = false;
			this.listTransactions.Location = new System.Drawing.Point(0, 0);
			this.listTransactions.MultiSelect = false;
			this.listTransactions.Name = "listTransactions";
			this.listTransactions.Size = new System.Drawing.Size(481, 198);
			this.listTransactions.TabIndex = 40;
			this.listTransactions.UseCompatibleStateImageBehavior = false;
			this.listTransactions.View = System.Windows.Forms.View.Details;
			this.listTransactions.DoubleClick += new System.EventHandler(this.listTransactions_DoubleClick);
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Type";
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "Check #";
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Description";
			this.columnHeader6.Width = 200;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Date";
			this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader7.Width = 71;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Amount";
			this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader8.Width = 75;
			// 
			// btnLast
			// 
			this.btnLast.Location = new System.Drawing.Point(168, 64);
			this.btnLast.Name = "btnLast";
			this.btnLast.Size = new System.Drawing.Size(25, 20);
			this.btnLast.TabIndex = 36;
			this.btnLast.Text = ">|";
			this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
			// 
			// comboDescription
			// 
			this.comboDescription.Location = new System.Drawing.Point(72, 36);
			this.comboDescription.Name = "comboDescription";
			this.comboDescription.Size = new System.Drawing.Size(216, 21);
			this.comboDescription.TabIndex = 27;
			this.comboDescription.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboDescription_KeyUp);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(144, 4);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 20);
			this.label2.TabIndex = 22;
			this.label2.Text = "Trans type";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(296, 4);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 20);
			this.label3.TabIndex = 24;
			this.label3.Text = "Check #";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textDate
			// 
			this.textDate.Location = new System.Drawing.Point(72, 4);
			this.textDate.MaxLength = 10;
			this.textDate.Name = "textDate";
			this.textDate.Size = new System.Drawing.Size(64, 20);
			this.textDate.TabIndex = 21;
			this.textDate.Leave += new System.EventHandler(this.textDate_Leave);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(3, 36);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 20);
			this.label4.TabIndex = 26;
			this.label4.Text = "Description";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(296, 36);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 20);
			this.label5.TabIndex = 28;
			this.label5.Text = "Amount";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 20);
			this.label1.TabIndex = 20;
			this.label1.Text = "Trans date";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// checkCleared
			// 
			this.checkCleared.Location = new System.Drawing.Point(416, 36);
			this.checkCleared.Name = "checkCleared";
			this.checkCleared.Size = new System.Drawing.Size(64, 20);
			this.checkCleared.TabIndex = 30;
			this.checkCleared.Text = "Cleared";
			// 
			// btnPrevious
			// 
			this.btnPrevious.Location = new System.Drawing.Point(104, 64);
			this.btnPrevious.Name = "btnPrevious";
			this.btnPrevious.Size = new System.Drawing.Size(25, 20);
			this.btnPrevious.TabIndex = 34;
			this.btnPrevious.Text = "<";
			this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
			// 
			// btnFirst
			// 
			this.btnFirst.Location = new System.Drawing.Point(72, 64);
			this.btnFirst.Name = "btnFirst";
			this.btnFirst.Size = new System.Drawing.Size(25, 20);
			this.btnFirst.TabIndex = 33;
			this.btnFirst.Text = "|<";
			this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
			// 
			// textAmount
			// 
			this.textAmount.Location = new System.Drawing.Point(344, 36);
			this.textAmount.Name = "textAmount";
			this.textAmount.Size = new System.Drawing.Size(64, 20);
			this.textAmount.TabIndex = 29;
			this.textAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textCheckNumber
			// 
			this.textCheckNumber.Location = new System.Drawing.Point(344, 4);
			this.textCheckNumber.MaxLength = 50;
			this.textCheckNumber.Name = "textCheckNumber";
			this.textCheckNumber.Size = new System.Drawing.Size(64, 20);
			this.textCheckNumber.TabIndex = 25;
			// 
			// comboType
			// 
			this.comboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboType.Items.AddRange(new object[] {
            "ATM",
            "Archive",
            "Check",
            "Correction Credit",
            "Correction Debit",
            "Debit Card",
            "Deposit",
            "E-pay",
            "Fee",
            "Transfer In",
            "Transfer Out",
            "Withdrawal",
            "Other Debit",
            "Other Credit"});
			this.comboType.Location = new System.Drawing.Point(208, 4);
			this.comboType.Name = "comboType";
			this.comboType.Size = new System.Drawing.Size(80, 21);
			this.comboType.TabIndex = 23;
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(136, 64);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(25, 20);
			this.btnNext.TabIndex = 35;
			this.btnNext.Text = ">";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnNew
			// 
			this.btnNew.Location = new System.Drawing.Point(200, 64);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(25, 20);
			this.btnNew.TabIndex = 37;
			this.btnNew.Text = "+";
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// checkArchived
			// 
			this.checkArchived.AutoSize = true;
			this.checkArchived.Location = new System.Drawing.Point(416, 67);
			this.checkArchived.Name = "checkArchived";
			this.checkArchived.Size = new System.Drawing.Size(68, 17);
			this.checkArchived.TabIndex = 38;
			this.checkArchived.Text = "Archived";
			this.checkArchived.UseVisualStyleBackColor = true;
			// 
			// CheckReconcile
			// 
			this.Controls.Add(this.checkArchived);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.btnNew);
			this.Controls.Add(this.btnLast);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnPrevious);
			this.Controls.Add(this.btnFirst);
			this.Controls.Add(this.textAmount);
			this.Controls.Add(this.textCheckNumber);
			this.Controls.Add(this.checkCleared);
			this.Controls.Add(this.comboDescription);
			this.Controls.Add(this.comboType);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textDate);
			this.Controls.Add(this.label1);
			this.Name = "CheckReconcile";
			this.Size = new System.Drawing.Size(488, 312);
			this.tabControl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public override void SetDefaultButton()
		{
			m_mainWindow.AcceptButton = btnNext;
		}

		public bool LoadCheckReconcile(string accountId)
		{
            SaveRecord();

			m_registerRecs.Clear();

			textDate.Text = "";
			comboType.SelectedIndex = -1;
			textCheckNumber.Text = "";
			comboDescription.Text = "";
			comboDescription.SelectedIndex = -1;
			comboDescription.Items.Clear();
			textAmount.Text = "";
			checkCleared.Checked = false;
			checkArchived.Checked = false;

			m_accountId = accountId;

			string sql = string.Format("select description from vendor_names where account_id = '{0}'", accountId);

			OleDbCommand selectCmd = new OleDbCommand(sql, m_dbConnection);
			OleDbDataReader dataReader = selectCmd.ExecuteReader();

			while(dataReader.Read())
			{
				comboDescription.Items.Add(dataReader[0].ToString());
			}

			dataReader.Close();

			sql = string.Format("select * from check_register where account_id = '{0}' and cleared = 0 order by trans_date", accountId);

			selectCmd = new OleDbCommand(sql, m_dbConnection);
			dataReader = selectCmd.ExecuteReader();

			while(dataReader.Read())
			{
				CheckRegister rec = new CheckRegister();
				rec.Load(dataReader);

				m_registerRecs.Add(rec);
			}

			dataReader.Close();

			sql = string.Format("select * from bank_transactions where account_id = '{0}' and check_register_id is null", accountId);

			selectCmd = new OleDbCommand(sql, m_dbConnection);
			dataReader = selectCmd.ExecuteReader();

			listTransactions.Items.Clear();

			while(dataReader.Read())
			{
				BankTransaction tran = new BankTransaction();
				tran.Load(dataReader);

				ListViewItem item = new ListViewItem();
				item.Tag = tran;
				tran.Tag = item;

				item.Text = tran.TransType;
				item.SubItems.Add(tran.CheckNumber);

				if("" == tran.TransName)
				{
					item.SubItems.Add(tran.Description);
				}
				else
				{
					item.SubItems.Add(string.Format("{0} - {1}", tran.TransName, tran.Description));
				}

				item.SubItems.Add(tran.TransDate.ToShortDateString());
				item.SubItems.Add(tran.TransAmount.ToString("C"));

				listTransactions.Items.Add(item);
			}

			dataReader.Close();

			UpdateBalances();

			if(m_registerRecs.Count > 0)
			{
				CheckRegister rec = (CheckRegister)m_registerRecs[0];
				DisplayRegisterRec(rec);
			}

            return true;
		}

		private bool DisplayRegisterRec(CheckRegister rec)
		{
            SaveRecord();

			Tag = rec;

			textDate.Text = rec.TransDateString;
			comboType.SelectedIndex = comboType.FindStringExact(rec.TransType);
			textCheckNumber.Text = rec.CheckNumber;
			comboDescription.Text = rec.Description;
			textAmount.Text = rec.Amount.ToString();
			checkCleared.Checked = (1 == rec.Cleared);
			checkArchived.Checked = (1 == rec.Archived);

			int index = m_registerRecs.IndexOf(rec);
			index++;

			m_statusBar.Panels[0].Text = string.Format("Record {0} of {1}", index, m_registerRecs.Count);

			FindMatches();

            return true;
		}

		private void listMatches_DoubleClick(object sender, System.EventArgs e)
		{
			checkCleared.Checked = true;

			CheckRegister rec = (CheckRegister)Tag;
			rec.Cleared = 1;

			BankTransaction match = (BankTransaction)listMatches.SelectedItems[0].Tag;
			match.CheckRegisterId = rec.Id;
			match.Store(m_dbConnection);

			rec.Store(m_dbConnection);

			foreach(ListViewItem item in listMatches.SelectedItems)
			{
				listMatches.Items.Remove(item);
			}

			foreach(ListViewItem item in listTransactions.Items)
			{
				BankTransaction tran = (BankTransaction)item.Tag;

				if(match.TransactionId == tran.TransactionId)
				{
					listTransactions.Items.Remove(item);
					break;
				}
			}
		}

		private void listTransactions_DoubleClick(object sender, System.EventArgs e)
		{
			if(1 == listTransactions.SelectedItems.Count)
			{
				btnNew_Click(null, null);

				ListViewItem item = listTransactions.SelectedItems[0];

				string transType = item.SubItems[0].Text;
				string checkNumber = item.SubItems[1].Text;
				string description = item.SubItems[2].Text;
				string transDate = item.SubItems[3].Text;
				string amount = item.SubItems[4].Text;
				amount = amount.Replace("(", "");
				amount = amount.Replace(")", "");
				amount = amount.Replace("$", "");

				textDate.Text = transDate;
				
				switch(transType.ToLower())
				{
					case "fee":
						comboType.Text = "Fee";
						break;

					case "directdebit":
					case "debit":
					case "pos":
						comboType.Text = "Debit Card";
						break;

					case "check":
						comboType.Text = "Check";
						textCheckNumber.Text = checkNumber;
						break;

					case "atm":
						comboType.Text = "ATM";
						break;

					case "directdep":
					case "credit":
						comboType.Text = "Deposit";
						break;

					case "payment":
						comboType.Text = "E-pay";
						break;
				}

				comboDescription.Text = description;
				textAmount.Text = amount;
			}
		}

		private void btnFirst_Click(object sender, System.EventArgs e)
		{
			if(m_registerRecs.Count > 0)
			{
				CheckRegister rec = (CheckRegister)m_registerRecs[0];
				DisplayRegisterRec(rec);
			}
		}

		private void btnPrevious_Click(object sender, System.EventArgs e)
		{
			if(m_registerRecs.Count > 0)
			{
				int index = m_registerRecs.IndexOf(Tag);

				if(index > 0)
				{
					CheckRegister rec = (CheckRegister)m_registerRecs[index - 1];
					DisplayRegisterRec(rec);
				}
			}
		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{
			if(m_registerRecs.Count > 0)
			{
				int index = m_registerRecs.IndexOf(Tag);

				if(index < m_registerRecs.Count - 1)
				{
					CheckRegister rec = (CheckRegister)m_registerRecs[index + 1];
					DisplayRegisterRec(rec);
				}
				else
				{
					btnNew_Click(null, null);
				}
			}
		}

		private void btnLast_Click(object sender, System.EventArgs e)
		{
			CheckRegister rec = (CheckRegister)m_registerRecs[m_registerRecs.Count - 1];
			DisplayRegisterRec(rec);
		}

		private void btnNew_Click(object sender, System.EventArgs e)
		{
			CheckRegister rec = new CheckRegister();
			rec.AccountId = m_accountId;			

			DisplayRegisterRec(rec);

			textDate.Focus();

			m_registerRecs.Add(rec);
		}

		private void SaveRecord()
		{
			CheckRegister rec = (CheckRegister)Tag;

            if (rec == null) return;

            if (rec.IsNew)
            {
                string msg = null;

                if (textDate.Text == "" || textDate.Text == "1/1/0001")
                {
                    msg = "Trans date is a required field";
                }

                if (comboType.SelectedIndex == -1)
                {
                    msg = "Trans type is a required field";
                }

                if (comboDescription.Text == "")
                {
                    msg = "Description is a required field";
                }

                if (textAmount.Text == "")
                {
                    msg = "Amount is a required field";
                }

                if (msg != null)
                {
                    DialogResult dr = MessageBox.Show(this, string.Format("{0}\n\nDo you want to cancel the entry?", msg), "Missing data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dr == DialogResult.Yes)
                    {
                        ListViewItem item = rec.Tag as ListViewItem;
                        listTransactions.Items.Remove(item);
                        Tag = null;
                        return;
                    }
                    else
                    {
                        MessageBox.Show(this, "Entry is not saved, but will remain in the transactions list.", "Entry not saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }

			try
			{
				rec.TransDate = DateTime.Parse(textDate.Text);
				rec.TransType = comboType.Text;
				rec.CheckNumber = textCheckNumber.Text;
				rec.Description = comboDescription.Text;
				rec.Cleared = checkCleared.Checked ? 1 : 0;
				rec.Archived = checkArchived.Checked ? 1 : 0;

				rec.Amount = Convert.ToDouble(textAmount.Text);

				switch(rec.TransType)
				{
					case "ATM":
					case "Archive":
					case "Check":
					case "Debit Card":
					case "E-pay":
					case "Fee":
					case "Withdrawal":
					case "Transfer Out":
					case "Other Debit":
					case "Correction Debit":
						rec.TransCategory = "debit";
						break;

					case "Deposit":
					case "Transfer In":
					case "Other Credit":
					case "Correction Credit":
						rec.TransCategory = "credit";
						break;
				}

				rec.Store(m_dbConnection);

				if(-1 == comboDescription.FindStringExact(rec.Description))
				{
					comboDescription.Items.Add(rec.Description);
				}

				UpdateBalances();

				Tag = null;
			}
			catch(Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void FindMatches()
		{
			listMatches.Items.Clear();

			CheckRegister rec = (CheckRegister)Tag;

			string sql = string.Format("select * from bank_transactions where account_id = '{0}' and (trans_amount = {1} or trans_amount = -{1}) and check_register_id is null", rec.AccountId, rec.Amount);

			OleDbCommand selectCmd = new OleDbCommand(sql, m_dbConnection);
			OleDbDataReader dataReader = selectCmd.ExecuteReader();

			ListViewItem item = null;

			while(dataReader.Read())
			{
				BankTransaction tran = new BankTransaction();
				tran.Load(dataReader);

				item = new ListViewItem();
				item.Tag = tran;
				tran.Tag = item;

				item.Text = tran.TransType;
				item.SubItems.Add(tran.CheckNumber);

				if("" != tran.TransName)
				{
					item.SubItems.Add(tran.TransName);
				}
				else
				{
					item.SubItems.Add(tran.Description);
				}
				
				item.SubItems.Add(tran.TransDate.ToShortDateString());
				item.SubItems.Add(tran.TransAmount.ToString("C"));

				listMatches.Items.Add(item);
			}

			dataReader.Close();
		}

		public void UpdateWhatsLeft()
		{
		}

		private void comboDescription_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(0 == comboDescription.Text.Length)
			{
				return;
			}

			if(e.Control)
			{
				return;
			}

			if(
				e.KeyCode == Keys.Delete ||
				e.KeyCode == Keys.Back ||
				e.KeyCode == Keys.Tab ||
				e.KeyCode == Keys.ShiftKey ||
				e.KeyCode == Keys.Shift)
			{
				return;
			}

			int index = comboDescription.FindString(comboDescription.Text);

			if(-1 != index)
			{
				int len = comboDescription.Text.Length;
				string found = comboDescription.Items[index].ToString().Substring(len);
				comboDescription.Text += found;
				comboDescription.SelectionStart = len;
				comboDescription.SelectionLength = found.Length;
			}
		}

		public override void SaveCurrentRecord()
		{
			SaveRecord();	
		}

		private void textDate_Leave(object sender, System.EventArgs e)
		{
			try
			{
				textDate.Text = DateTime.Parse(textDate.Text).ToShortDateString();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this, string.Format("Invalid date!\n\nThe exact error was: {0}", ex.Message), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				textDate.Focus();
			}
		}
	}
}
