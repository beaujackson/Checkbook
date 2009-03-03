using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Configuration;

namespace Checkbook
{
	/// <summary>
	/// Summary description for LedgerEntry.
	/// </summary>
	public class LedgerEntry : BusinessControl
	{
		private System.Windows.Forms.TextBox textDate;
		private System.Windows.Forms.ComboBox comboType;
		private System.Windows.Forms.MenuItem menuContextDelete;
		private System.Windows.Forms.Button btnNew;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.ListView listEntries;
		private System.Windows.Forms.TextBox textAmount;
		private System.Windows.Forms.Button btnFirst;
		private System.Windows.Forms.Button btnPrevious;
		private System.Windows.Forms.ComboBox comboAccount;
		private System.Windows.Forms.ContextMenu contextMenu;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.TextBox textComments;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Button btnLast;
		private System.Windows.Forms.Label label8;
		private ComboBox comboDescription;
		private Label label3;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public LedgerEntry()
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
			this.label7 = new System.Windows.Forms.Label();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.textComments = new System.Windows.Forms.TextBox();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.contextMenu = new System.Windows.Forms.ContextMenu();
			this.menuContextDelete = new System.Windows.Forms.MenuItem();
			this.comboAccount = new System.Windows.Forms.ComboBox();
			this.btnPrevious = new System.Windows.Forms.Button();
			this.btnFirst = new System.Windows.Forms.Button();
			this.textAmount = new System.Windows.Forms.TextBox();
			this.listEntries = new System.Windows.Forms.ListView();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnNew = new System.Windows.Forms.Button();
			this.comboType = new System.Windows.Forms.ComboBox();
			this.textDate = new System.Windows.Forms.TextBox();
			this.comboDescription = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 144);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(80, 20);
			this.label8.TabIndex = 17;
			this.label8.Text = "Entries";
			this.label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// btnLast
			// 
			this.btnLast.Location = new System.Drawing.Point(168, 120);
			this.btnLast.Name = "btnLast";
			this.btnLast.Size = new System.Drawing.Size(25, 20);
			this.btnLast.TabIndex = 15;
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
			this.label4.Location = new System.Drawing.Point(270, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(51, 20);
			this.label4.TabIndex = 8;
			this.label4.Text = "Account";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(306, 7);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 20);
			this.label5.TabIndex = 4;
			this.label5.Text = "Amount";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(3, 72);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 20);
			this.label7.TabIndex = 10;
			this.label7.Text = "Comments";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Account";
			this.columnHeader5.Width = 117;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Entry date";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(142, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Entry type";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			this.textComments.TabIndex = 11;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Amount";
			this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader4.Width = 62;
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
			// comboAccount
			// 
			this.comboAccount.Location = new System.Drawing.Point(327, 40);
			this.comboAccount.Name = "comboAccount";
			this.comboAccount.Size = new System.Drawing.Size(153, 21);
			this.comboAccount.TabIndex = 9;
			this.comboAccount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboDescription_KeyUp);
			// 
			// btnPrevious
			// 
			this.btnPrevious.Location = new System.Drawing.Point(104, 120);
			this.btnPrevious.Name = "btnPrevious";
			this.btnPrevious.Size = new System.Drawing.Size(25, 20);
			this.btnPrevious.TabIndex = 13;
			this.btnPrevious.Text = "<";
			this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
			// 
			// btnFirst
			// 
			this.btnFirst.Location = new System.Drawing.Point(72, 120);
			this.btnFirst.Name = "btnFirst";
			this.btnFirst.Size = new System.Drawing.Size(25, 20);
			this.btnFirst.TabIndex = 12;
			this.btnFirst.Text = "|<";
			this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
			// 
			// textAmount
			// 
			this.textAmount.Location = new System.Drawing.Point(360, 8);
			this.textAmount.Name = "textAmount";
			this.textAmount.Size = new System.Drawing.Size(64, 20);
			this.textAmount.TabIndex = 5;
			this.textAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// listEntries
			// 
			this.listEntries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.listEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader2,
            this.columnHeader5,
            this.columnHeader4});
			this.listEntries.ContextMenu = this.contextMenu;
			this.listEntries.FullRowSelect = true;
			this.listEntries.HideSelection = false;
			this.listEntries.Location = new System.Drawing.Point(5, 171);
			this.listEntries.MultiSelect = false;
			this.listEntries.Name = "listEntries";
			this.listEntries.Size = new System.Drawing.Size(478, 136);
			this.listEntries.TabIndex = 18;
			this.listEntries.UseCompatibleStateImageBehavior = false;
			this.listEntries.View = System.Windows.Forms.View.Details;
			this.listEntries.SelectedIndexChanged += new System.EventHandler(this.listTransactions_SelectedIndexChanged);
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(136, 120);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(25, 20);
			this.btnNext.TabIndex = 14;
			this.btnNext.Text = ">";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnNew
			// 
			this.btnNew.Location = new System.Drawing.Point(200, 120);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(25, 20);
			this.btnNew.TabIndex = 16;
			this.btnNew.Text = "+";
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// comboType
			// 
			this.comboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboType.Items.AddRange(new object[] {
            "Credit",
            "Debit"});
			this.comboType.Location = new System.Drawing.Point(200, 8);
			this.comboType.Name = "comboType";
			this.comboType.Size = new System.Drawing.Size(93, 21);
			this.comboType.Sorted = true;
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
			// comboDescription
			// 
			this.comboDescription.Location = new System.Drawing.Point(72, 40);
			this.comboDescription.Name = "comboDescription";
			this.comboDescription.Size = new System.Drawing.Size(180, 21);
			this.comboDescription.TabIndex = 7;
			this.comboDescription.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboDescription_KeyUp);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(3, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 20);
			this.label3.TabIndex = 6;
			this.label3.Text = "Description";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LedgerEntry
			// 
			this.Controls.Add(this.comboDescription);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnNew);
			this.Controls.Add(this.btnLast);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnPrevious);
			this.Controls.Add(this.btnFirst);
			this.Controls.Add(this.listEntries);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.textAmount);
			this.Controls.Add(this.textComments);
			this.Controls.Add(this.comboAccount);
			this.Controls.Add(this.comboType);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textDate);
			this.Controls.Add(this.label1);
			this.Name = "LedgerEntry";
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

		public bool LoadLedgerEntry(int businessId)
		{
            SaveRecord();

			m_businessId = businessId;

			UpdateBalances();

			textDate.Text = "";
			comboType.SelectedIndex = -1;
			comboAccount.Text = "";
			comboAccount.SelectedIndex = -1;
			comboAccount.Items.Clear();
			comboDescription.Text = "";
			comboDescription.SelectedIndex = -1;
			comboDescription.Items.Clear();
			textAmount.Text = "";
			textComments.Text = "";

			string sql = string.Format("select account from ledger_accounts where business_id = {0}", businessId);

			OleDbCommand selectCmd = new OleDbCommand(sql, m_dbConnection);
			OleDbDataReader dataReader = selectCmd.ExecuteReader();

			while(dataReader.Read())
			{
				comboAccount.Items.Add(dataReader[0].ToString());
			}

			dataReader.Close();

			//@ need a query for this
			sql = string.Format("select distinct description from ledger where business_id = {0}", businessId);

			selectCmd = new OleDbCommand(sql, m_dbConnection);
			dataReader = selectCmd.ExecuteReader();

			while (dataReader.Read())
			{
				comboDescription.Items.Add(dataReader[0].ToString());
			}

			dataReader.Close();

			listEntries.Items.Clear();

			sql = string.Format("select * from ledger where business_id = {0} order by entry_date", businessId);

			selectCmd = new OleDbCommand(sql, m_dbConnection);
			dataReader = selectCmd.ExecuteReader();

			ListViewItem item = null;

			while(dataReader.Read())
			{
				Ledger rec = new Ledger();
				rec.Load(dataReader);

				item = new ListViewItem(rec.EntryDateString);
				item.Tag = rec;
				rec.Tag = item;

				item.SubItems.Add(rec.Description);
				item.SubItems.Add(rec.EntryAccount);

				if(rec.EntryType == "C")
				{
					item.SubItems.Add(rec.EntryAmount.ToString("C"));
				}
				else
				{
					item.SubItems.Add(string.Format("<{0:C}>", rec.EntryAmount));
				}
				
				listEntries.Items.Add(item);
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
			if(0 != listEntries.Items.Count)
			{
				listEntries.Items[0].Selected = true;;
			}
		}

		private void btnPrevious_Click(object sender, System.EventArgs e)
		{
			if(0 != listEntries.SelectedItems.Count)
			{
				int index = listEntries.SelectedIndices[0] - 1;

				if(index >= 0)
				{
					listEntries.Items[index].Selected = true;
				}
			}
		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{
			if(0 != listEntries.SelectedItems.Count)
			{
				int index = listEntries.SelectedIndices[0] + 1;

				if(index < listEntries.Items.Count)
				{
					listEntries.Items[index].Selected = true;
				}
				else
				{
					btnNew_Click(null, null);
				}
			}
		}

		private void btnLast_Click(object sender, System.EventArgs e)
		{
			if(0 != listEntries.Items.Count)
			{
				listEntries.Items[listEntries.Items.Count - 1].Selected = true;;
			}				
		}

		private void btnNew_Click(object sender, System.EventArgs e)
		{
			ListViewItem item = new ListViewItem("");
			item.SubItems.Add("");
			item.SubItems.Add("");
			item.SubItems.Add("");

			Ledger rec = new Ledger();
			rec.BusinessId = m_businessId;

			item.Tag = rec;
			rec.Tag = item;

			listEntries.Items.Add(item);
			item.Selected = true;

			textDate.Focus();
		}

		private void SaveRecord()
		{
            Ledger rec = Tag as Ledger;

            if (rec == null) return;

            if (rec.IsNew)
            {
                string msg = null;

                if (textDate.Text == "" || textDate.Text == "1/1/0001")
                {
                    msg = "Entry date is a required field";
                }

                if (comboType.SelectedIndex == -1)
                {
                    msg = "Entry type is a required field";
                }

                if (comboAccount.Text == "")
                {
                    msg = "Account is a required field";
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
                        listEntries.Items.Remove(item);
                        Tag = null;
                        return;
                    }
                    else
                    {
                        MessageBox.Show(this, "Entry is not saved, but will remain in the entries list.", "Entry not saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }

			try
			{
				rec.EntryDate = DateTime.Parse(textDate.Text);
				rec.EntryType = comboType.Text == "Credit" ? "C" : "D";
				rec.EntryAmount = Convert.ToDouble(textAmount.Text);
				rec.Description = comboDescription.Text;
				rec.EntryAccount = comboAccount.Text;
				rec.Comments = textComments.Text;
				
				rec.Store(m_dbConnection);
				
				ListViewItem item = (ListViewItem)rec.Tag;

				item.SubItems[0].Text = rec.EntryDateString;
				item.SubItems[1].Text = rec.Description;
				item.SubItems[2].Text = rec.EntryAccount;

				if("C" == rec.EntryType)
				{
					item.SubItems[3].Text = rec.EntryAmount.ToString("C");
				}
				else
				{
					item.SubItems[3].Text = string.Format("<{0:C}>", rec.EntryAmount);
				}

				if (-1 == comboDescription.FindStringExact(rec.Description))
				{
					comboDescription.Items.Add(rec.Description);
				}

				if(-1 == comboAccount.FindStringExact(rec.EntryAccount))
				{
					comboAccount.Items.Add(rec.EntryAccount);
				}
				
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

			if(0 != listEntries.SelectedItems.Count)
			{
				ListViewItem item = listEntries.SelectedItems[0];
				item.EnsureVisible();

                Ledger rec = item.Tag as Ledger;

                if (rec != null)
                {
                    Tag = rec;

					textDate.Text = rec.EntryDateString;
					comboType.SelectedIndex = rec.EntryType == "C" ? comboType.FindStringExact("Credit") : comboType.FindStringExact("Debit");
                    comboAccount.SelectedIndex = comboAccount.FindStringExact(rec.EntryAccount);
					comboDescription.SelectedIndex = comboDescription.FindStringExact(rec.Description);
					textAmount.Text = rec.EntryAmount.ToString();
                    textComments.Text = rec.Comments;

                    if (rec.IsNew)
                    {
                        m_statusBar.Panels[0].Text = "New Record";
                    }
                    else
                    {
                        m_statusBar.Panels[0].Text = string.Format("Record {0} of {1}", item.Index + 1, listEntries.Items.Count);
                    }
                }
			}
			else
			{
                Tag = null;
				textDate.Text = "1/1/0001";
				comboType.SelectedIndex = -1;
				comboAccount.Text = "";
				comboAccount.SelectedIndex = -1;
				comboDescription.SelectedIndex = -1;
				comboDescription.Text = "";
				textAmount.Text = "";
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
			ComboBox cb = sender as ComboBox;

			if (0 == cb.Text.Length)
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

			int index = cb.FindString(cb.Text);

			if(-1 != index)
			{
				int len = cb.Text.Length;
				string found = cb.Items[index].ToString().Substring(len);
				cb.Text += found;
				cb.SelectionStart = len;
				cb.SelectionLength = found.Length;
			}
		}

		private void menuContextDelete_Click(object sender, System.EventArgs e)
		{
			if(0 != listEntries.SelectedItems.Count)
			{
				ListViewItem item = listEntries.SelectedItems[0];
				listEntries.Items.Remove(item);

				Ledger rec = (Ledger)item.Tag;
				
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
