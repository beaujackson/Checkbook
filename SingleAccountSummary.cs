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
	public class SingleAccountSummary : CheckbookControl
	{
		private System.Windows.Forms.ListView listSummary;
		private System.Windows.Forms.ColumnHeader columnHeader1;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SingleAccountSummary()
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
			this.SuspendLayout();
			// 
			// listSummary
			// 
			this.listSummary.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						  this.columnHeader1});
			this.listSummary.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listSummary.Location = new System.Drawing.Point(0, 0);
			this.listSummary.Name = "listSummary";
			this.listSummary.Size = new System.Drawing.Size(392, 272);
			this.listSummary.TabIndex = 0;
			this.listSummary.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Account Info";
			this.columnHeader1.Width = 167;
			// 
			// SingleAccountSummary
			// 
			this.Controls.Add(this.listSummary);
			this.Name = "SingleAccountSummary";
			this.Size = new System.Drawing.Size(392, 272);
			this.ResumeLayout(false);

		}
		#endregion

		public void LoadSummary(string accountId)
		{
			listSummary.Columns[0].Width = listSummary.Width - 15;

			listSummary.Items.Clear();

			m_accountId = accountId;

			string sql = string.Format("select account_name, balance, cleared_balance, last_import from accounts_summary where id = '{0}'", m_accountId);

			OleDbCommand selectCmd = new OleDbCommand(sql, m_dbConnection);
			OleDbDataReader dataReader = selectCmd.ExecuteReader();

			while(dataReader.Read())
			{
				listSummary.Items.Add(dataReader[0].ToString());
				listSummary.Items.Add(string.Format("Balance: {0:C}", dataReader[1]));
				listSummary.Items.Add(string.Format("Cleared balance: {0:C}", dataReader[2]));
				listSummary.Items.Add(string.Format("Data last imported: {0}", dataReader[3].ToString()));
			}

			dataReader.Close();
		}
	}
}
