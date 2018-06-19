using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using Khendys.Controls;
using System.Net;
using System.Runtime.Remoting.Channels;
using LanMessengerChatRoomBase;
using System.Runtime.Remoting.Channels.Tcp;
namespace Lan_Messenger
{
	/// <summary>
	/// Summary description for FormMessage.
	/// </summary>
	public class FormMessage : System.Windows.Forms.Form
	{
        private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.TextBox txtMessage;
		private System.Windows.Forms.Timer tmrBuzz;
		private System.Windows.Forms.Timer tmrBuzzOff;

		internal string contact;
		private System.Windows.Forms.Timer tmrBuzzCount;
        private PictureBox picBuzz;
        private ToolTip toolTip1;
        private ExRichTextBox rtbConversation;
        private Panel PanelFormMessage;
        private ToolBar toolBarFormMessage;
        private ToolBarButton tbbSmile;
        private ContextMenu contextMenuSmile;
        private Image[] emoticons;
        private ImageList toolBarIcons;
        private PictureBox picSendFile;
        private int buzzCount = 0;
        private string[] setting = new string[6]; // Có 6 Options tất cả
        public string IPServerPhoto; // địa chỉ IP được truyền từ FormPhotoRecive
        public string IPWebcam_rq = ""; // Địa chi IP của máy Request webcam
        public string IPWebcam_rp = ""; // Địa chỉ Ip của máy Response webcam
        public string LinkSongSend = ""; // Link nhạc gửi cho người được tặng.
        private string IPCaro = "";
        private string IPFile = "";
        private ToolTip toolTip2;
        private PictureBox picSharePhoto;
        private ToolTip toolTip3;
        private PictureBox picWebcam; // Của Server truyền cho người nhận
        public string IPContact; // Của người gửi truyền cho Client
        FormPhotoReceive fm;
        private ToolTip toolTip4;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private RadioButton rbtn_opacity;
        private PictureBox pctbCaro;
        private Panel panel1;
		public FormMessage()
		{

			InitializeComponent();
			//
			// Các Construtor ở đây!
			//

            // Bỏ mũi tên xổ xuống của nút mặt cười
            toolBarFormMessage.DropDownArrows = false;
            // Thêm Icon cho toolbar
            tbbSmile.ImageIndex = 0;
            toolBarIcons = new ImageList();
            toolBarIcons.ImageSize = new System.Drawing.Size(20, 20);
            toolBarIcons.Images.Add(Image.FromFile("images/smiles/face.png"));            
            toolBarIcons.ColorDepth = ColorDepth.Depth16Bit;
            toolBarIcons.TransparentColor = System.Drawing.Color.Transparent;
            toolBarFormMessage.ImageList = toolBarIcons;

            // Đọc UserSetting.dat nếu tồn tại
            if (File.Exists("UserSetting.dat"))
                ReadUserSetting();
            else
                setting[5] = "1";
            // Đưa các mặt cười vào một mảng
            emoticons = new Image[20];
            emoticons[0] = Image.FromFile("images/smiles/_1.gif");
            emoticons[1] = Image.FromFile("images/smiles/_2.gif");
            emoticons[2] = Image.FromFile("images/smiles/_3.gif");
            emoticons[3] = Image.FromFile("images/smiles/_4.gif");
            emoticons[4] = Image.FromFile("images/smiles/_5.gif");
            emoticons[5] = Image.FromFile("images/smiles/_6.gif");
            emoticons[6] = Image.FromFile("images/smiles/_7.gif");
            emoticons[7] = Image.FromFile("images/smiles/_8.gif");
            emoticons[8] = Image.FromFile("images/smiles/_9.gif");
            emoticons[9] = Image.FromFile("images/smiles/_10.gif");
            emoticons[10] = Image.FromFile("images/smiles/_11.gif");
            emoticons[11] = Image.FromFile("images/smiles/_12.gif");
            emoticons[12] = Image.FromFile("images/smiles/_13.gif");
            emoticons[13] = Image.FromFile("images/smiles/_14.gif");
            emoticons[14] = Image.FromFile("images/smiles/_15.gif");
            emoticons[15] = Image.FromFile("images/smiles/25.gif");
            emoticons[16] = Image.FromFile("images/smiles/26.gif");
            emoticons[17] = Image.FromFile("images/smiles/28.gif");
            emoticons[18] = Image.FromFile("images/smiles/39.gif");
            emoticons[19] = Image.FromFile("images/smiles/50.gif");

            EmoticonMenuItem _menuItem;
            int _count = 0;
            int i = 0;
            // Đưa các image mặt cười vào trong Toolbar
            foreach (Image _emoticon in emoticons)
            {
                _menuItem = new EmoticonMenuItem(_emoticon);
                if (i == 0) _menuItem.Click += new EventHandler(IconToCharacter1);
                if (i == 1) _menuItem.Click += new EventHandler(IconToCharacter2);
                if (i == 2) _menuItem.Click += new EventHandler(IconToCharacter3);
                if (i == 3) _menuItem.Click += new EventHandler(IconToCharacter4);
                if (i == 4) _menuItem.Click += new EventHandler(IconToCharacter5);
                if (i == 5) _menuItem.Click += new EventHandler(IconToCharacter6);
                if (i == 6) _menuItem.Click += new EventHandler(IconToCharacter7);
                if (i == 7) _menuItem.Click += new EventHandler(IconToCharacter8);
                if (i == 8) _menuItem.Click += new EventHandler(IconToCharacter9);
                if (i == 9) _menuItem.Click += new EventHandler(IconToCharacter10);
                if (i == 10) _menuItem.Click += new EventHandler(IconToCharacter11);
                if (i == 11) _menuItem.Click += new EventHandler(IconToCharacter12);
                if (i == 12) _menuItem.Click += new EventHandler(IconToCharacter13);
                if (i == 13) _menuItem.Click += new EventHandler(IconToCharacter14);
                if (i == 14) _menuItem.Click += new EventHandler(IconToCharacter15);
                if (i == 15) _menuItem.Click += new EventHandler(IconToCharacter16);
                if (i == 16) _menuItem.Click += new EventHandler(IconToCharacter17);
                if (i == 17) _menuItem.Click += new EventHandler(IconToCharacter18);
                if (i == 18) _menuItem.Click += new EventHandler(IconToCharacter19);
                if (i == 19) _menuItem.Click += new EventHandler(IconToCharacter20);
                if (_count % 4 == 0) // Giới hạn hiển thị ở 4 dòng
                    _menuItem.BarBreak = true;
                contextMenuSmile.MenuItems.Add(_menuItem);
                ++_count;
                i++;
            }
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMessage));
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.tmrBuzz = new System.Windows.Forms.Timer(this.components);
            this.tmrBuzzOff = new System.Windows.Forms.Timer(this.components);
            this.tmrBuzzCount = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.picBuzz = new System.Windows.Forms.PictureBox();
            this.rtbConversation = new Khendys.Controls.ExRichTextBox();
            this.PanelFormMessage = new System.Windows.Forms.Panel();
            this.pctbCaro = new System.Windows.Forms.PictureBox();
            this.rbtn_opacity = new System.Windows.Forms.RadioButton();
            this.picWebcam = new System.Windows.Forms.PictureBox();
            this.picSharePhoto = new System.Windows.Forms.PictureBox();
            this.picSendFile = new System.Windows.Forms.PictureBox();
            this.toolBarFormMessage = new System.Windows.Forms.ToolBar();
            this.tbbSmile = new System.Windows.Forms.ToolBarButton();
            this.contextMenuSmile = new System.Windows.Forms.ContextMenu();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSend = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBuzz)).BeginInit();
            this.PanelFormMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbCaro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWebcam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSharePhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSendFile)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(8, 3);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(236, 26);
            this.txtMessage.TabIndex = 2;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            this.txtMessage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyUp);
            // 
            // tmrBuzz
            // 
            this.tmrBuzz.Interval = 31;
            this.tmrBuzz.Tick += new System.EventHandler(this.tmrBuzz_Tick);
            // 
            // tmrBuzzOff
            // 
            this.tmrBuzzOff.Interval = 1000;
            this.tmrBuzzOff.Tick += new System.EventHandler(this.tmrBuzzOff_Tick);
            // 
            // tmrBuzzCount
            // 
            this.tmrBuzzCount.Enabled = true;
            this.tmrBuzzCount.Interval = 5000;
            this.tmrBuzzCount.Tick += new System.EventHandler(this.tmrBuzzCount_Tick);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "BUZZ!";
            // 
            // picBuzz
            // 
            this.picBuzz.BackColor = System.Drawing.SystemColors.Control;
            this.picBuzz.Image = ((System.Drawing.Image)(resources.GetObject("picBuzz.Image")));
            this.picBuzz.InitialImage = ((System.Drawing.Image)(resources.GetObject("picBuzz.InitialImage")));
            this.picBuzz.Location = new System.Drawing.Point(132, 4);
            this.picBuzz.Name = "picBuzz";
            this.picBuzz.Size = new System.Drawing.Size(29, 25);
            this.picBuzz.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBuzz.TabIndex = 3;
            this.picBuzz.TabStop = false;
            this.toolTip1.SetToolTip(this.picBuzz, "Buzz người bạn này!");
            this.picBuzz.Click += new System.EventHandler(this.picBuzz_Click);
            this.picBuzz.MouseLeave += new System.EventHandler(this.ChangePictureBuzz2);
            this.picBuzz.MouseHover += new System.EventHandler(this.ChangePictureBuzz1);
            // 
            // rtbConversation
            // 
            this.rtbConversation.HiglightColor = Khendys.Controls.RtfColor.White;
            this.rtbConversation.Location = new System.Drawing.Point(8, 6);
            this.rtbConversation.Name = "rtbConversation";
            this.rtbConversation.ReadOnly = true;
            this.rtbConversation.Size = new System.Drawing.Size(285, 308);
            this.rtbConversation.TabIndex = 4;
            this.rtbConversation.Text = "";
            this.rtbConversation.TextColor = Khendys.Controls.RtfColor.Black;
            // 
            // PanelFormMessage
            // 
            this.PanelFormMessage.Controls.Add(this.pctbCaro);
            this.PanelFormMessage.Controls.Add(this.rbtn_opacity);
            this.PanelFormMessage.Controls.Add(this.picWebcam);
            this.PanelFormMessage.Controls.Add(this.picSharePhoto);
            this.PanelFormMessage.Controls.Add(this.picSendFile);
            this.PanelFormMessage.Controls.Add(this.picBuzz);
            this.PanelFormMessage.Controls.Add(this.toolBarFormMessage);
            this.PanelFormMessage.Location = new System.Drawing.Point(8, 336);
            this.PanelFormMessage.Name = "PanelFormMessage";
            this.PanelFormMessage.Size = new System.Drawing.Size(285, 33);
            this.PanelFormMessage.TabIndex = 5;
            // 
            // pctbCaro
            // 
            this.pctbCaro.Image = global::Lan_Messenger.Properties.Resources.X;
            this.pctbCaro.Location = new System.Drawing.Point(254, 4);
            this.pctbCaro.Name = "pctbCaro";
            this.pctbCaro.Size = new System.Drawing.Size(24, 24);
            this.pctbCaro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctbCaro.TabIndex = 16;
            this.pctbCaro.TabStop = false;
            this.toolTip4.SetToolTip(this.pctbCaro, "Mời chat Webcam với người này...");
            this.pctbCaro.Click += new System.EventHandler(this.pctbCaro_Click);
            // 
            // rbtn_opacity
            // 
            this.rbtn_opacity.AutoSize = true;
            this.rbtn_opacity.Location = new System.Drawing.Point(47, 6);
            this.rbtn_opacity.Name = "rbtn_opacity";
            this.rbtn_opacity.Size = new System.Drawing.Size(82, 17);
            this.rbtn_opacity.TabIndex = 15;
            this.rbtn_opacity.TabStop = true;
            this.rbtn_opacity.Text = "Transparent";
            this.rbtn_opacity.UseVisualStyleBackColor = true;
            this.rbtn_opacity.CheckedChanged += new System.EventHandler(this.rbtn_opacity_CheckedChanged);
            // 
            // picWebcam
            // 
            this.picWebcam.Image = ((System.Drawing.Image)(resources.GetObject("picWebcam.Image")));
            this.picWebcam.Location = new System.Drawing.Point(224, 4);
            this.picWebcam.Name = "picWebcam";
            this.picWebcam.Size = new System.Drawing.Size(24, 24);
            this.picWebcam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWebcam.TabIndex = 8;
            this.picWebcam.TabStop = false;
            this.toolTip4.SetToolTip(this.picWebcam, "Mời chat Webcam với người này...");
            this.picWebcam.Click += new System.EventHandler(this.picWebcam_Click);
            this.picWebcam.MouseLeave += new System.EventHandler(this.picWebcam_MouseLeave);
            this.picWebcam.MouseHover += new System.EventHandler(this.picWebcam_MouseHover);
            // 
            // picSharePhoto
            // 
            this.picSharePhoto.Image = ((System.Drawing.Image)(resources.GetObject("picSharePhoto.Image")));
            this.picSharePhoto.Location = new System.Drawing.Point(194, 4);
            this.picSharePhoto.Name = "picSharePhoto";
            this.picSharePhoto.Size = new System.Drawing.Size(24, 24);
            this.picSharePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSharePhoto.TabIndex = 7;
            this.picSharePhoto.TabStop = false;
            this.toolTip3.SetToolTip(this.picSharePhoto, "Chia sẻ hình ảnh với người bạn này.");
            this.picSharePhoto.Click += new System.EventHandler(this.picSharePhoto_Click);
            this.picSharePhoto.MouseLeave += new System.EventHandler(this.picSharePhoto_MouseLeave);
            this.picSharePhoto.MouseHover += new System.EventHandler(this.picSharePhoto_MouseHover);
            // 
            // picSendFile
            // 
            this.picSendFile.Image = ((System.Drawing.Image)(resources.GetObject("picSendFile.Image")));
            this.picSendFile.Location = new System.Drawing.Point(164, 4);
            this.picSendFile.Name = "picSendFile";
            this.picSendFile.Size = new System.Drawing.Size(24, 24);
            this.picSendFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSendFile.TabIndex = 6;
            this.picSendFile.TabStop = false;
            this.toolTip2.SetToolTip(this.picSendFile, "Gửi file tới người bạn này...");
            this.picSendFile.Click += new System.EventHandler(this.picSendFile_Click);
            this.picSendFile.MouseLeave += new System.EventHandler(this.ChangePictureFileTransfer1);
            this.picSendFile.MouseHover += new System.EventHandler(this.ChangePictureFileTransfer2);
            // 
            // toolBarFormMessage
            // 
            this.toolBarFormMessage.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbbSmile});
            this.toolBarFormMessage.DropDownArrows = true;
            this.toolBarFormMessage.Location = new System.Drawing.Point(0, 0);
            this.toolBarFormMessage.Name = "toolBarFormMessage";
            this.toolBarFormMessage.ShowToolTips = true;
            this.toolBarFormMessage.Size = new System.Drawing.Size(285, 28);
            this.toolBarFormMessage.TabIndex = 0;
            // 
            // tbbSmile
            // 
            this.tbbSmile.DropDownMenu = this.contextMenuSmile;
            this.tbbSmile.Name = "tbbSmile";
            this.tbbSmile.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
            this.tbbSmile.ToolTipText = "Chèn mặt cười.";
            // 
            // toolTip2
            // 
            this.toolTip2.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip2.ToolTipTitle = "Gửi file...";
            // 
            // toolTip3
            // 
            this.toolTip3.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip3.ToolTipTitle = "Share Photo";
            // 
            // toolTip4
            // 
            this.toolTip4.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip4.ToolTipTitle = "Webcam...";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.bunifuSeparator1.LineThickness = 2;
            this.bunifuSeparator1.Location = new System.Drawing.Point(8, 320);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(284, 10);
            this.bunifuSeparator1.TabIndex = 13;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtMessage);
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 371);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 33);
            this.panel1.TabIndex = 14;
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.Location = new System.Drawing.Point(250, 3);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(43, 26);
            this.btnSend.TabIndex = 1;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // FormMessage
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(302, 404);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.PanelFormMessage);
            this.Controls.Add(this.rtbConversation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(296, 200);
            this.Name = "FormMessage";
            this.ShowIcon = false;
            this.Text = "7";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormMessage_Closing);
            this.Resize += new System.EventHandler(this.FormMessage_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picBuzz)).EndInit();
            this.PanelFormMessage.ResumeLayout(false);
            this.PanelFormMessage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbCaro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWebcam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSharePhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSendFile)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		internal void AddText(string person,string message)
		{
            if (message == "BUZZ IT")
            {
                tmrBuzz.Enabled = true;
                tmrBuzzOff.Enabled = true;
                rtbConversation.SelectionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold);
                message = "Kiss";
                this.Focus();
                if (File.Exists(setting[0]))
                {
                    System.Media.SoundPlayer sound = new System.Media.SoundPlayer(setting[0]);
                    sound.Play();
                }
                else
                {
                    System.Media.SoundPlayer sound = new System.Media.SoundPlayer("sounds/buzz.wav");
                    sound.Play();
                }
                
            }
            else // Khi ko phát tiếng BUZZ thì mới phát tiếng của file massage.wav
            {
                if (File.Exists(setting[3]))
                {
                    System.Media.SoundPlayer sound = new System.Media.SoundPlayer(setting[3]);
                    sound.Play();
                }
                else
                {
                    System.Media.SoundPlayer sound = new System.Media.SoundPlayer("sounds/message.wav");
                    sound.Play();
                }
            }
			rtbConversation.SelectionFont=new System.Drawing.Font("Microsoft Sans Serif",9.75f,System.Drawing.FontStyle.Bold);
			rtbConversation.AppendText(Global.server.GetfullName(person)+" : ");
			rtbConversation.SelectionFont=new System.Drawing.Font("Microsoft Sans Serif",9.75f,System.Drawing.FontStyle.Regular);
			rtbConversation.AppendText(message+" \n");
            CharactertoIcon(rtbConversation);
			txtMessage.Focus();
            if (setting[5] == "1" || setting[5] == "2")
                WriteLogs(person+" : " + message); // Ghi logs của mình nhận

            if (message == "Requesting caro playing ...") // Kiểm tra bạn chat có yêu cầu chơi caro hay không
            {
                this.Show();
                Global.server.Send(Global.username, contact, "Waiting for confirmation of caro playing request ...");
                switch (MessageBox.Show(Global.server.GetfullName(contact) + " Want to play caro with you. Do you accept?", "Caro playing request", MessageBoxButtons.YesNo))
                {
                    case DialogResult.Yes:
                        ServerCaroStart();
                        return;
                        break;
                    case DialogResult.No:
                        Global.server.Send(Global.username, contact, Global.username + " didn't accept your caro playing request!");
                        this.DialogResult = DialogResult.None;
                        break;
                }
            }

            if (message == "Requesting file sharing ...") // Kiểm tra bạn chat có yêu cầu chơi caro hay không
            {
                this.Show();
                Global.server.Send(Global.username, contact, "Waiting for confirmation of file sharing request ...");
                switch (MessageBox.Show(Global.server.GetfullName(contact) + " Want to share file with you. Do you accept?", "File sharing request", MessageBoxButtons.YesNo))
                {
                    case DialogResult.Yes:
                        ServerFileStart();
                        return;
                        break;
                    case DialogResult.No:
                        Global.server.Send(Global.username, contact, Global.username + " didn't accept your file sharing request!");
                        this.DialogResult = DialogResult.None;
                        break;
                }
            }

            if (message == "Requesting photo sharing ...") // Kiểm tra bạn chat có yêu cầu chia sẻ hình ảnh hay ko.
            {
                this.Show();
                Global.server.Send(Global.username, contact, "Waiting for confirmation of photo sharing request ...");
                switch (MessageBox.Show(Global.server.GetfullName(contact) + " Want to share pictures for you. Do you accept?", "Image sharing request", MessageBoxButtons.YesNo))
                {
                    case DialogResult.Yes:
                        ServerPhotoStart();
                        return;
                        break;
                    case DialogResult.No:
                        Global.server.Send(Global.username, contact, Global.username + " không chấp nhận yêu cầu chia sẻ hình ảnh của bạn!");
                        this.DialogResult = DialogResult.None;
                        break;
                }
            }

            if (message == "You are invited to Chat Room ...")
            {
                this.Show();
                switch (MessageBox.Show(Global.server.GetfullName(contact) + " muốn mời bạn tham gia Chat Room. Bạn có chập nhận không?", "Yêu cầu tham gia Chat Room", MessageBoxButtons.YesNo))
                {
                    case DialogResult.Yes:
                        OpenRoom();
                        return;
                        break;
                    case DialogResult.No:
                        Global.server.Send(Global.username, contact, Global.username + " từ chối tham gia Chat Room!");
                        this.DialogResult = DialogResult.None;
                        break;
                }
            }



            if ((IPContact = CheckSharePhoto(message)) != "")
            {
                //Đã chấp nhận yêu cầu chia sẻ hình ảnh
                ClientPhotoStart(); // Khởi động Client chia sẻ hình ảnh
            }

            if ((IPContact = CheckCaro(message)) != "")
            {
                //Đã chấp nhận yêu cầu chơi caro
                ClientCaroStart(); // Khởi động Client caro
            }

            if ((IPContact = CheckFile(message)) != "")
            {
                //Đã chấp nhận yêu cầu chia sẻ file
                ClientFileStart(); // Khởi động Client file
            }

            // Nhận IP chat webcam của máy phản hồi.
            if (message.IndexOf("Được đồng ý chat webcam") != -1)
            {
                IPWebcam_rp = GetIPofContact(message);
                FormWebcam fw = new FormWebcam(this);
                fw.Show();
            }

            // Kiểm tra có phải yêu cầu chat Webcam hay ko
            if (CheckWebcamRequest(message) != "")
            {
                this.Show();
                switch (MessageBox.Show(Global.server.GetfullName(contact) + " muốn mời bạn chat Webcam. Bạn có đồng ý không?", "Chat Webcam...", MessageBoxButtons.YesNo))
                {
                    case DialogResult.Yes:
                        IPHostEntry IP = Dns.GetHostByName(Dns.GetHostName().ToString());
                        string tempIP = IP.AddressList[0].ToString(); // IP máy phản hồi
                        Global.server.Send(Global.username, contact, "Được đồng ý chat webcam - IP: " + tempIP);
                        IPWebcam_rq = GetIPofContact(message); // IP của máy yêu cầu
                        FormWebcam fw = new FormWebcam(this);
                        fw.Show();
                        return;
                        break;
                    case DialogResult.No:
                        Global.server.Send(Global.username, contact, Global.username + " không muốn chat Webcam!");
                        this.DialogResult = DialogResult.None;
                        break;
                }
            }
		}


        bool ChatRoomClosed = false;
        public void GetValue(Boolean b)
        {
            ChatRoomClosed = b;
            if (ChatRoomClosed)
            {
                ChannelServices.UnregisterChannel(chan);
                chan = null;
            }
        }

        TcpChannel chan;
        private void OpenRoom()
        {
            ArrayList alOnlineUser = new ArrayList();
            FormChatRoom objChatWin;

            if (chan == null)
            {
                chan = new TcpChannel();
                ChannelServices.RegisterChannel(chan, false);

                objChatWin = new FormChatRoom();
                objChatWin.MyGetData = new FormChatRoom.GetString(GetValue);
                objChatWin.remoteObj = (SampleObject)Activator.GetObject(typeof(LanMessengerChatRoomBase.SampleObject), "tcp://" + Global.server.GetIP(contact) + ":7070/" + contact);

                if (!objChatWin.remoteObj.JoinToChatRoom(Global.username))
                {
                    MessageBox.Show(Global.username + " đã đăng nhập rồi!. Có thể mạng bị lag, hãy thử lại sau!");
                    ChannelServices.UnregisterChannel(chan);
                    chan = null;
                    objChatWin.Dispose();
                    return;
                }
                objChatWin.key = objChatWin.remoteObj.CurrentKeyNo();
                objChatWin.yourName = Global.username;
                objChatWin.Show();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra khi tạo Room Chat, vui lòng thử lại sau!");
                ChannelServices.UnregisterChannel(chan);
                chan = null;
            }
        }
		private void btnSend_Click(object sender, System.EventArgs e)
		{
			rtbConversation.SelectionFont=new System.Drawing.Font("Microsoft Sans Serif",9.75f,System.Drawing.FontStyle.Bold);
			rtbConversation.AppendText(Global.server.GetfullName(Global.username)+" : ");
			rtbConversation.SelectionFont=new System.Drawing.Font("Microsoft Sans Serif",9.75f,System.Drawing.FontStyle.Regular);
            rtbConversation.AppendText(txtMessage.Text + " \n");
            CharactertoIcon(rtbConversation);
			rtbConversation.Focus();
            if (setting[5] == "1" || setting[5] == "2")
                WriteLogs(Global.username + " : " + txtMessage.Text); // Ghi log của mình gửi
            Global.server.Send(Global.username, contact, txtMessage.Text); // Có thể xử lý thêm trường hợp ko cho phép gửi tin nhắn tới "tài koản ko tồn tại" ở đây.
			txtMessage.Focus();
			txtMessage.Clear();
		}

        string [] lastMessage = new string[10];
        int posLM = 0;
        int j = 0;
        bool UpPressed = false;
		private void txtMessage_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (e.KeyCode != Keys.Up)
            {
                if (e.KeyCode != Keys.Down)
                    j = posLM;
            }
            if (e.KeyCode == Keys.Up) // Lấy lại các tin đã gửi trước đó bỏ vào khung chat (Up)
            {
                UpPressed = true;
                j--;
                if (j < 0)
                {
                      j = 9;
                    if (lastMessage[9] == null)
                        j = posLM - 1;
                    if (j < 0)
                        j = 0;
                }
                txtMessage.Text = lastMessage[j];
                txtMessage.SelectionStart = txtMessage.Text.Length;
            }

            if (e.KeyCode == Keys.Down) // Lấy lại các tin đã gửi trước đó bỏ vào khung chat (Down)
            {
                if (UpPressed)
                {
                    j++;
                    if (j > 9 || lastMessage[j] == null)
                    {
                        j = 0;
                    }
                    txtMessage.Text = lastMessage[j];
                    txtMessage.SelectionStart = txtMessage.Text.Length;
                }
            }

			if(e.KeyCode==Keys.Enter)
			{
                if (txtMessage.Text != "")
                {           
                    lastMessage[posLM] = txtMessage.Text;
                    posLM++;
                    if (posLM > 9)
                        posLM = 0;
                    j = posLM;
                    btnSend_Click(null, null);
                }
			}
            // Khi nhấn Ctrl + G thì sẻ Buzz kiểu như YAHOO MESSENGER :D
			if(e.KeyCode==Keys.G&&e.Control)
			{
				if(buzzCount>=2)
				{
					MessageBox.Show("Bạn chỉ được sử dụng tính năng BUZZ không quá 2 lần trong mỗi 5 giây.");
					return;
				}                
				buzzCount++;
				Global.server.Send(Global.username,contact,"BUZZ IT");
				rtbConversation.SelectionFont=new System.Drawing.Font("Microsoft Sans Serif",9.75f,System.Drawing.FontStyle.Bold);                
				rtbConversation.AppendText(Global.server.GetfullName(Global.username)+" : Kiss \n");
                if (setting[5] == "1" || setting[5] == "2")
                    WriteLogs(Global.username + " : " + "Kiss"); // Ghi log của mình gửi (buzz)
				tmrBuzz.Enabled=true;
				tmrBuzzOff.Enabled=true;
				txtMessage.Focus();
                if (File.Exists(setting[0]))
                {
                    System.Media.SoundPlayer sound = new System.Media.SoundPlayer(setting[0]);
                    sound.Play();
                }
                else
                {
                    System.Media.SoundPlayer sound = new System.Media.SoundPlayer("sounds/buzz.wav");
                    sound.Play();
                }
			}
		}

		private void FormMessage_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Global.windowList.Remove(contact);
		}

        // Xóa nội dung trong ô soạn thảo sau khi đã gửi
		private void txtMessage_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				txtMessage.Clear();
			}
		}

		private void FormMessage_Resize(object sender, System.EventArgs e)
		{
			rtbConversation.Width=this.Width-24;
			rtbConversation.Height=this.Height-96;
			btnSend.Location=new System.Drawing.Point(this.Width-80,this.Height-80);
			txtMessage.Location=new Point(8,this.Height-80);
			txtMessage.Size =new System.Drawing.Size(this.Width-96,40);
		}


        // Tạo hiệu ứng rung cửa sổ chat khi người dùng BUZZ
		int loc=0;
		private void tmrBuzz_Tick(object sender, System.EventArgs e)
		{
			switch(loc)
			{
				case 0:
					this.Location=new Point(this.Location.X+10,this.Location.Y);
					break;
				case 1:
					this.Location=new Point(this.Location.X,this.Location.Y+10);
					break;
				case 2:
					this.Location=new Point(this.Location.X-10,this.Location.Y);
					break;
				case 3:
					this.Location=new Point(this.Location.X,this.Location.Y-10);
					break;
			}
			loc++;
			loc%=4;
		}

		private void tmrBuzzOff_Tick(object sender, System.EventArgs e)
		{
			tmrBuzz.Enabled=false;
			tmrBuzz.Enabled=false;
		}

		private void tmrBuzzCount_Tick(object sender, System.EventArgs e)
		{
			buzzCount=0;
		}

        // Khi txtMessage không chứa chữ thì làm mở nút Gửi (ko thể gửi tn được)
        private void txtMessage_TextChanged(object sender, System.EventArgs e)
        {
            if (txtMessage.Text == "")
                btnSend.Enabled = false;
            else
                btnSend.Enabled = true;
        }

        //
        // Phần giao diện
        //
        // Nút Buzz 2
        private void ChangePictureBuzz1(object sender, System.EventArgs e)
        {
            picBuzz.Image = Image.FromFile("images/hearts.png");
            
        }

        // Nút Buzz 1
        private void ChangePictureBuzz2(object sender, System.EventArgs e)
        {
            picBuzz.Image = Image.FromFile("images/hearts.png");            
        }
        
        // Nút File Transfer 1
        private void ChangePictureFileTransfer1(object sender, System.EventArgs e)
        {
            picSendFile.Image = Image.FromFile("images/document1.png");
        }

        // Nút File Transfer 2
        private void ChangePictureFileTransfer2(object sender, System.EventArgs e)
        {
            picSendFile.Image = Image.FromFile("images/document.png");
        }


        private void picSharePhoto_MouseHover(object sender, EventArgs e)
        {
            picSharePhoto.Image = Image.FromFile("images/frame.png");
        }

        private void picSharePhoto_MouseLeave(object sender, EventArgs e)
        {
            picSharePhoto.Image = Image.FromFile("images/frame1.png");
        }

        private void picWebcam_MouseHover(object sender, EventArgs e)
        {
            picWebcam.Image = Image.FromFile("images/instagram.png");
        }

        private void picWebcam_MouseLeave(object sender, EventArgs e)
        {
            picWebcam.Image = Image.FromFile("images/instagram1.png");
        }

        // Nhấn Icon Buzz
        private void picBuzz_Click(object sender, EventArgs e)
        {
            if (buzzCount >= 2)
            {
                MessageBox.Show("Bạn chỉ được sử dụng tính năng KISS không quá 2 lần trong mỗi 5 giây.");
                return;
            }
            buzzCount++;
            Global.server.Send(Global.username, contact, "BUZZ IT");
            rtbConversation.SelectionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold);
            rtbConversation.AppendText(Global.server.GetfullName(Global.username) + " : Kiss \n");
            if (setting[5] == "1" || setting[5] == "2")
                WriteLogs(Global.username + " : " + "Kiss"); // Ghi log của mình gửi (buzz)
            tmrBuzz.Enabled = true;
            tmrBuzzOff.Enabled = true;
            txtMessage.Focus();
            if (File.Exists(setting[0]))
            {
                System.Media.SoundPlayer sound = new System.Media.SoundPlayer(setting[0]);
                sound.Play();
            }
            else
            {
                System.Media.SoundPlayer sound = new System.Media.SoundPlayer("sounds/buzz.wav");
                sound.Play();
            }
        }
    
        // Chuyển các kí tự mặt cười sang hình ảnh
        private void CharactertoIcon(ExRichTextBox r)
        {
            int _index = 0;
            if ((_index = r.Find(":)")) > -1)
            {
                r.Select(_index, ":)".Length);
                r.InsertImage(Image.FromFile("images/smiles/_1.gif"));
            }

            if ((_index = r.Find(":(")) > -1)
            {
                r.Select(_index, ":(".Length);
                r.InsertImage(Image.FromFile("images/smiles/_2.gif"));
            }

            if ((_index = r.Find(";)")) > -1)
            {
                r.Select(_index, ";)".Length);
                r.InsertImage(Image.FromFile("images/smiles/_3.gif"));
            }

            if ((_index = r.Find(":D")) > -1)
            {
                r.Select(_index, ":D".Length);
                r.InsertImage(Image.FromFile("images/smiles/_4.gif"));
            }

            if ((_index = r.Find("8->")) > -1)
            {
                r.Select(_index, "8->".Length);
                r.InsertImage(Image.FromFile("images/smiles/_5.gif"));
            }

            if ((_index = r.Find(":|")) > -1)
            {
                r.Select(_index, ":|".Length);
                //r.InsertImage(Image.FromFile("images/smiles/22.gif"));
                r.InsertImage(Image.FromFile("images/smiles/_14.gif"));
            }
            if ((_index = r.Find(":X")) > -1)
            {
                r.Select(_index, ":X".Length);
                //r.InsertImage(Image.FromFile("images/smiles/8.gif"));
                r.InsertImage(Image.FromFile("images/smiles/_6.gif"));
            }
            if ((_index = r.Find(":\">")) > -1)
            {
                r.Select(_index, ":\">".Length);
                r.InsertImage(Image.FromFile("images/smiles/_7.gif"));
            }
            if ((_index = r.Find(":-*")) > -1)
            {
                r.Select(_index, ":-*".Length);
                r.InsertImage(Image.FromFile("images/smiles/_9.gif"));
            }
            if ((_index = r.Find("X(")) > -1)
            {
                r.Select(_index, "X(".Length);
                r.InsertImage(Image.FromFile("images/smiles/_10.gif"));
            }
            if ((_index = r.Find("b-)")) > -1)
            {
                r.Select(_index, "b-)".Length);
                r.InsertImage(Image.FromFile("images/smiles/_12.gif"));
            }
            if ((_index = r.Find(":-S")) > -1)
            {
                r.Select(_index, ":-S".Length);
                r.InsertImage(Image.FromFile("images/smiles/_13.gif"));
            }
            if ((_index = r.Find("=))")) > -1)
            {
                r.Select(_index, "=))".Length);
                //r.InsertImage(Image.FromFile("images/smiles/24.gif"));
                r.InsertImage(Image.FromFile("images/smiles/_15.gif"));
            }
            if ((_index = r.Find("O:-)")) > -1)
            {
                r.Select(_index, "O:-)".Length);
                r.InsertImage(Image.FromFile("images/smiles/25.gif"));
            }
            if ((_index = r.Find(":-B")) > -1)
            {
                r.Select(_index, ":-B".Length);
                r.InsertImage(Image.FromFile("images/smiles/26.gif"));
            }
            if ((_index = r.Find("I-)")) > -1)
            {
                r.Select(_index, "I-)".Length);
                r.InsertImage(Image.FromFile("images/smiles/28.gif"));
            }
            if ((_index = r.Find(":-?")) > -1)
            {
                r.Select(_index, ":-?".Length);
                r.InsertImage(Image.FromFile("images/smiles/39.gif"));
            }
            if ((_index = r.Find("3:-O")) > -1)
            {
                r.Select(_index, "3:-O".Length);
                r.InsertImage(Image.FromFile("images/smiles/50.gif"));
            }
            if ((_index = r.Find("~:>")) > -1)
            {
                r.Select(_index, "~:>".Length);
                r.InsertImage(Image.FromFile("images/smiles/_11.gif"));
            }
            if ((_index = r.Find(":P")) > -1)
            {
                r.Select(_index, ":P".Length);
                r.InsertImage(Image.FromFile("images/smiles/_8.gif"));
            }
        }

        // Các sự kiện khi bấm vào 1 Icon trên menu sẻ chèn kí tự mặt cười vào textbox
        
        private void IconToCharacter1(object _sender, EventArgs _args)
        {
            txtMessage.Text += ":)";            
        }
        private void IconToCharacter2(object _sender, EventArgs _args)
        {
            txtMessage.Text += ":(";
        }
        private void IconToCharacter3(object _sender, EventArgs _args)
        {

            txtMessage.Text += ";)";
        }
        private void IconToCharacter4(object _sender, EventArgs _args)
        {

            txtMessage.Text += ":D";
        }
        private void IconToCharacter5(object _sender, EventArgs _args)
        {

            txtMessage.Text += "8->";
        }
        private void IconToCharacter6(object _sender, EventArgs _args)
        {

            txtMessage.Text += ":X";
        }
        private void IconToCharacter7(object _sender, EventArgs _args)
        {

            txtMessage.Text += ":\">";
        }
        private void IconToCharacter8(object _sender, EventArgs _args)
        {

            txtMessage.Text += ":P";
        }
        private void IconToCharacter9(object _sender, EventArgs _args)
        {

            txtMessage.Text += ":-*";
        }
        private void IconToCharacter10(object _sender, EventArgs _args)
        {

            txtMessage.Text += "X(";
        }
        private void IconToCharacter11(object _sender, EventArgs _args)
        {

            txtMessage.Text += "~:>";
        }
        private void IconToCharacter12(object _sender, EventArgs _args)
        {

            txtMessage.Text += "b-)";
        }
        private void IconToCharacter13(object _sender, EventArgs _args)
        {

            txtMessage.Text += ":-S";
        }
        private void IconToCharacter14(object _sender, EventArgs _args)
        {

            txtMessage.Text += ":|";
        }
        private void IconToCharacter15(object _sender, EventArgs _args)
        {

            txtMessage.Text += "=))";
        }
        private void IconToCharacter16(object _sender, EventArgs _args)
        {

            txtMessage.Text += "O:-)";
        }
        private void IconToCharacter17(object _sender, EventArgs _args)
        {

            txtMessage.Text += ":-B";
        }
        private void IconToCharacter18(object _sender, EventArgs _args)
        {
            txtMessage.Text += "I-)";
        }
        private void IconToCharacter19(object _sender, EventArgs _args)
        {

            txtMessage.Text += ":-?";
        }
        private void IconToCharacter20(object _sender, EventArgs _args)
        {
            txtMessage.Text += "3:-O";
        }

        // Sự kiện khi người dùng bấm vào nút gửi file
        private void picSendFile_Click(object sender, EventArgs e)
        {
            // Nếu người dùng đang online thì mới có thể share file
            if (Global.server.IsVisible(contact))
            {
                Global.server.Send(Global.username, contact, "Requesting file sharing ...");
            }
            else
            {
                MessageBox.Show("Người này hiện không có Online để share file. Vui lòng thử lại vào lúc khác!", "Lỗi!");
            }
        }

        // Sự kiện khi người dùng bấm vào nút Share Photo.
        private void picSharePhoto_Click(object sender, EventArgs e)
        {
            // Nếu người dùng đang online thì mới có thể chia sẻ hình ảnh.
            if (Global.server.IsVisible(contact))
            {
                Global.server.Send(Global.username, contact, "Requesting photo sharing ...");
            }
            else
            {
                MessageBox.Show("Người này hiện không có Online để chia sẻ hình ảnh. Vui lòng thử lại vào lúc khác!", "Lỗi!");
            }
        }

        // Sự kiện khi người dùng bấm vào nút chơi caro
        private void pctbCaro_Click(object sender, EventArgs e)
        {
            // Nếu người dùng đang online thì mới có thể chơi caro
            if (Global.server.IsVisible(contact))
            {
                Global.server.Send(Global.username, contact, "Requesting caro playing ...");
            }
            else
            {
                MessageBox.Show("Người này hiện không có Online để chơi caro. Vui lòng thử lại vào lúc khác!", "Lỗi!");
            }
        }

        // Sự kiện khi người dùng bấm vào nút View Webcam.
        private void picWebcam_Click(object sender, EventArgs e)
        {
            // Nếu người dùng đang online thì mới có thể chia sẻ hình ảnh.
            if (Global.server.IsVisible(contact))
            {
                IPHostEntry IP = Dns.GetHostByName(Dns.GetHostName().ToString());
                string IP_rq = IP.AddressList[0].ToString();
                Global.server.Send(Global.username, contact, " cmd-Webcam: Đang yêu cầu chia sẻ chat Webcam - IP: " + IP_rq);
            }
            else
            {
                MessageBox.Show("Người này hiện không có Online để chat Webcam. Vui lòng thử lại vào lúc khác!", "Lỗi!");
            }
        }




        // Server, lắng nghe kết nối để nhận hình ảnh chia sẻ (sau khi đã ấn yes)
        public void ServerPhotoStart()
        {
            IPHostEntry IP = Dns.GetHostByName(Dns.GetHostName().ToString());
            IPServerPhoto = IP.AddressList[0].ToString();
            fm = new FormPhotoReceive();
            fm.Show();
            Global.server.Send(Global.username, contact, " cmd-SharePhoto: Accepted image sharing request (IP: " + IPServerPhoto + ")"); // Thông báo tới người gửi
        }

        // Server, lắng nghe kết nối để chơi caro (sau khi đã ấn yes)
        public void ServerCaroStart()
        {
            IPHostEntry IP = Dns.GetHostByName(Dns.GetHostName().ToString());
            IPCaro = IP.AddressList[0].ToString();
            FormCaro fmCaro = new FormCaro(Global.username, contact, IPCaro, true);
            fmCaro.Show();
            Global.server.Send(Global.username, contact, " cmd-Caro: Accepted caro playing request (IP: " + IPCaro + ")"); // Thông báo tới người gửi
        }

        // Server, lắng nghe kết nối để share file (sau khi đã ấn yes)
        public void ServerFileStart()
        {
            IPHostEntry IP = Dns.GetHostByName(Dns.GetHostName().ToString());
            IPFile = IP.AddressList[0].ToString();
            FormRecieveFile fmFile = new FormRecieveFile(IPFile);
            fmFile.Show();
            Global.server.Send(Global.username, contact, " cmd-File: Accepted file sharing request (IP: " + IPFile + ")"); // Thông báo tới người gửi
        }


        // Client kết nối tới Server để chia sẻ hình ảnh
        public void ClientPhotoStart()
        {
            FormPhotoSend ffs = new FormPhotoSend(this);
            ffs.Show();
        }

        // Client kết nối tới Server để chơi caro
        public void ClientCaroStart()
        {
            FormCaro fmCaroClient = new FormCaro(contact, Global.username, IPContact, false);
            fmCaroClient.Show();
        }

        // Client kết nối tới Server để share file
        public void ClientFileStart()
        {
            FormSendFile fmCaroClient = new FormSendFile(IPContact);
            fmCaroClient.Show();
        }

        // Lọc địa chỉ IP từ Message
        public string GetIPofContact(string message)
        {
            string pattern = @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b";
            Regex check = new Regex(pattern);
            Match m = check.Match(message);
            if (m.Success) return m.Value;
            return "Error";
        }


        // Kiểm tra người dùng có chấp nhận yêu cầu share photo hay không
        public string CheckSharePhoto(string message)
        {
            if (message.Length > 14 && message.Substring(1, 14) == "cmd-SharePhoto")
            {
                return GetIPofContact(message);
            }
            return "";
        }

        // Kiểm tra người dùng có chấp nhận yêu cầu chơi caro
        public string CheckCaro(string message)
        {
            if (message.Length > 8 && message.Substring(1, 8) == "cmd-Caro")
            {
                return GetIPofContact(message);
            }
            return "";
        }

        // Kiểm tra người dùng có chấp nhận yêu cầu share file
        public string CheckFile(string message)
        {
            if (message.Length > 8 && message.Substring(1, 8) == "cmd-File")
            {
                return GetIPofContact(message);
            }
            return "";
        }

        // Kiểm tra có phải là yêu cầu xem webcam hay không?
        public string CheckWebcamRequest(string message)
        {
            if (message.Length > 11 && message.Substring(1, 10) == "cmd-Webcam")
            { 
                string IP_rq = GetIPofContact(message);
                return IP_rq;
            }
            return "";
        }

        public void ReadUserSetting()
        {
            FileStream fs1 = new FileStream("UserSetting.dat", FileMode.Open);
            BinaryReader w1 = new BinaryReader(fs1);            
            setting[0] = w1.ReadString().ToString(); // Link tiếng buzz
            setting[1] = w1.ReadString().ToString(); // Link tiếng Online
            setting[2] = w1.ReadString().ToString(); // Link tiếng Offline
            setting[3] = w1.ReadString().ToString(); // Link tiếng Message
            setting[4] = w1.ReadString().ToString(); // Link thư mục lưu file
            setting[5] = w1.ReadString().ToString(); // Tùy chọn lưu logs chat
            w1.Close();
            fs1.Close();
        }
        
        // Hàm ghi logs chat
        private void WriteLogs(string s)
        {
            string path = "logs/" + Global.username + "/" + contact + "/"; // đường dẫn logs của người dùng đang đăng nhập            
            if (!Directory.Exists(path)) // Nếu người này chưa lưu log trước đó thì tạo thư mục mới
                Directory.CreateDirectory(path);
            path = path + TimetoFileName();
            if (!File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(s);
                sw.Flush();
                fs.Close();
            }
            else
            {
                FileStream fs = new FileStream(path, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(s);
                sw.Flush();
                fs.Close();
            }            
        }

        // Chuyển ngày hiện tại sang tên file
        private string TimetoFileName()
        {
            string s = DateTime.Today.ToShortDateString();

            if (s.IndexOf("/") == 1)
            {
                s = s.Remove(1, 1);
                s = s.Insert(0, "0");
                if (s.IndexOf("/") == 3)
                    s = s.Insert(2, "0");
                s = s.Remove(4, 1);
            }
            else
            {
                s = s.Remove(2, 1);
                if (s.IndexOf("/") == 3)
                    s = s.Insert(2, "0");
                s = s.Remove(4, 1);
            }
            s = s + ".dat";
            return s;
        }

        private void rbtn_opacity_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtn_opacity.Checked=true)
            {
                this.Opacity = .80;
            }
            else
                this.Opacity = .100;
        }


    }
}
