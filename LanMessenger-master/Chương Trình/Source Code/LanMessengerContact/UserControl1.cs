using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace LanMessengerControls
{
	/// <summary>
	/// Summary description for UserControl1.
	/// </summary>
	public class LanMessengerContact : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label txtContact;
		private System.Windows.Forms.PictureBox picSmiley;
		private System.Windows.Forms.ImageList imageList;
		private System.ComponentModel.IContainer components;
        private string contact; // username
        
		public LanMessengerContact()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitComponent call
			picSmiley.Image=imageList.Images[2];
		}
		public LanMessengerContact(string contact)
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitComponent call
			picSmiley.Image=imageList.Images[2];
			txtContact.Text=contact;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LanMessengerContact));
            this.picSmiley = new System.Windows.Forms.PictureBox();
            this.txtContact = new System.Windows.Forms.Label();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picSmiley)).BeginInit();
            this.SuspendLayout();
            // 
            // picSmiley
            // 
            this.picSmiley.BackColor = System.Drawing.Color.Transparent;
            this.picSmiley.Location = new System.Drawing.Point(13, 20);
            this.picSmiley.Name = "picSmiley";
            this.picSmiley.Size = new System.Drawing.Size(16, 16);
            this.picSmiley.TabIndex = 0;
            this.picSmiley.TabStop = false;
            this.picSmiley.DoubleClick += new System.EventHandler(this.picSmiley_DoubleClick);
            this.picSmiley.MouseLeave += new System.EventHandler(this.picSmiley_MouseLeave);
            this.picSmiley.MouseHover += new System.EventHandler(this.picSmiley_MouseHover);
            // 
            // txtContact
            // 
            this.txtContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtContact.ForeColor = System.Drawing.Color.Gray;
            this.txtContact.Location = new System.Drawing.Point(45, 20);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(128, 16);
            this.txtContact.TabIndex = 1;
            this.txtContact.Text = "Contact";
            this.txtContact.DoubleClick += new System.EventHandler(this.txtContact_DoubleClick);
            this.txtContact.MouseLeave += new System.EventHandler(this.txtContact_MouseLeave);
            this.txtContact.MouseHover += new System.EventHandler(this.txtContact_MouseHover);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "");
            this.imageList.Images.SetKeyName(1, "");
            this.imageList.Images.SetKeyName(2, "off.png");
            this.imageList.Images.SetKeyName(3, "on.png");
            // 
            // LanMessengerContact
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(223)))), ((int)(((byte)(226)))));
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.picSmiley);
            this.Name = "LanMessengerContact";
            this.Size = new System.Drawing.Size(202, 58);
            this.Resize += new System.EventHandler(this.LanMessengerContact_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picSmiley)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void LanMessengerContact_Resize(object sender, System.EventArgs e)
		{
			txtContact.Width=this.Width-32;
			this.Height=48;
		}

		public bool online;

		private void txtContact_DoubleClick(object sender, System.EventArgs e)
		{
			this.OnDoubleClick(new EventArgs());
		}

		private void picSmiley_DoubleClick(object sender, System.EventArgs e)
		{
			this.OnDoubleClick(new EventArgs());
		}

		public bool Online
		{
			get
			{
				return online;
			}
			set
			{
				online=value;
				if(value)
				{
					picSmiley.Image=imageList.Images[3];
				}
				else
				{
					picSmiley.Image=imageList.Images[2];
				}
				picSmiley.Update();
				picSmiley.Refresh();
			}
		}

        // Get Username để thao tác
		public string Contact
		{
			get
			{
                return contact;
			}
			set
			{
				contact = value;
			}
		}

        // Lấy display name để hiện trên Contact list
        public string DisplayName
        {
            get
            {
                return txtContact.Text;
            }
            set
            {
                txtContact.Text = value;
            }
        }

        private void txtContact_MouseHover(object sender, EventArgs e)
        {
            txtContact.ForeColor = System.Drawing.Color.Green;
            txtContact.Font = new System.Drawing.Font("Sitka Banner", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void txtContact_MouseLeave(object sender, EventArgs e)
        {
            txtContact.ForeColor = System.Drawing.Color.Gray;
            txtContact.Font = new System.Drawing.Font("Sitka Banner", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void picSmiley_MouseHover(object sender, EventArgs e)
        {
            txtContact.ForeColor = System.Drawing.Color.Green;
            txtContact.Font = new System.Drawing.Font("Sitka Banner", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void picSmiley_MouseLeave(object sender, EventArgs e)
        {
            txtContact.ForeColor = System.Drawing.Color.Gray;
            txtContact.Font = new System.Drawing.Font("Sitka Banner", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
	}
}
