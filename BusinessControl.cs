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
	/// Summary description for BusinessControl.
	/// </summary>
	public class BusinessControl : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		protected Form m_mainWindow = null;
		protected StatusBar m_statusBar = null;
		protected OleDbConnection m_dbConnection = null;
		protected int m_businessId;

		public BusinessControl()
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

		public int BusinessId
		{
			get { return m_businessId; }
			set { m_businessId = value; }
		}

		public virtual void SetDefaultButton()
		{
			return;
		}

		public virtual void UpdateBalances()
		{
			m_statusBar.Panels[1].Text = string.Empty;
			m_statusBar.Panels[2].Text = string.Empty;
			m_statusBar.Panels[3].Text = string.Empty;
		}

		public virtual void SaveCurrentRecord()
		{
			return;
		}
	}
}
