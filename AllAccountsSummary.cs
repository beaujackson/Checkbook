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
	/// Summary description for AccountsSummary.
	/// </summary>
	public class AllAccountsSummary : CheckbookControl
	{
		private System.Windows.Forms.ListView listSummary;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AllAccountsSummary()
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
		private void InitializeComponent()
		{
			this.listSummary = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// listSummary
			// 
			this.listSummary.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						  this.columnHeader1,
																						  this.columnHeader2,
																						  this.columnHeader3,
																						  this.columnHeader4});
			this.listSummary.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listSummary.Location = new System.Drawing.Point(0, 0);
			this.listSummary.Name = "listSummary";
			this.listSummary.Size = new System.Drawing.Size(392, 272);
			this.listSummary.TabIndex = 0;
			this.listSummary.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Account";
			this.columnHeader1.Width = 167;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Balance";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader2.Width = 103;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Cleared Balance";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader3.Width = 103;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Last Import";
			this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader4.Width = 100;
			// 
			// AllAccountsSummary
			// 
			this.Controls.Add(this.listSummary);
			this.Name = "AllAccountsSummary";
			this.Size = new System.Drawing.Size(392, 272);
			this.ResumeLayout(false);

		}
		#endregion

		public void LoadSummaries()
		{
			listSummary.Items.Clear();

			string sql = "select id, account_name, balance, cleared_balance, last_import from accounts_summary";

			OleDbCommand selectCmd = new OleDbCommand(sql, m_dbConnection);
			OleDbDataReader dataReader = selectCmd.ExecuteReader();

			while(dataReader.Read())
			{
				ListViewItem item = new ListViewItem();
				item.Tag = dataReader[0].ToString();
				item.Text = (dataReader[1].ToString());
				item.SubItems.Add(string.Format("{0:C}", dataReader[2]));
				item.SubItems.Add(string.Format("{0:C}", dataReader[3]));
				item.SubItems.Add(dataReader[4].ToString());

				listSummary.Items.Add(item);
			}

			dataReader.Close();
		}
	}
}
