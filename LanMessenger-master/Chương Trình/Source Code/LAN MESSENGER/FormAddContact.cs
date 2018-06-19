using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lan_Messenger
{
	/// <summary>
	/// Summary description for FormAddContact.
	/// </summary>
	public class FormAddContact : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtContact;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnCancel;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private PictureBox pictureBox2;
        private Label label2;
        private Panel panel1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private IContainer components;

        public FormAddContact()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddContact));
            this.txtContact = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(106, 69);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(184, 20);
            this.txtContact.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.btnAdd.Location = new System.Drawing.Point(106, 105);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 24);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.btnCancel.Location = new System.Drawing.Point(202, 105);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 24);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(11, 53);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(299, 2);
            this.bunifuSeparator1.TabIndex = 26;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(11, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(37, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "The name you need to add:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(321, 15);
            this.panel1.TabIndex = 27;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // FormAddContact
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(321, 154);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtContact);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddContact";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Thêm bạn bè";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormAddContact_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			if(Global.username==txtContact.Text)
			{
				MessageBox.Show("Bạn không thể thêm chính bạn vào danh sách được!");
				txtContact.Text="";
				this.DialogResult=DialogResult.None;
				return;
			}
			if(Global.server.AddContact(Global.username,txtContact.Text))
			{
				return;
			}
			else
			{
                // Global.server.GetContacts(Global.username) lấy mảng danh sách các Contact của người dùng hiện tại
                bool check = false; // Biến cờ để xác định sự tồn tại của User                
                foreach (object o in Global.server.GetContacts(Global.username))
                    if (o.ToString() == txtContact.Text) 
                    {
                        check = true;                        
                        break;
                    }
                if (check) MessageBox.Show("Người dùng này đã có trong danh sách bạn bè của bạn");
                else
                    MessageBox.Show("Người dùng này không tồn tại trong cơ sở dữ liệu!");
				this.DialogResult=DialogResult.None;
			}
		}

		private void FormAddContact_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(this.DialogResult==DialogResult.None)
				e.Cancel=true;
		}
	}
}
