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
	/// Summary description for BusinessSummary.
	/// </summary>
	public class BusinessSummary : BusinessControl
	{
		private System.Windows.Forms.ListView listSummary;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private ColumnHeader columnHeader3;
		private ColumnHeader columnHeader4;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BusinessSummary()
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
			this.listSummary.UseCompatibleStateImageBehavior = false;
			this.listSummary.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Business";
			this.columnHeader1.Width = 104;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Revenue";
			this.columnHeader2.Width = 67;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Expenses";
			this.columnHeader3.Width = 77;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Mileage";
			this.columnHeader4.Width = 71;
			// 
			// BusinessSummary
			// 
			this.Controls.Add(this.listSummary);
			this.Name = "BusinessSummary";
			this.Size = new System.Drawing.Size(392, 272);
			this.ResumeLayout(false);

		}
		#endregion

		public void LoadSummary(int businessId)
		{
			listSummary.Items.Clear();

			m_businessId = businessId;

			string sql = string.Format("select business_name, fiscal_year, total from business_summary where id = {0}", m_businessId);

			OleDbCommand selectCmd = new OleDbCommand(sql, m_dbConnection);
			OleDbDataReader dataReader = selectCmd.ExecuteReader();

			bool firstTime = true;
			string lastYear = "junk";
			string currentYear;
			ListViewItem item = null;

			while(dataReader.Read())
			{
				if (firstTime)
				{
					listSummary.Items.Add(dataReader[0].ToString());
					firstTime = false;
				}

				currentYear = dataReader[1].ToString();

				if (currentYear != lastYear)
				{
					item = listSummary.Items.Add(dataReader[1].ToString());
					item.SubItems.Add(string.Format("{0:C}", dataReader[2]));

					lastYear = currentYear;
				}
				else
				{
					item.SubItems.Add(string.Format("{0:C}", dataReader[2]));
				}
			}

			dataReader.Close();
		}
	}
}
