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
	/// Summary description for CheckRegistr.
	/// </summary>
	public class CheckRegistry : CheckbookControl
	{
		private System.Windows.Forms.TextBox textDate;
		private System.Windows.Forms.ComboBox comboType;
		private System.Windows.Forms.MenuItem menuContextDelete;
		private System.Windows.Forms.Button btnNew;
		private System.Windows.Forms.TextBox textCheckNumber;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.ListView listTransactions;
		private System.Windows.Forms.TextBox textAmount;
		private System.Windows.Forms.Button btnFirst;
		private System.Windows.Forms.Button btnPrevious;
		private System.Windows.Forms.CheckBox checkCleared;
		private System.Windows.Forms.ComboBox comboDescription;
		private System.Windows.Forms.ContextMenu contextMenu;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.TextBox textComments;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Button btnLast;
		private System.Windows.Forms.Label label8;
		private CheckBox checkArchived;

		private bool m_archived = false;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CheckRegistry()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
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
			this.label8 = new System.Windows.Forms.Label();
			this.btnLast = new System.Windows.Forms.Button();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.label7 = new System.Windows.Forms.Label();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.textComments = new System.Windows.Forms.TextBox();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.contextMenu = new System.Windows.Forms.ContextMenu();
			this.menuContextDelete = new System.Windows.Forms.MenuItem();
			this.comboDescription = new System.Windows.Forms.ComboBox();
			this.checkCleared = new System.Windows.Forms.CheckBox();
			this.btnPrevious = new System.Windows.Forms.Button();
			this.btnFirst = new System.Windows.Forms.Button();
			this.textAmount = new System.Windows.Forms.TextBox();
			this.listTransactions = new System.Windows.Forms.ListView();
			this.btnNext = new System.Windows.Forms.Button();
			this.textCheckNumber = new System.Windows.Forms.TextBox();
			this.btnNew = new System.Windows.Forms.Button();
			this.comboType = new System.Windows.Forms.ComboBox();
			this.textDate = new System.Windows.Forms.TextBox();
			this.checkArchived = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 144);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(80, 20);
			this.label8.TabIndex = 19;
			this.label8.Text = "Transactions";
			this.label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// btnLast
			// 
			this.btnLast.Location = new System.Drawing.Point(168, 120);
			this.btnLast.Name = "btnLast";
			this.btnLast.Size = new System.Drawing.Size(25, 20);
			this.btnLast.TabIndex = 16;
			this.btnLast.Text = ">|";
			this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Description";
			this.columnHeader2.Width = 200;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(3, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 20);
			this.label4.TabIndex = 6;
			this.label4.Text = "Description";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(296, 40);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 20);
			this.label5.TabIndex = 8;
			this.label5.Text = "Amount";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Type";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(3, 72);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 20);
			this.label7.TabIndex = 11;
			this.label7.Text = "Comments";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Clear";
			this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader5.Width = 50;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Trans date";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(144, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Trans type";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(368, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 20);
			this.label3.TabIndex = 4;
			this.label3.Text = "Check #";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Date";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader3.Width = 71;
			// 
			// textComments
			// 
			this.textComments.AcceptsReturn = true;
			this.textComments.Location = new System.Drawing.Point(72, 72);
			this.textComments.MaxLength = 255;
			this.textComments.Multiline = true;
			this.textComments.Name = "textComments";
			this.textComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textComments.Size = new System.Drawing.Size(408, 40);
			this.textComments.TabIndex = 12;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Amount";
			this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader4.Width = 75;
			// 
			// contextMenu
			// 
			this.contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuContextDelete});
			// 
			// menuContextDelete
			// 
			this.menuContextDelete.Index = 0;
			this.menuContextDelete.Text = "Delete";
			this.menuContextDelete.Click += new System.EventHandler(this.menuContextDelete_Click);
			// 
			// comboDescription
			// 
			this.comboDescription.Location = new System.Drawing.Point(72, 40);
			this.comboDescription.Name = "comboDescription";
			this.comboDescription.Size = new System.Drawing.Size(216, 21);
			this.comboDescription.TabIndex = 7;
			this.comboDescription.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboDescription_KeyUp);
			// 
			// checkCleared
			// 
			this.checkCleared.Location = new System.Drawing.Point(416, 40);
			this.checkCleared.Name = "checkCleared";
			this.checkCleared.Size = new System.Drawing.Size(64, 20);
			this.checkCleared.TabIndex = 10;
			this.checkCleared.Text = "Cleared";
			// 
			// btnPrevious
			// 
			this.btnPrevious.Location = new System.Drawing.Point(104, 120);
			this.btnPrevious.Name = "btnPrevious";
			this.btnPrevious.Size = new System.Drawing.Size(25, 20);
			this.btnPrevious.TabIndex = 14;
			this.btnPrevious.Text = "<";
			this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
			// 
			// btnFirst
			// 
			this.btnFirst.Location = new System.Drawing.Point(72, 120);
			this.btnFirst.Name = "btnFirst";
			this.btnFirst.Size = new System.Drawing.Size(25, 20);
			this.btnFirst.TabIndex = 13;
			this.btnFirst.Text = "|<";
			this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
			// 
			// textAmount
			// 
			this.textAmount.Location = new System.Drawing.Point(344, 40);
			this.textAmount.Name = "textAmount";
			this.textAmount.Size = new System.Drawing.Size(64, 20);
			this.textAmount.TabIndex = 9;
			this.textAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// listTransactions
			// 
			this.listTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.listTransactions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
			this.listTransactions.ContextMenu = this.contextMenu;
			this.listTransactions.FullRowSelect = true;
			this.listTransactions.HideSelection = false;
			this.listTransactions.Location = new System.Drawing.Point(5, 171);
			this.listTransactions.MultiSelect = false;
			this.listTransactions.Name = "listTransactions";
			this.listTransactions.Size = new System.Drawing.Size(478, 136);
			this.listTransactions.TabIndex = 20;
			this.listTransactions.UseCompatibleStateImageBehavior = false;
			this.listTransactions.View = System.Windows.Forms.View.Details;
			this.listTransactions.SelectedIndexChanged += new System.EventHandler(this.listTransactions_SelectedIndexChanged);
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(136, 120);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(25, 20);
			this.btnNext.TabIndex = 15;
			this.btnNext.Text = ">";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// textCheckNumber
			// 
			this.textCheckNumber.Location = new System.Drawing.Point(416, 8);
			this.textCheckNumber.MaxLength = 50;
			this.textCheckNumber.Name = "textCheckNumber";
			this.textCheckNumber.Size = new System.Drawing.Size(64, 20);
			this.textCheckNumber.TabIndex = 5;
			// 
			// btnNew
			// 
			this.btnNew.Location = new System.Drawing.Point(200, 120);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(25, 20);
			this.btnNew.TabIndex = 17;
			this.btnNew.Text = "+";
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
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
			this.comboType.Location = new System.Drawing.Point(208, 8);
			this.comboType.Name = "comboType";
			this.comboType.Size = new System.Drawing.Size(154, 21);
			this.comboType.TabIndex = 3;
			// 
			// textDate
			// 
			this.textDate.Location = new System.Drawing.Point(72, 8);
			this.textDate.MaxLength = 10;
			this.textDate.Name = "textDate";
			this.textDate.Size = new System.Drawing.Size(64, 20);
			this.textDate.TabIndex = 1;
			this.textDate.Leave += new System.EventHandler(this.textDate_Leave);
			// 
			// checkArchived
			// 
			this.checkArchived.AutoSize = true;
			this.checkArchived.Location = new System.Drawing.Point(416, 123);
			this.checkArchived.Name = "checkArchived";
			this.checkArchived.Size = new System.Drawing.Size(68, 17);
			this.checkArchived.TabIndex = 18;
			this.checkArchived.Text = "Archived";
			this.checkArchived.UseVisualStyleBackColor = true;
			// 
			// CheckRegistry
			// 
			this.Controls.Add(this.checkArchived);
			this.Controls.Add(this.btnNew);
			this.Controls.Add(this.btnLast);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnPrevious);
			this.Controls.Add(this.btnFirst);
			this.Controls.Add(this.listTransactions);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.textAmount);
			this.Controls.Add(this.textComments);
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
			this.Name = "CheckRegistry";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.Size = new System.Drawing.Size(488, 312);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public override void SetDefaultButton()
		{
			m_mainWindow.AcceptButton = btnNext;
		}

		public bool LoadCheckRegistry(string accountId, bool archived)
		{
            SaveRecord();

			m_accountId = accountId;
			m_archived = archived;

			btnNew.Enabled = !m_archived;

			UpdateBalances();

			textDate.Text = "";
			comboType.SelectedIndex = -1;
			textCheckNumber.Text = "";
			comboDescription.Text = "";
			comboDescription.SelectedIndex = -1;
			comboDescription.Items.Clear();
			textAmount.Text = "";
			checkCleared.Checked = false;
			checkArchived.Checked = false;
			textComments.Text = "";

			string sql = string.Format("select description from vendor_names where account_id = '{0}'", accountId);

			OleDbCommand selectCmd = new OleDbCommand(sql, m_dbConnection);
			OleDbDataReader dataReader = selectCmd.ExecuteReader();

			while(dataReader.Read())
			{
				comboDescription.Items.Add(dataReader[0].ToString());
			}

			dataReader.Close();

			listTransactions.Items.Clear();

			string archivedOperator = m_archived ? "=" : "<>";

			sql = string.Format("select * from check_register where account_id = '{0}' and archived {1} 1 order by trans_date", accountId, archivedOperator);

			selectCmd = new OleDbCommand(sql, m_dbConnection);
			dataReader = selectCmd.ExecuteReader();

			ListViewItem item = null;

			while(dataReader.Read())
			{
				CheckRegister rec = new CheckRegister();
				rec.Load(dataReader);

				item = new ListViewItem();
				item.Tag = rec;
				rec.Tag = item;

				if("Check" == rec.TransType)
				{
					item.Text = rec.CheckNumber;
				}
				else
				{
					item.Text = rec.TransType;
				}

				item.SubItems.Add(rec.Description);
				item.SubItems.Add(rec.TransDate.ToShortDateString());

				if("credit" == rec.TransCategory)
				{
					item.SubItems.Add(rec.Amount.ToString("C"));
				}
				else
				{
					item.SubItems.Add(string.Format("<{0:C}>", rec.Amount));
				}
				
				item.SubItems.Add((1 == rec.Cleared) ? "Yes" : "");

				listTransactions.Items.Add(item);
			}

			dataReader.Close();

			if(null != item)
			{
				item.Selected = true;
			}

            return true;
		}

		private void btnFirst_Click(object sender, System.EventArgs e)
		{
			if(0 != listTransactions.Items.Count)
			{
				listTransactions.Items[0].Selected = true;;
			}
		}

		private void btnPrevious_Click(object sender, System.EventArgs e)
		{
			if(0 != listTransactions.SelectedItems.Count)
			{
				int index = listTransactions.SelectedIndices[0] - 1;

				if(index >= 0)
				{
					listTransactions.Items[index].Selected = true;
				}
			}
		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{
			if(0 != listTransactions.SelectedItems.Count)
			{
				int index = listTransactions.SelectedIndices[0] + 1;

				if(index < listTransactions.Items.Count)
				{
					listTransactions.Items[index].Selected = true;
				}
				else
				{
					if (!m_archived)
					{
						btnNew_Click(null, null);
					}
				}
			}
		}

		private void btnLast_Click(object sender, System.EventArgs e)
		{
			if(0 != listTransactions.Items.Count)
			{
				listTransactions.Items[listTransactions.Items.Count - 1].Selected = true;;
			}				
		}

		private void btnNew_Click(object sender, System.EventArgs e)
		{
			ListViewItem item = new ListViewItem();
			item.SubItems.Add("");
			item.SubItems.Add("");
			item.SubItems.Add("");
			item.SubItems.Add("");

			CheckRegister rec = new CheckRegister();
			rec.AccountId = m_accountId;

			item.Tag = rec;
			rec.Tag = item;

			listTransactions.Items.Add(item);
			item.Selected = true;

			textDate.Focus();
		}

		private void SaveRecord()
		{
            CheckRegister rec = Tag as CheckRegister;

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
				rec.Amount = Convert.ToDouble(textAmount.Text);
				rec.Comments = textComments.Text;
				rec.Cleared = checkCleared.Checked ? 1 : 0;
				rec.Archived = checkArchived.Checked ? 1 : 0;

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
				ListViewItem item = (ListViewItem)rec.Tag;

				if("Check" == rec.TransType)
				{
					item.Text = rec.CheckNumber;
				}
				else
				{
					item.Text = rec.TransType;
				}

				item.SubItems[1].Text = rec.Description;
				item.SubItems[2].Text = rec.TransDateString;

				if("credit" == rec.TransCategory)
				{
					item.SubItems[3].Text = rec.Amount.ToString("C");
				}
				else
				{
					item.SubItems[3].Text = string.Format("<{0:C}>", rec.Amount);
				}

				if(-1 == comboDescription.FindStringExact(rec.Description))
				{
					comboDescription.Items.Add(rec.Description);
				}
				
				item.SubItems[4].Text = (1== rec.Cleared) ? "Yes" : "";

				UpdateBalances();

				Tag = null;
			}
			catch(Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void listTransactions_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            SaveRecord();

			if(0 != listTransactions.SelectedItems.Count)
			{
				ListViewItem item = listTransactions.SelectedItems[0];
				item.EnsureVisible();

                CheckRegister rec = item.Tag as CheckRegister;

                if (rec != null)
                {
                    Tag = rec;

                    textDate.Text = rec.TransDateString;
                    comboType.SelectedIndex = comboType.FindStringExact(rec.TransType);
                    textCheckNumber.Text = rec.CheckNumber;
                    comboDescription.SelectedIndex = comboDescription.FindStringExact(rec.Description);
                    textAmount.Text = rec.Amount.ToString();
                    checkCleared.Checked = (1 == rec.Cleared);
					checkArchived.Checked = (1 == rec.Archived);
                    textComments.Text = rec.Comments;

                    if (rec.IsNew)
                    {
                        m_statusBar.Panels[0].Text = "New Record";
                    }
                    else
                    {
                        m_statusBar.Panels[0].Text = string.Format("Record {0} of {1}", item.Index + 1, listTransactions.Items.Count);
                    }
                }
			}
			else
			{
                Tag = null;
				textDate.Text = "1/1/0001";
				comboType.SelectedIndex = -1;
				textCheckNumber.Text = "";
				comboDescription.Text = "";
				comboDescription.SelectedIndex = -1;
				textAmount.Text = "";
				checkCleared.Checked = false;
				checkArchived.Checked = false;
				textComments.Text = "";
			}
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

		private void menuContextDelete_Click(object sender, System.EventArgs e)
		{
			if(0 != listTransactions.SelectedItems.Count)
			{
				ListViewItem item = listTransactions.SelectedItems[0];
				listTransactions.Items.Remove(item);

				CheckRegister rec = (CheckRegister)item.Tag;
				
				rec.DeleteRecord(m_dbConnection);

				UpdateBalances();
			}		
		}

		public override void SaveCurrentRecord()
		{
			SaveRecord();	
		}
	}
}
