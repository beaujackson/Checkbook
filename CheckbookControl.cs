using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Checkbook
{
	/// <summary>
	/// Summary description for CheckbookControl.
	/// </summary>
	public class CheckbookControl : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		protected Form m_mainWindow = null;
		protected StatusBar m_statusBar = null;
		protected OleDbConnection m_dbConnection = null;
		protected string m_accountId = null;

		public CheckbookControl()
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
			components = new System.ComponentModel.Container();
		}
		#endregion

		public Form MainWindow
		{
			get { return m_mainWindow; }
			set { m_mainWindow = value; }
		}

		public StatusBar StatusBar
		{
			get { return m_statusBar; }
			set { m_statusBar = value; }
		}

		public OleDbConnection DbConnection
		{
			get { return m_dbConnection; }
			set { m_dbConnection = value; }
		}

		public string AccountId
		{
			get { return m_accountId; }
			set { m_accountId = value; }
		}

		public virtual void SetDefaultButton()
		{
			return;
		}

		public virtual void UpdateBalances()
		{
			if(null == m_accountId)
			{
				return;
			}

			string sql = string.Format("select balance, cleared_balance, future_total, future_credit, future_debit from accounts_summary where id = '{0}'", m_accountId);

			OleDbCommand selectCmd = new OleDbCommand(sql, m_dbConnection);
			OleDbDataReader dataReader = selectCmd.ExecuteReader();

			Double fc;
			Double fd;
			Double ft;

			while(dataReader.Read())
			{
				m_statusBar.Panels[1].Text = string.Format("{0:C}", dataReader[0]);
				m_statusBar.Panels[2].Text = string.Format("{0:C}", dataReader[1]);
				
				if(System.DBNull.Value == dataReader[3])
				{
					fc = 0;
				}
				else
				{
					fc = (double)dataReader[3];
				}

				if(System.DBNull.Value == dataReader[4])
				{
					fd = 0;
				}
				else
				{
					fd = (double)dataReader[4];
				}

				ft = fc - fd;

				m_statusBar.Panels[3].Text = string.Format("{0:C}", ft);
			}

			dataReader.Close();
		}

		public virtual void SaveCurrentRecord()
		{
			return;
		}
	}
}
