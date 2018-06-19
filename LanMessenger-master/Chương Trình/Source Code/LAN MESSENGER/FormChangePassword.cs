using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using LanMessengerLib;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

namespace Lan_Messenger
{
	/// <summary>
	/// Summary description for FormChangePassword.
	/// </summary>
	public class FormChangePassword : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		internal System.Windows.Forms.TextBox txtUsername;
		internal System.Windows.Forms.TextBox txtCurPassword;
		internal System.Windows.Forms.TextBox txtNewPassword;
		internal System.Windows.Forms.TextBox txtConfirmPassword;
        private Panel panel1;
        private Label label8;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator7;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator6;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator5;
        private PictureBox pictureBox1;
        private Label label5;
        private Label label6;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator3;
        private Label label7;
        private Label label9;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private IContainer components;

        public FormChangePassword()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChangePassword));
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtCurPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.bunifuSeparator7 = new Bunifu.Framework.UI.BunifuSeparator();
            this.bunifuSeparator6 = new Bunifu.Framework.UI.BunifuSeparator();
            this.bunifuSeparator5 = new Bunifu.Framework.UI.BunifuSeparator();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bunifuSeparator3 = new Bunifu.Framework.UI.BunifuSeparator();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(169, 16);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(160, 20);
            this.txtUsername.TabIndex = 4;
            // 
            // txtCurPassword
            // 
            this.txtCurPassword.Location = new System.Drawing.Point(169, 47);
            this.txtCurPassword.Name = "txtCurPassword";
            this.txtCurPassword.PasswordChar = '*';
            this.txtCurPassword.Size = new System.Drawing.Size(160, 20);
            this.txtCurPassword.TabIndex = 5;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(169, 77);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(160, 20);
            this.txtNewPassword.TabIndex = 6;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(169, 106);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(160, 20);
            this.txtConfirmPassword.TabIndex = 7;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.btnOK.Location = new System.Drawing.Point(169, 160);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 24);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.btnCancel.Location = new System.Drawing.Point(255, 160);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 24);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(398, 15);
            this.panel1.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Account Setting";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(12, 44);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(370, 2);
            this.bunifuSeparator1.TabIndex = 28;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 52);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(374, 216);
            this.tabControl1.TabIndex = 29;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.bunifuSeparator7);
            this.tabPage1.Controls.Add(this.bunifuSeparator6);
            this.tabPage1.Controls.Add(this.bunifuSeparator5);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.btnCancel);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.btnOK);
            this.tabPage1.Controls.Add(this.bunifuSeparator3);
            this.tabPage1.Controls.Add(this.txtConfirmPassword);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtNewPassword);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txtCurPassword);
            this.tabPage1.Controls.Add(this.txtUsername);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(366, 190);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Change the password";
            // 
            // bunifuSeparator7
            // 
            this.bunifuSeparator7.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator7.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bunifuSeparator7.LineThickness = 2;
            this.bunifuSeparator7.Location = new System.Drawing.Point(169, 130);
            this.bunifuSeparator7.Name = "bunifuSeparator7";
            this.bunifuSeparator7.Size = new System.Drawing.Size(160, 1);
            this.bunifuSeparator7.TabIndex = 19;
            this.bunifuSeparator7.Transparency = 255;
            this.bunifuSeparator7.Vertical = false;
            // 
            // bunifuSeparator6
            // 
            this.bunifuSeparator6.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator6.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bunifuSeparator6.LineThickness = 2;
            this.bunifuSeparator6.Location = new System.Drawing.Point(169, 100);
            this.bunifuSeparator6.Name = "bunifuSeparator6";
            this.bunifuSeparator6.Size = new System.Drawing.Size(160, 1);
            this.bunifuSeparator6.TabIndex = 18;
            this.bunifuSeparator6.Transparency = 255;
            this.bunifuSeparator6.Vertical = false;
            // 
            // bunifuSeparator5
            // 
            this.bunifuSeparator5.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator5.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bunifuSeparator5.LineThickness = 2;
            this.bunifuSeparator5.Location = new System.Drawing.Point(169, 70);
            this.bunifuSeparator5.Name = "bunifuSeparator5";
            this.bunifuSeparator5.Size = new System.Drawing.Size(160, 1);
            this.bunifuSeparator5.TabIndex = 17;
            this.bunifuSeparator5.Transparency = 255;
            this.bunifuSeparator5.Vertical = false;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(33, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Account name :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(33, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Current password :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bunifuSeparator3
            // 
            this.bunifuSeparator3.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bunifuSeparator3.LineThickness = 2;
            this.bunifuSeparator3.Location = new System.Drawing.Point(169, 39);
            this.bunifuSeparator3.Name = "bunifuSeparator3";
            this.bunifuSeparator3.Size = new System.Drawing.Size(160, 1);
            this.bunifuSeparator3.TabIndex = 12;
            this.bunifuSeparator3.Transparency = 255;
            this.bunifuSeparator3.Vertical = false;
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(33, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "New passwords :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(33, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Confirm password :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // FormChangePassword
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(398, 287);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormChangePassword";
            this.Text = "Thay đổi mật khẩu";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormChangePassword_Closing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if(this.txtNewPassword.Text==txtConfirmPassword.Text)
			{
				try
				{
					if(Global.server.ChangePassword(txtUsername.Text,txtCurPassword.Text,txtNewPassword.Text))
					{
						MessageBox.Show("Mật khẩu của bạn đã được thay đổi thành công!");
					}
					else
					{
						MessageBox.Show("Thao tác không thành công. Vui lòng kiểm tra lại thông tin!");
						this.DialogResult=DialogResult.None;
					}
				}
				catch
				{
                    MessageBox.Show("Lỗi kết nối tới Server. Vui lòng kiểm tra kết nối và thử lại!");
				}
			}
			else
			{
				MessageBox.Show("Mật khẩu xác nhận không khớp!");
				this.DialogResult=DialogResult.None;
			}
		}

		private void FormChangePassword_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(this.DialogResult==DialogResult.None)
			{
				e.Cancel=true;
			}
		}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
