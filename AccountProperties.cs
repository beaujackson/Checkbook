using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Checkbook
{
	/// <summary>
	/// Summary description for AccountProperties.
	/// </summary>
	public class AccountProperties : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textAccountName;
		private System.Windows.Forms.TextBox textRoutingNumber;
		private System.Windows.Forms.TextBox textAccountNumber;
		private System.Windows.Forms.TextBox textComments;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private Account m_account;

		public AccountProperties(Account account)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_account = account;

			textAccountName.Text = account.AccountName;
			textRoutingNumber.Text = account.RoutingNumber;
			textAccountNumber.Text = account.AccountNumber;
			textComments.Text = account.Comments;
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textAccountName = new System.Windows.Forms.TextBox();
			this.textRoutingNumber = new System.Windows.Forms.TextBox();
			this.textAccountNumber = new System.Windows.Forms.TextBox();
			this.textComments = new System.Windows.Forms.TextBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Account name";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Routing number";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 20);
			this.label3.TabIndex = 4;
			this.label3.Text = "Account number";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 104);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 20);
			this.label4.TabIndex = 6;
			this.label4.Text = "Comments";
			this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// textAccountName
			// 
			this.textAccountName.Location = new System.Drawing.Point(120, 8);
			this.textAccountName.Name = "textAccountName";
			this.textAccountName.Size = new System.Drawing.Size(208, 20);
			this.textAccountName.TabIndex = 1;
			this.textAccountName.Text = "";
			// 
			// textRoutingNumber
			// 
			this.textRoutingNumber.Location = new System.Drawing.Point(120, 40);
			this.textRoutingNumber.Name = "textRoutingNumber";
			this.textRoutingNumber.Size = new System.Drawing.Size(208, 20);
			this.textRoutingNumber.TabIndex = 3;
			this.textRoutingNumber.Text = "";
			// 
			// textAccountNumber
			// 
			this.textAccountNumber.Location = new System.Drawing.Point(120, 72);
			this.textAccountNumber.Name = "textAccountNumber";
			this.textAccountNumber.Size = new System.Drawing.Size(208, 20);
			this.textAccountNumber.TabIndex = 5;
			this.textAccountNumber.Text = "";
			// 
			// textComments
			// 
			this.textComments.AcceptsReturn = true;
			this.textComments.Location = new System.Drawing.Point(8, 128);
			this.textComments.Multiline = true;
			this.textComments.Name = "textComments";
			this.textComments.Size = new System.Drawing.Size(320, 80);
			this.textComments.TabIndex = 7;
			this.textComments.Text = "";
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(92, 216);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 8;
			this.btnOk.Text = "OK";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(172, 216);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// AccountProperties
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(338, 248);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.textComments);
			this.Controls.Add(this.textAccountNumber);
			this.Controls.Add(this.textRoutingNumber);
			this.Controls.Add(this.textAccountName);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "AccountProperties";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Account Properties";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOk_Click(object sender, System.EventArgs e)
		{
			if("" == textAccountName.Text)
			{
				MessageBox.Show(this, "You must provide a name for the account!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			m_account.AccountName = textAccountName.Text;
			m_account.RoutingNumber = textRoutingNumber.Text;
			m_account.AccountNumber = textAccountNumber.Text;
			m_account.Comments = textComments.Text;

			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
