using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;

namespace Checkbook
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Checkbook : System.Windows.Forms.Form
	{
		private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.Panel panelNav;
        private System.Windows.Forms.TreeView treeManagement;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem menuFile;
        private System.Windows.Forms.MenuItem menuEdit;
		private System.Windows.Forms.MenuItem menuHelp;
		private System.Windows.Forms.MenuItem menuNew;
		private System.Windows.Forms.MenuItem menuImport;
		private System.Windows.Forms.MenuItem menuSep1;
		private System.Windows.Forms.MenuItem menuExit;
		private System.Windows.Forms.MenuItem menuCut;
		private System.Windows.Forms.MenuItem menuCopy;
		private System.Windows.Forms.MenuItem menuPaste;
        private System.Windows.Forms.MenuItem menuAbout;
		private System.Windows.Forms.ContextMenu contextMenu;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.MenuItem menuContextProperties;
		private System.Windows.Forms.MenuItem menuProperties;
        private System.Windows.Forms.MenuItem menuContextDelete;
		private System.Windows.Forms.Panel panelMain;
		private System.Windows.Forms.Splitter splitter;
		private System.Windows.Forms.Panel panelView;
		private System.Windows.Forms.StatusBarPanel statusText;
		private System.Windows.Forms.StatusBarPanel statusBalance;
		private System.Windows.Forms.StatusBarPanel statusClearedBalance;
		private System.Windows.Forms.StatusBarPanel statusFutureItems;
        private IContainer components;

		private string m_connectString = "";
		private OleDbConnection m_dbConnection;

		private AllAccountsSummary m_allAccountsSummary;
		private SingleAccountSummary m_singleAccountSummary;
		private CheckRegistry m_checkRegistry;
		private CheckReconcile m_checkReconcile;
		private BusinessSummary m_businessSummary;
		private LedgerEntry m_ledgerEntry;
		private MenuItem menuSelectDb;
		private MenuItem menuArchive;
        private Hashtable m_accountRecs;
		private MenuItem menuNewBusiness;
		private MenuItem menuBusinessProperties;
		private MenuItem menuItem1;
		private Hashtable m_businessRecs;

        public Checkbook()
        {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            m_accountRecs = new Hashtable();
			m_businessRecs = new Hashtable();

			m_dbConnection = new OleDbConnection();

			m_allAccountsSummary = new AllAccountsSummary();
			m_allAccountsSummary.MainWindow = this;
			m_allAccountsSummary.StatusBar = statusBar;
			m_allAccountsSummary.DbConnection = m_dbConnection;

			m_singleAccountSummary = new SingleAccountSummary();
			m_singleAccountSummary.MainWindow = this;
			m_singleAccountSummary.StatusBar = statusBar;
			m_singleAccountSummary.DbConnection = m_dbConnection;

			m_checkRegistry = new CheckRegistry();
			m_checkRegistry.MainWindow = this;
			m_checkRegistry.StatusBar = statusBar;
			m_checkRegistry.DbConnection = m_dbConnection;

			m_checkReconcile = new CheckReconcile();
			m_checkReconcile.MainWindow = this;
			m_checkReconcile.StatusBar = statusBar;
			m_checkReconcile.DbConnection = m_dbConnection;

			m_businessSummary = new BusinessSummary();
			m_businessSummary.MainWindow = this;
			m_businessSummary.StatusBar = statusBar;
			m_businessSummary.DbConnection = m_dbConnection;

			m_ledgerEntry = new LedgerEntry();
			m_ledgerEntry.MainWindow = this;
			m_ledgerEntry.StatusBar = statusBar;
			m_ledgerEntry.DbConnection = m_dbConnection;

			CheckbookConfig config = CheckbookConfig.GetInstance();

			if (config.TestMode)
			{
				this.Text += " - TESTMODE";
			}

			m_connectString = config.ConnectString;

			if(string.IsNullOrEmpty(m_connectString))
			{
                if (false == SelectDb())
                {
                    Close();
                }
			}

			if(string.IsNullOrEmpty(m_connectString) == false)
			{
                bool tryAgain = true;

                while(tryAgain)
                {
                    try
                    {
				        m_dbConnection.ConnectionString = m_connectString;
                        m_dbConnection.Open();
                        
                        tryAgain = false;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, "Error connecting to database!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        if(ConnectionState.Open == m_dbConnection.State)
                        {
                            m_dbConnection.Close();
                        }

                        tryAgain = SelectDb();
                    }
                }

                try
                {
                    LoadCheckbook();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error loading checkbook!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Checkbook));
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.statusText = new System.Windows.Forms.StatusBarPanel();
			this.statusBalance = new System.Windows.Forms.StatusBarPanel();
			this.statusClearedBalance = new System.Windows.Forms.StatusBarPanel();
			this.statusFutureItems = new System.Windows.Forms.StatusBarPanel();
			this.panelNav = new System.Windows.Forms.Panel();
			this.treeManagement = new System.Windows.Forms.TreeView();
			this.contextMenu = new System.Windows.Forms.ContextMenu();
			this.menuContextProperties = new System.Windows.Forms.MenuItem();
			this.menuContextDelete = new System.Windows.Forms.MenuItem();
			this.menuArchive = new System.Windows.Forms.MenuItem();
			this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
			this.menuFile = new System.Windows.Forms.MenuItem();
			this.menuSelectDb = new System.Windows.Forms.MenuItem();
			this.menuNew = new System.Windows.Forms.MenuItem();
			this.menuProperties = new System.Windows.Forms.MenuItem();
			this.menuImport = new System.Windows.Forms.MenuItem();
			this.menuSep1 = new System.Windows.Forms.MenuItem();
			this.menuExit = new System.Windows.Forms.MenuItem();
			this.menuEdit = new System.Windows.Forms.MenuItem();
			this.menuCut = new System.Windows.Forms.MenuItem();
			this.menuCopy = new System.Windows.Forms.MenuItem();
			this.menuPaste = new System.Windows.Forms.MenuItem();
			this.menuHelp = new System.Windows.Forms.MenuItem();
			this.menuAbout = new System.Windows.Forms.MenuItem();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.panelMain = new System.Windows.Forms.Panel();
			this.panelView = new System.Windows.Forms.Panel();
			this.splitter = new System.Windows.Forms.Splitter();
			this.menuNewBusiness = new System.Windows.Forms.MenuItem();
			this.menuBusinessProperties = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.statusText)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBalance)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusClearedBalance)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusFutureItems)).BeginInit();
			this.panelNav.SuspendLayout();
			this.panelMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 347);
			this.statusBar.Name = "statusBar";
			this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusText,
            this.statusBalance,
            this.statusClearedBalance,
            this.statusFutureItems});
			this.statusBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.statusBar.ShowPanels = true;
			this.statusBar.Size = new System.Drawing.Size(672, 22);
			this.statusBar.TabIndex = 3;
			// 
			// statusText
			// 
			this.statusText.MinWidth = 100;
			this.statusText.Name = "statusText";
			this.statusText.Width = 300;
			// 
			// statusBalance
			// 
			this.statusBalance.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.statusBalance.MinWidth = 30;
			this.statusBalance.Name = "statusBalance";
			this.statusBalance.ToolTipText = "Balance";
			// 
			// statusClearedBalance
			// 
			this.statusClearedBalance.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.statusClearedBalance.MinWidth = 30;
			this.statusClearedBalance.Name = "statusClearedBalance";
			this.statusClearedBalance.ToolTipText = "Cleared Balance";
			// 
			// statusFutureItems
			// 
			this.statusFutureItems.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.statusFutureItems.MinWidth = 30;
			this.statusFutureItems.Name = "statusFutureItems";
			this.statusFutureItems.ToolTipText = "Total of Future Items";
			// 
			// panelNav
			// 
			this.panelNav.Controls.Add(this.treeManagement);
			this.panelNav.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelNav.Location = new System.Drawing.Point(0, 0);
			this.panelNav.Name = "panelNav";
			this.panelNav.Size = new System.Drawing.Size(152, 347);
			this.panelNav.TabIndex = 0;
			// 
			// treeManagement
			// 
			this.treeManagement.ContextMenu = this.contextMenu;
			this.treeManagement.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeManagement.HideSelection = false;
			this.treeManagement.Location = new System.Drawing.Point(0, 0);
			this.treeManagement.Name = "treeManagement";
			this.treeManagement.Size = new System.Drawing.Size(152, 347);
			this.treeManagement.TabIndex = 0;
			this.treeManagement.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeManagement_AfterSelect);
			this.treeManagement.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeManagement_MouseDown);
			// 
			// contextMenu
			// 
			this.contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuContextProperties,
            this.menuContextDelete,
            this.menuArchive});
			this.contextMenu.Popup += new System.EventHandler(this.contextMenu_Popup);
			// 
			// menuContextProperties
			// 
			this.menuContextProperties.Index = 0;
			this.menuContextProperties.Text = "Account &Properties...";
			this.menuContextProperties.Click += new System.EventHandler(this.menuContextProperties_Click);
			// 
			// menuContextDelete
			// 
			this.menuContextDelete.Index = 1;
			this.menuContextDelete.Text = "&Delete Account";
			this.menuContextDelete.Click += new System.EventHandler(this.menuContextDelete_Click);
			// 
			// menuArchive
			// 
			this.menuArchive.Index = 2;
			this.menuArchive.Text = "Archive Transactions...";
			this.menuArchive.Click += new System.EventHandler(this.menuArchive_Click);
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFile,
            this.menuEdit,
            this.menuHelp});
			// 
			// menuFile
			// 
			this.menuFile.Index = 0;
			this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuSelectDb,
            this.menuNew,
            this.menuProperties,
            this.menuImport,
            this.menuSep1,
            this.menuNewBusiness,
            this.menuBusinessProperties,
            this.menuItem1,
            this.menuExit});
			this.menuFile.Text = "&File";
			this.menuFile.Popup += new System.EventHandler(this.menuFile_Popup);
			// 
			// menuSelectDb
			// 
			this.menuSelectDb.Index = 0;
			this.menuSelectDb.Text = "&Select Database...";
			this.menuSelectDb.Click += new System.EventHandler(this.menuSelectDb_Click);
			// 
			// menuNew
			// 
			this.menuNew.Index = 1;
			this.menuNew.Text = "&New Account...";
			this.menuNew.Click += new System.EventHandler(this.menuNew_Click);
			// 
			// menuProperties
			// 
			this.menuProperties.Index = 2;
			this.menuProperties.Text = "Account &Properties...";
			this.menuProperties.Click += new System.EventHandler(this.menuProperties_Click);
			// 
			// menuImport
			// 
			this.menuImport.Index = 3;
			this.menuImport.Text = "&Import Bank Transactions...";
			this.menuImport.Click += new System.EventHandler(this.menuImport_Click);
			// 
			// menuSep1
			// 
			this.menuSep1.Index = 4;
			this.menuSep1.Text = "-";
			// 
			// menuExit
			// 
			this.menuExit.Index = 8;
			this.menuExit.Text = "E&xit";
			this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
			// 
			// menuEdit
			// 
			this.menuEdit.Index = 1;
			this.menuEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuCut,
            this.menuCopy,
            this.menuPaste});
			this.menuEdit.Text = "&Edit";
			// 
			// menuCut
			// 
			this.menuCut.Enabled = false;
			this.menuCut.Index = 0;
			this.menuCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
			this.menuCut.Text = "Cu&t";
			// 
			// menuCopy
			// 
			this.menuCopy.Enabled = false;
			this.menuCopy.Index = 1;
			this.menuCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
			this.menuCopy.Text = "&Copy";
			// 
			// menuPaste
			// 
			this.menuPaste.Enabled = false;
			this.menuPaste.Index = 2;
			this.menuPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
			this.menuPaste.Text = "&Paste";
			// 
			// menuHelp
			// 
			this.menuHelp.Index = 2;
			this.menuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuAbout});
			this.menuHelp.Text = "&Help";
			// 
			// menuAbout
			// 
			this.menuAbout.Index = 0;
			this.menuAbout.Text = "&About";
			this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "OFX files|*.ofx";
			this.openFileDialog.Title = "Select transaction file to import";
			// 
			// panelMain
			// 
			this.panelMain.Controls.Add(this.panelView);
			this.panelMain.Controls.Add(this.splitter);
			this.panelMain.Controls.Add(this.panelNav);
			this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMain.Location = new System.Drawing.Point(0, 0);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(672, 347);
			this.panelMain.TabIndex = 4;
			// 
			// panelView
			// 
			this.panelView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelView.Location = new System.Drawing.Point(156, 0);
			this.panelView.Name = "panelView";
			this.panelView.Size = new System.Drawing.Size(516, 347);
			this.panelView.TabIndex = 2;
			// 
			// splitter
			// 
			this.splitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitter.Location = new System.Drawing.Point(152, 0);
			this.splitter.Name = "splitter";
			this.splitter.Size = new System.Drawing.Size(4, 347);
			this.splitter.TabIndex = 1;
			this.splitter.TabStop = false;
			// 
			// menuNewBusiness
			// 
			this.menuNewBusiness.Index = 5;
			this.menuNewBusiness.Text = "New &Business...";
			this.menuNewBusiness.Click += new System.EventHandler(this.menuNewBusiness_Click);
			// 
			// menuBusinessProperties
			// 
			this.menuBusinessProperties.Index = 6;
			this.menuBusinessProperties.Text = "Business Proper&ties...";
			this.menuBusinessProperties.Click += new System.EventHandler(this.menuBusinessProperties_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 7;
			this.menuItem1.Text = "-";
			// 
			// Checkbook
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(672, 369);
			this.Controls.Add(this.panelMain);
			this.Controls.Add(this.statusBar);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu;
			this.Name = "Checkbook";
			this.Text = "Checkbook";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Checkbook_Closing);
			((System.ComponentModel.ISupportInitialize)(this.statusText)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBalance)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusClearedBalance)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusFutureItems)).EndInit();
			this.panelNav.ResumeLayout(false);
			this.panelMain.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args) 
		{
            Checkbook cb = new Checkbook();
            cb.ImportTransactions(args);
            SingleInstance.SingleApplication.Run(cb);
		}

		private void LoadCheckbook()
		{
			treeManagement.Nodes.Clear();

			TreeNode summaryNode = treeManagement.Nodes.Add("Accounts Summary");
			summaryNode.Tag = "all_summary";

			string sql = "select * from accounts order by account_name";

			OleDbCommand selectCmd = new OleDbCommand(sql, m_dbConnection);
			OleDbDataReader dataReader = selectCmd.ExecuteReader();

			while(dataReader.Read())
			{
				Account rec = new Account();
				rec.Load(dataReader);

                m_accountRecs[rec.AccountNumber] = rec;

				TreeNode accountNode = treeManagement.Nodes.Add(rec.AccountName);
				accountNode.Tag = rec.AccountNumber;

				TreeNode node = accountNode.Nodes.Add("Registry");
				node.Tag = "registry";

				node = accountNode.Nodes.Add("Reconcile");
				node.Tag = "reconcile";

				node = accountNode.Nodes.Add("Archived");
				node.Tag = "archived";
			}

			dataReader.Close();

			sql = "select * from businesses order by business_name";

			selectCmd = new OleDbCommand(sql, m_dbConnection);
			dataReader = selectCmd.ExecuteReader();

			while (dataReader.Read())
			{
				Business rec = new Business();
				rec.Load(dataReader);

				m_businessRecs[rec.BusinessName] = rec;

				TreeNode businessNode = treeManagement.Nodes.Add(rec.BusinessName);
				businessNode.Tag = "business";

				TreeNode node = businessNode.Nodes.Add("Ledger");
				node.Tag = "ledger";

				node = businessNode.Nodes.Add("Mileage");
				node.Tag = "mileage";
			}

			dataReader.Close();

			treeManagement.SelectedNode = summaryNode;
		}

        private bool SelectDb()
        {
			CheckbookConfig config = CheckbookConfig.GetInstance();

			string dbFile = config.DB;

            //"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=c:\\src\\checkbook\\checkbookapp.mdb"
            openFileDialog.Filter = "Access Database files|*.mdb";
            openFileDialog.Title = "Select checkbook database";

            if (dbFile != null)
            {
                string dbPath = dbFile.Substring(0, dbFile.LastIndexOf('\\'));
                openFileDialog.InitialDirectory = dbPath;
            }

            if (DialogResult.OK == openFileDialog.ShowDialog(this))
            {                
                m_connectString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}", openFileDialog.FileName);
				config.ConnectString = m_connectString;
				config.DB = openFileDialog.FileName;

				config.Save();
                
                return true;
            }

            return false;
        }

		private void menuNewBusiness_Click(object sender, EventArgs e)
		{
			/*!
			Business rec = new Business();
			AccountProperties dlg = new AccountProperties(rec);

			if (DialogResult.OK == dlg.ShowDialog(this))
			{
				rec.Store(m_dbConnection);

				m_accountRecs[rec.BusinessName] = rec;

				TreeNode businessNode = treeManagement.Nodes.Add(rec.BusinessName);
				businessNode.Tag = "business";

				TreeNode node = businessNode.Nodes.Add("Income");
				node.Tag = "income";

				node = businessNode.Nodes.Add("Expenses");
				node.Tag = "expenses";

				node = businessNode.Nodes.Add("Mileage");
				node.Tag = "mileage";
			}
			*/
		}

		private void menuBusinessProperties_Click(object sender, EventArgs e)
		{

		}

		private void menuNew_Click(object sender, System.EventArgs e)
		{
			Account rec = new Account();
			AccountProperties dlg = new AccountProperties(rec);
			if(DialogResult.OK == dlg.ShowDialog(this))
			{
				rec.Store(m_dbConnection);

				m_accountRecs[rec.AccountNumber] = rec;

				CheckRegister registerRec = new CheckRegister();
				registerRec.AccountId = rec.Id;
				registerRec.TransDate = DateTime.Now;
				registerRec.TransType = "Archive";
				registerRec.Amount = 0;
				registerRec.TransCategory = "credit";
				registerRec.Description = "account created";
				registerRec.Cleared = 1;
				registerRec.Store(m_dbConnection);

				TreeNode accountNode = treeManagement.Nodes.Add(rec.AccountName);
				accountNode.Tag = rec.AccountNumber;

				TreeNode node = accountNode.Nodes.Add("Registry");
				node.Tag = "registry";

				node = accountNode.Nodes.Add("Reconcile");
				node.Tag = "reconcile";

				node = accountNode.Nodes.Add("Archived");
				node.Tag = "archived";
			}
		}

		private void menuExit_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void menuContextDelete_Click(object sender, System.EventArgs e)
		{
			string msg = "This action will delete this account, and all of its associated registry entries and bank transactions.  You will not be able to undo this action.  Are you sure you want to delete this account?";
			
			if(DialogResult.Yes == MessageBox.Show(this, msg, "Delete Account?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
			{
                Account rec = m_accountRecs[treeManagement.SelectedNode.Tag] as Account;

				string sql = string.Format("delete from accounts where id = '{0}'", rec.Id);

				OleDbCommand delCmd = new OleDbCommand(sql, m_dbConnection);

				delCmd.ExecuteNonQuery();

				treeManagement.Nodes.Remove(treeManagement.SelectedNode);
				treeManagement.SelectedNode = treeManagement.Nodes[0];
			}
		}

		private void menuAbout_Click(object sender, System.EventArgs e)
		{
            AboutBox about = new AboutBox();
            about.ShowDialog(this);
		}

		private void treeManagement_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			while(panelView.Controls.Count > 0)
			{
				CheckbookControl c = panelView.Controls[0] as CheckbookControl;
                if(c != null) c.SaveCurrentRecord();

				BusinessControl b = panelView.Controls[0] as BusinessControl;
				if (b != null) b.SaveCurrentRecord();

				panelView.Controls.RemoveAt(0);
			}

			AcceptButton = null;

			foreach(StatusBarPanel panel in statusBar.Panels)
			{
				panel.Text = "";
			}

			string nodeType = treeManagement.SelectedNode.Tag.ToString();

			switch (nodeType)
			{
				case "all_summary":	//summary node			
					m_allAccountsSummary.LoadSummaries();
					panelView.Controls.Add(m_allAccountsSummary);
					m_allAccountsSummary.Dock = DockStyle.Fill;
					break;

				case "archived":
				case "registry":	//registry node
					{
						Account rec = m_accountRecs[treeManagement.SelectedNode.Parent.Tag] as Account;
						string accountId = rec.Id;

						m_checkRegistry.LoadCheckRegistry(accountId, (nodeType == "archived"));

						panelView.Controls.Add(m_checkRegistry);
						m_checkRegistry.Dock = DockStyle.Fill;
						m_checkRegistry.SetDefaultButton();
					}
					break;

				case "reconcile":	//reconcile node
					{
						Account rec = m_accountRecs[treeManagement.SelectedNode.Parent.Tag] as Account;
						string accountId = rec.Id;

						m_checkReconcile.LoadCheckReconcile(accountId);

						panelView.Controls.Add(m_checkReconcile);
						m_checkReconcile.Dock = DockStyle.Fill;
						m_checkReconcile.SetDefaultButton();
					}
					break;

				case "business":
					{
						Business rec = m_businessRecs[treeManagement.SelectedNode.Text] as Business;
						m_businessSummary.LoadSummary(rec.Id);
						panelView.Controls.Add(m_businessSummary);
						m_businessSummary.Dock = DockStyle.Fill;
						m_businessSummary.SetDefaultButton();
					}
					break;

				case "ledger":
					{
						Business rec = m_businessRecs[treeManagement.SelectedNode.Parent.Text] as Business;
						int businessId = rec.Id;

						m_ledgerEntry.LoadLedgerEntry(businessId);

						panelView.Controls.Add(m_ledgerEntry);
						m_ledgerEntry.Dock = DockStyle.Fill;
						m_ledgerEntry.SetDefaultButton();
					}
					break;

				case "mileage":
					{
						Business rec = m_businessRecs[treeManagement.SelectedNode.Parent.Text] as Business;
					}
					break;

				default:	//account node
					{
						Account rec = m_accountRecs[treeManagement.SelectedNode.Tag] as Account;
						string accountId = rec.Id;

						m_singleAccountSummary.LoadSummary(accountId);

						panelView.Controls.Add(m_singleAccountSummary);
						m_singleAccountSummary.Dock = DockStyle.Fill;
					}
					break;
			}
		}

		private void Checkbook_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(ConnectionState.Open == m_dbConnection.State)
			{
				m_dbConnection.Close();
			}				
		}

		private void menuContextProperties_Click(object sender, System.EventArgs e)
		{
			ShowProperties();
		}

		private void menuProperties_Click(object sender, System.EventArgs e)
		{
			ShowProperties();
		}

		private void ShowProperties()
		{
            Account rec = m_accountRecs[treeManagement.SelectedNode.Tag] as Account;

			AccountProperties dlg = new AccountProperties(rec);

			if(DialogResult.OK == dlg.ShowDialog(this))
			{
				rec.Store(m_dbConnection);
				treeManagement.SelectedNode.Text = rec.AccountName;
			}
		}

		private void menuArchive_Click(object sender, EventArgs e)
		{
			Archive dlg = new Archive();
			if (DialogResult.OK == dlg.ShowDialog(this))
			{
				Account rec = m_accountRecs[treeManagement.SelectedNode.Tag] as Account;

				string sql = string.Format("update check_register set archived = 1 where archived <> 1 and cleared = 1 and trans_date <= #{0}# and account_id = '{1}'", dlg.ArchiveDate.ToShortDateString(), rec.Id);

				OleDbCommand cmd = new OleDbCommand(sql, m_dbConnection);
				cmd.ExecuteNonQuery();
			}
		}

		private void menuFile_Popup(object sender, System.EventArgs e)
		{
			bool enable = false;

			if(null != treeManagement.SelectedNode)
			{
                enable = (null != m_accountRecs[treeManagement.SelectedNode.Tag]);
			}

			menuProperties.Enabled = enable;
		}

		private void contextMenu_Popup(object sender, System.EventArgs e)
		{
            bool enable = (null != m_accountRecs[treeManagement.SelectedNode.Tag]);

			menuContextProperties.Enabled = enable;
			menuContextDelete.Enabled = enable;
			menuArchive.Enabled = enable;
		}

		private void menuImport_Click(object sender, System.EventArgs e)
		{
			ImportTransactions();
		}

        private void ImportTransactions()
        {
			CheckbookConfig config = CheckbookConfig.GetInstance();

			string dataFolder = config.StartFolder;

            if(string.IsNullOrEmpty(dataFolder) == false) openFileDialog.InitialDirectory = dataFolder;

            openFileDialog.Filter = "OFX files|*.ofx";
            openFileDialog.Title = "Select transaction file to import";

            if (DialogResult.Cancel == openFileDialog.ShowDialog(this))
            {
                return;
            }

            dataFolder = openFileDialog.FileName.Substring(0, openFileDialog.FileName.LastIndexOf("\\"));

            config.StartFolder = dataFolder;
			config.Save();

            ImportTransactions(openFileDialog.FileName);
        }

        public void ImportTransactions(string[] args)
        {
            if (args.Length < 1)
            {
                return;
            }

            if (false == File.Exists(args[0]))
            {
                return;
            }

            ImportTransactions(args[0]);
        }

		private void ImportTransactions(string fileName)
		{
			Cursor c = Cursor;
			Cursor = Cursors.WaitCursor;

            Account account = null;
            ImportData import = new ImportData();

            StreamReader reader = null;

			bool showReconcileScreen = false;

            try
            {
                reader = new StreamReader(fileName);
                
                import.ImportDate = DateTime.Now;
                import.Data = reader.ReadToEnd();

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("The following error occurred while reading the import file {0}\n\n{1)\n\nImport failed!", fileName, ex.Message), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                reader = new StreamReader(fileName);

                string tag = "";

                BankTransaction tran = null;

                while ("" != (tag = FindNextTag(reader)))
                {
                    switch (tag)
                    {
                        case "<ACCTID>":
                            {
                                string accountNum = GetTagValue(reader);
                                account = m_accountRecs[accountNum] as Account;

                                if (account == null)
                                {
                                    MessageBox.Show(this, string.Format("There is no account with Account Number '{0}'.  Import failed!"), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                DialogResult dr = MessageBox.Show(this, string.Format("Import bank transactions into {0}?", account.AccountName), "Import?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (dr == DialogResult.No)
                                {
                                    return;
                                }

								showReconcileScreen = true;

                                account.LastImport = DateTime.Today.ToString("d");
                                account.Store(m_dbConnection);

                                import.AccountId = account.Id;
                                import.Store(m_dbConnection);
                            }
                            break;

                        case "<STMTTRN>":
                            if (account == null)
                            {
                                MessageBox.Show(this, "Invalid import file!  Import failed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            tran = new BankTransaction();
                            tran.AccountId = account.Id;
                            break;

                        case "</STMTTRN>":
                            if (tran == null)
                            {
                                MessageBox.Show(this, "Invalid import file!  Import failed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            try
                            {
                                tran.Store(m_dbConnection);
                            }
                            catch (OleDbException dbEx)
                            {
                                if (-2147467259 != dbEx.ErrorCode)
                                {
                                    //this is not a duplicate primary key error, so display it
                                    string msg = string.Format("The following error occurred while saving a bank transaction record:\n\n{0}\n\nThe record was not saved.  Click OK to continue with the next record, or Cancel.", dbEx.Message);

                                    if (DialogResult.Cancel == MessageBox.Show(this, msg, "Error!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error))
                                    {
                                        reader.Close();
                                        return;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                                string msg = string.Format("The following error occurred while saving a bank transaction record:\n\n{0}\n\nThe record was not saved.  Click OK to continue with the next record, or Cancel.", ex.Message);

                                if (DialogResult.Cancel == MessageBox.Show(this, msg, "Error!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error))
                                {
                                    reader.Close();
                                    Cursor = c;
                                    return;
                                }
                            }
                            break;

                        case "<TRNTYPE>":
                            //this trans type is a generic name for the transaction.
                            //the <NAME> field provides a nicer descripton for the
                            //trans type
                            if (tran == null)
                            {
                                MessageBox.Show(this, "Invalid import file!  Import failed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            tran.TransType = GetTagValue(reader);
                            break;

                        case "<DTPOSTED>":
                            {
                                if (tran == null)
                                {
                                    MessageBox.Show(this, "Invalid import file!  Import failed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                string transDate = GetTagValue(reader);
                                string dateFormatted = string.Format("{0}/{1}/{2}", transDate.Substring(4, 2), transDate.Substring(6, 2), transDate.Substring(0, 4));

                                tran.TransDate = DateTime.Parse(dateFormatted);
                            }
                            break;

                        case "<TRNAMT>":
                            {
                                if (tran == null)
                                {
                                    MessageBox.Show(this, "Invalid import file!  Import failed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                string amt = GetTagValue(reader);
                                tran.TransAmount = Convert.ToDouble(amt);
                            }
                            break;

                        case "<FITID>":
                            if (tran == null)
                            {
                                MessageBox.Show(this, "Invalid import file!  Import failed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            tran.TransactionId = GetTagValue(reader);
                            break;

                        case "<CHECKNUM>":
                            {
                                if (tran == null)
                                {
                                    MessageBox.Show(this, "Invalid import file!  Import failed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                string checkNum = GetTagValue(reader);
                                if ("000000" != checkNum)
                                {
                                    checkNum = checkNum.TrimStart(new char[] { '0' });
                                    tran.CheckNumber = checkNum;
                                }
                            }
                            break;

                        case "<NAME>":
                            if (tran == null)
                            {
                                MessageBox.Show(this, "Invalid import file!  Import failed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            tran.TransName = GetTagValue(reader);
                            break;

                        case "<MEMO>":
                            if (tran == null)
                            {
                                MessageBox.Show(this, "Invalid import file!  Import failed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            tran.Description = GetTagValue(reader);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if(reader != null) reader.Close();

				if (showReconcileScreen)
				{
					foreach (TreeNode node in treeManagement.Nodes)
					{
						if (node.Tag.ToString() == account.AccountNumber)
						{
							if (treeManagement.SelectedNode != node.Nodes[1])
							{
								treeManagement.SelectedNode = node.Nodes[1];
							}
							else
							{
								//force a refresh
								m_checkReconcile.LoadCheckReconcile(account.Id);
								m_checkReconcile.SetDefaultButton();
							}
						}
					}
				}

 			    Cursor = c;
            }
		}

		private string FindNextTag(StreamReader reader)
		{
			StringBuilder tag = new StringBuilder();

			int thisChar = -1;

			bool openFound = false;

			while(-1 != (thisChar = reader.Read()))
			{
				if(false == openFound)
				{
					if('<' == (char)thisChar)
					{
						openFound = true;
						tag.Append((char)thisChar);
					}
				}
				else
				{
					tag.Append((char)thisChar);

					if('>' == (char)thisChar)
					{
						break;
					}
				}
			}

			return tag.ToString();
		}

		private string GetTagValue(StreamReader reader)
		{
			StringBuilder tag = new StringBuilder();

			int thisChar = -1;

			while(-1 != (thisChar = reader.Peek()))
			{
				if('<' == (char)thisChar)
				{
					break;
				}

				tag.Append((char)reader.Read());
			}

			return tag.ToString();
		}

		private void treeManagement_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			treeManagement.SelectedNode = treeManagement.GetNodeAt(e.X, e.Y);
		}

        private void menuSelectDb_Click(object sender, EventArgs e)
        {
            SelectDb();
        }
	}
}
