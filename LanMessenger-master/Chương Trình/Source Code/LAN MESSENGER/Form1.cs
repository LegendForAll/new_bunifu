using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LanMessengerLib;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Services;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.IO;
using System.Threading;
using System.Runtime.Remoting.Channels.Tcp;
using LanMessengerChatRoomBase;
using System.Net;

namespace Lan_Messenger
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	///
	public class Form1 : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MenuItem menuSendMessage;
		private System.Windows.Forms.MenuItem menuAddContact;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.Timer tmrMessageReceive;
		private System.Windows.Forms.Panel pnlContacts;
		private System.Windows.Forms.MenuItem menuChangeUser;
		private System.Windows.Forms.MenuItem menuSignOut;
		private System.Windows.Forms.MenuItem menuMin;
		private System.Windows.Forms.MenuItem menuExit;
		private System.Windows.Forms.Timer tmrContactUpdate;
		private System.Windows.Forms.MenuItem menuRemoveContact;
		private System.Windows.Forms.MenuItem menuNetworkSettings;
		private System.Windows.Forms.StatusBar statusBar;

		HttpChannel channel;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem conMenuSendMessage;
		private System.Windows.Forms.MenuItem conMenuAddContact;
		private System.Windows.Forms.ContextMenu conMenu;
		private System.Windows.Forms.ContextMenu conMenuContactsPanel;
		private System.Windows.Forms.MenuItem conMenuRefreshContactsPanel;
		private System.Windows.Forms.MenuItem conMenuRemoveContact;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem conMenuPanelRemoveContact;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.MenuItem menuChat;
		private System.Windows.Forms.MenuItem menuAbout;
		private System.Windows.Forms.ContextMenu notifyMenu;
        private System.Windows.Forms.MenuItem showLanMessenger;
		private System.Windows.Forms.MenuItem notMenuSend;
		private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem notMenuSignOut;
		private System.Windows.Forms.MenuItem notMenuSignIn;
		private System.Windows.Forms.MenuItem notMenuMin;
		private System.Windows.Forms.MenuItem notMenuExit;
		private System.Windows.Forms.MenuItem notMenuAbout;
		private System.Windows.Forms.MenuItem conMenuPanelAddContact;
        private Label lblWelcome;
        string hostIP;
        private TextBox txtSearchName;
        private ToolTip toolTip1;
        private PictureBox picSearch;
        private RadioButton rbtnOnline;
        private RadioButton rbtnInvisible;
        private ToolTip toolTip2;
        private MenuItem menuLogMessage;
        private MenuItem menuItem1;
        private MenuItem menuChangeDisplayName;
        private MenuItem menuOpenChatRoom;
        private MenuItem menuJoinRoom;
        private Panel panel2;
        private Panel panel1;
        private PictureBox pictureBox6;
        private Label label1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private PictureBox pictureBox1;
        private Panel panel3;
        private Button btn_login;
        private Button btn_Logchat;
        private Button btn_addFriend;
        private Button btn_link;
        private Button btn_setting;
        private Button btn_mess;
        private Button btn_changePass;
        private Button btn_group;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        private string[] setting = new string[6]; // Có 6 Options tất cả
		public Form1()
		{
            Application.EnableVisualStyles();
			InitializeComponent();            
			//
			// Các Constructor tại đây
			//

            // Đọc Usersetting.dat nếu tồn tại (ở đây người dùng phải SignOut thì mới cập nhật Sounds được)
            if (File.Exists("UserSetting.dat"))
                ReadUserSetting();
            else
                setting[5] = "1";

            // Thiết lập mạng
			channel = new HttpChannel();
			ChannelServices.RegisterChannel(channel);			
			
			statusBar.Text="Đang tải thiết lập mạng...";
			if(File.Exists("NetSetting.Dat"))
			{
				FileStream fs = new FileStream("NetSetting.Dat",FileMode.Open);
				BinaryReader br = new BinaryReader(fs);
				hostIP=br.ReadString();
				fs.Close();
				br.Close();
			}
			else
			{
				hostIP="127.0.0.1";
			}
			statusBar.Text="Đã tải thiết lập mạng.";

            Thread thietLapMang = new Thread(() =>
            {
                try
                {
                    MarshalByRefObject obj = (MarshalByRefObject)RemotingServices.Connect(typeof(IServer), "http://" + hostIP + ":9090/Server");
                    Global.server = obj as IServer;
                    (obj as RemotingClientProxy).Timeout = 5000;
                }
                catch
                {
                    return;
                }
            });			
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{	
			this.Show();
			Connect();
        }
        // Khi Double lên 1 Contact thì mở cửa sổ chat với tên của người này.
		private void Contact_Click(object sender, System.EventArgs e)
		{
			OpenFormMessage(((LanMessengerControls.LanMessengerContact)sender).Contact);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuChat = new System.Windows.Forms.MenuItem();
            this.menuSendMessage = new System.Windows.Forms.MenuItem();
            this.menuAddContact = new System.Windows.Forms.MenuItem();
            this.menuRemoveContact = new System.Windows.Forms.MenuItem();
            this.menuLogMessage = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuChangeUser = new System.Windows.Forms.MenuItem();
            this.menuSignOut = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuMin = new System.Windows.Forms.MenuItem();
            this.menuExit = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuNetworkSettings = new System.Windows.Forms.MenuItem();
            this.menuChangeDisplayName = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuOpenChatRoom = new System.Windows.Forms.MenuItem();
            this.menuJoinRoom = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.menuAbout = new System.Windows.Forms.MenuItem();
            this.tmrMessageReceive = new System.Windows.Forms.Timer(this.components);
            this.pnlContacts = new System.Windows.Forms.Panel();
            this.tmrContactUpdate = new System.Windows.Forms.Timer(this.components);
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.conMenu = new System.Windows.Forms.ContextMenu();
            this.conMenuSendMessage = new System.Windows.Forms.MenuItem();
            this.conMenuRemoveContact = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.conMenuAddContact = new System.Windows.Forms.MenuItem();
            this.conMenuContactsPanel = new System.Windows.Forms.ContextMenu();
            this.conMenuPanelAddContact = new System.Windows.Forms.MenuItem();
            this.conMenuPanelRemoveContact = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.conMenuRefreshContactsPanel = new System.Windows.Forms.MenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyMenu = new System.Windows.Forms.ContextMenu();
            this.showLanMessenger = new System.Windows.Forms.MenuItem();
            this.notMenuSend = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.notMenuSignIn = new System.Windows.Forms.MenuItem();
            this.notMenuSignOut = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.notMenuAbout = new System.Windows.Forms.MenuItem();
            this.notMenuMin = new System.Windows.Forms.MenuItem();
            this.notMenuExit = new System.Windows.Forms.MenuItem();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.picSearch = new System.Windows.Forms.PictureBox();
            this.rbtnOnline = new System.Windows.Forms.RadioButton();
            this.rbtnInvisible = new System.Windows.Forms.RadioButton();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_group = new System.Windows.Forms.Button();
            this.btn_changePass = new System.Windows.Forms.Button();
            this.btn_mess = new System.Windows.Forms.Button();
            this.btn_link = new System.Windows.Forms.Button();
            this.btn_setting = new System.Windows.Forms.Button();
            this.btn_login = new System.Windows.Forms.Button();
            this.btn_Logchat = new System.Windows.Forms.Button();
            this.btn_addFriend = new System.Windows.Forms.Button();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuChat,
            this.menuItem10,
            this.menuItem13});
            // 
            // menuChat
            // 
            this.menuChat.Index = 0;
            this.menuChat.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuSendMessage,
            this.menuAddContact,
            this.menuRemoveContact,
            this.menuLogMessage,
            this.menuItem4,
            this.menuChangeUser,
            this.menuSignOut,
            this.menuItem7,
            this.menuMin,
            this.menuExit});
            this.menuChat.Text = "Messenger";
            // 
            // menuSendMessage
            // 
            this.menuSendMessage.Enabled = false;
            this.menuSendMessage.Index = 0;
            this.menuSendMessage.Shortcut = System.Windows.Forms.Shortcut.CtrlG;
            this.menuSendMessage.Text = "Send Message";
            this.menuSendMessage.Click += new System.EventHandler(this.menuSendMessage_Click);
            // 
            // menuAddContact
            // 
            this.menuAddContact.Enabled = false;
            this.menuAddContact.Index = 1;
            this.menuAddContact.Shortcut = System.Windows.Forms.Shortcut.CtrlT;
            this.menuAddContact.Text = "Add friends";
            this.menuAddContact.Click += new System.EventHandler(this.menuAddContact_Click);
            // 
            // menuRemoveContact
            // 
            this.menuRemoveContact.Enabled = false;
            this.menuRemoveContact.Index = 2;
            this.menuRemoveContact.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftX;
            this.menuRemoveContact.Text = "Delete friends";
            this.menuRemoveContact.Click += new System.EventHandler(this.menuRemoveContact_Click);
            // 
            // menuLogMessage
            // 
            this.menuLogMessage.Enabled = false;
            this.menuLogMessage.Index = 3;
            this.menuLogMessage.Shortcut = System.Windows.Forms.Shortcut.CtrlL;
            this.menuLogMessage.Text = "Chat history";
            this.menuLogMessage.Click += new System.EventHandler(this.menuLogMessage_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 4;
            this.menuItem4.Text = "-";
            // 
            // menuChangeUser
            // 
            this.menuChangeUser.Index = 5;
            this.menuChangeUser.Text = "Log in";
            this.menuChangeUser.Click += new System.EventHandler(this.menuChangeUser_Click);
            // 
            // menuSignOut
            // 
            this.menuSignOut.Enabled = false;
            this.menuSignOut.Index = 6;
            this.menuSignOut.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
            this.menuSignOut.Text = "Log out";
            this.menuSignOut.Click += new System.EventHandler(this.menuSignOut_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 7;
            this.menuItem7.Text = "-";
            // 
            // menuMin
            // 
            this.menuMin.Index = 8;
            this.menuMin.Shortcut = System.Windows.Forms.Shortcut.CtrlM;
            this.menuMin.Text = "Minimize to system tray";
            this.menuMin.Click += new System.EventHandler(this.menuMin_Click);
            // 
            // menuExit
            // 
            this.menuExit.Index = 9;
            this.menuExit.Shortcut = System.Windows.Forms.Shortcut.AltF4;
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 1;
            this.menuItem10.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem11,
            this.menuNetworkSettings,
            this.menuChangeDisplayName,
            this.menuItem1,
            this.menuOpenChatRoom,
            this.menuJoinRoom});
            this.menuItem10.Text = "Extend";
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 0;
            this.menuItem11.Text = "Options";
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // menuNetworkSettings
            // 
            this.menuNetworkSettings.Index = 1;
            this.menuNetworkSettings.Text = "Network setup";
            this.menuNetworkSettings.Click += new System.EventHandler(this.menuNetworkSettings_Click);
            // 
            // menuChangeDisplayName
            // 
            this.menuChangeDisplayName.Enabled = false;
            this.menuChangeDisplayName.Index = 2;
            this.menuChangeDisplayName.Text = "Rename show with friends";
            this.menuChangeDisplayName.Click += new System.EventHandler(this.menuChangeDisplayName_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 3;
            this.menuItem1.Text = "-";
            // 
            // menuOpenChatRoom
            // 
            this.menuOpenChatRoom.Enabled = false;
            this.menuOpenChatRoom.Index = 4;
            this.menuOpenChatRoom.Text = "Open a chat room";
            this.menuOpenChatRoom.Click += new System.EventHandler(this.menuOpenChatRoom_Click);
            // 
            // menuJoinRoom
            // 
            this.menuJoinRoom.Enabled = false;
            this.menuJoinRoom.Index = 5;
            this.menuJoinRoom.Text = "Join a chat room";
            this.menuJoinRoom.Click += new System.EventHandler(this.menuJoinRoom_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 2;
            this.menuItem13.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuAbout});
            this.menuItem13.Text = "About";
            // 
            // menuAbout
            // 
            this.menuAbout.Index = 0;
            this.menuAbout.Text = "Information";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // tmrMessageReceive
            // 
            this.tmrMessageReceive.Interval = 1000;
            this.tmrMessageReceive.Tick += new System.EventHandler(this.tmrMessageReceive_Tick);
            // 
            // pnlContacts
            // 
            this.pnlContacts.AutoScroll = true;
            this.pnlContacts.BackColor = System.Drawing.Color.Transparent;
            this.pnlContacts.Location = new System.Drawing.Point(12, 39);
            this.pnlContacts.Name = "pnlContacts";
            this.pnlContacts.Size = new System.Drawing.Size(205, 315);
            this.pnlContacts.TabIndex = 0;
            this.pnlContacts.Resize += new System.EventHandler(this.pnlContacts_Resize);
            // 
            // tmrContactUpdate
            // 
            this.tmrContactUpdate.Interval = 3000;
            this.tmrContactUpdate.Tick += new System.EventHandler(this.tmrContactUpdate_Tick);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 410);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(542, 22);
            this.statusBar.TabIndex = 1;
            // 
            // conMenu
            // 
            this.conMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.conMenuSendMessage,
            this.conMenuRemoveContact,
            this.menuItem5,
            this.conMenuAddContact});
            // 
            // conMenuSendMessage
            // 
            this.conMenuSendMessage.Index = 0;
            this.conMenuSendMessage.Text = "Send a message to this user";
            this.conMenuSendMessage.Click += new System.EventHandler(this.conMenuSendMessage_Click);
            // 
            // conMenuRemoveContact
            // 
            this.conMenuRemoveContact.Index = 1;
            this.conMenuRemoveContact.Text = "Delete this friend";
            this.conMenuRemoveContact.Click += new System.EventHandler(this.conMenuRemoveContact_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 2;
            this.menuItem5.Text = "-";
            // 
            // conMenuAddContact
            // 
            this.conMenuAddContact.Index = 3;
            this.conMenuAddContact.Text = "Add friends";
            this.conMenuAddContact.Click += new System.EventHandler(this.menuAddContact_Click);
            // 
            // conMenuContactsPanel
            // 
            this.conMenuContactsPanel.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.conMenuPanelAddContact,
            this.conMenuPanelRemoveContact,
            this.menuItem6,
            this.conMenuRefreshContactsPanel});
            // 
            // conMenuPanelAddContact
            // 
            this.conMenuPanelAddContact.Index = 0;
            this.conMenuPanelAddContact.Text = "Add friends";
            this.conMenuPanelAddContact.Click += new System.EventHandler(this.menuAddContact_Click);
            // 
            // conMenuPanelRemoveContact
            // 
            this.conMenuPanelRemoveContact.Index = 1;
            this.conMenuPanelRemoveContact.Text = "Delete friends";
            this.conMenuPanelRemoveContact.Click += new System.EventHandler(this.menuRemoveContact_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 2;
            this.menuItem6.Text = "-";
            // 
            // conMenuRefreshContactsPanel
            // 
            this.conMenuRefreshContactsPanel.Index = 3;
            this.conMenuRefreshContactsPanel.Text = "Refresh list";
            this.conMenuRefreshContactsPanel.Click += new System.EventHandler(this.conMenuRefreshContactsPanel_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenu = this.notifyMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Messenger";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // notifyMenu
            // 
            this.notifyMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.showLanMessenger,
            this.notMenuSend,
            this.menuItem8,
            this.menuItem9,
            this.notMenuSignIn,
            this.notMenuSignOut,
            this.menuItem15,
            this.notMenuAbout,
            this.notMenuMin,
            this.notMenuExit});
            // 
            // showLanMessenger
            // 
            this.showLanMessenger.Index = 0;
            this.showLanMessenger.Text = "Show Messenger";
            this.showLanMessenger.Click += new System.EventHandler(this.showLanMessenger_Click);
            // 
            // notMenuSend
            // 
            this.notMenuSend.Enabled = false;
            this.notMenuSend.Index = 1;
            this.notMenuSend.Text = "Send a private message to ...";
            this.notMenuSend.Click += new System.EventHandler(this.menuSendMessage_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 2;
            this.menuItem8.Text = "-";
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 3;
            this.menuItem9.Text = "-";
            // 
            // notMenuSignIn
            // 
            this.notMenuSignIn.Index = 4;
            this.notMenuSignIn.Text = "Đăng nhập";
            this.notMenuSignIn.Click += new System.EventHandler(this.menuChangeUser_Click);
            // 
            // notMenuSignOut
            // 
            this.notMenuSignOut.Enabled = false;
            this.notMenuSignOut.Index = 5;
            this.notMenuSignOut.Text = "Đăng xuất";
            this.notMenuSignOut.Click += new System.EventHandler(this.menuSignOut_Click);
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 6;
            this.menuItem15.Text = "-";
            // 
            // notMenuAbout
            // 
            this.notMenuAbout.Index = 7;
            this.notMenuAbout.Text = "Thông tin";
            this.notMenuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // notMenuMin
            // 
            this.notMenuMin.Index = 8;
            this.notMenuMin.Text = "Thu nhỏ xuống khay hệ thống";
            this.notMenuMin.Click += new System.EventHandler(this.menuMin_Click);
            // 
            // notMenuExit
            // 
            this.notMenuExit.Index = 9;
            this.notMenuExit.Text = "Thoát";
            this.notMenuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblWelcome.Location = new System.Drawing.Point(79, 13);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(37, 13);
            this.lblWelcome.TabIndex = 2;
            this.lblWelcome.Text = "Status";
            // 
            // txtSearchName
            // 
            this.txtSearchName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSearchName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearchName.Enabled = false;
            this.txtSearchName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchName.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtSearchName.Location = new System.Drawing.Point(43, 10);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(154, 20);
            this.txtSearchName.TabIndex = 3;
            this.txtSearchName.Text = "Search...";
            this.toolTip1.SetToolTip(this.txtSearchName, "Tìm kiếm bạn bè bằng có gợi ý bằng cách nhập tên vào đây rồi nhấn Enter.");
            this.txtSearchName.Click += new System.EventHandler(this.SearchKeyClick);
            this.txtSearchName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchKeyPress);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Search Bar...";
            // 
            // picSearch
            // 
            this.picSearch.Image = ((System.Drawing.Image)(resources.GetObject("picSearch.Image")));
            this.picSearch.Location = new System.Drawing.Point(12, 5);
            this.picSearch.Name = "picSearch";
            this.picSearch.Size = new System.Drawing.Size(25, 25);
            this.picSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSearch.TabIndex = 4;
            this.picSearch.TabStop = false;
            this.picSearch.Click += new System.EventHandler(this.picSearch_Click);
            // 
            // rbtnOnline
            // 
            this.rbtnOnline.AutoSize = true;
            this.rbtnOnline.Enabled = false;
            this.rbtnOnline.ForeColor = System.Drawing.Color.DarkGray;
            this.rbtnOnline.Location = new System.Drawing.Point(82, 29);
            this.rbtnOnline.Name = "rbtnOnline";
            this.rbtnOnline.Size = new System.Drawing.Size(55, 17);
            this.rbtnOnline.TabIndex = 5;
            this.rbtnOnline.TabStop = true;
            this.rbtnOnline.Text = "Online";
            this.toolTip2.SetToolTip(this.rbtnOnline, "Hiện nick với mọi người.");
            this.rbtnOnline.UseVisualStyleBackColor = true;
            this.rbtnOnline.CheckedChanged += new System.EventHandler(this.rbtnOnline_CheckedChanged);
            // 
            // rbtnInvisible
            // 
            this.rbtnInvisible.AutoSize = true;
            this.rbtnInvisible.Enabled = false;
            this.rbtnInvisible.ForeColor = System.Drawing.Color.DarkGray;
            this.rbtnInvisible.Location = new System.Drawing.Point(150, 29);
            this.rbtnInvisible.Name = "rbtnInvisible";
            this.rbtnInvisible.Size = new System.Drawing.Size(63, 17);
            this.rbtnInvisible.TabIndex = 6;
            this.rbtnInvisible.TabStop = true;
            this.rbtnInvisible.Text = "Invisible";
            this.toolTip2.SetToolTip(this.rbtnInvisible, "Ẩn nick với mọi người.");
            this.rbtnInvisible.UseVisualStyleBackColor = true;
            this.rbtnInvisible.CheckedChanged += new System.EventHandler(this.rbtnInvisible_CheckedChanged);
            // 
            // toolTip2
            // 
            this.toolTip2.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip2.ToolTipTitle = "Trạng thái...";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.picSearch);
            this.panel2.Controls.Add(this.txtSearchName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 374);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(231, 36);
            this.panel2.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btn_group);
            this.panel1.Controls.Add(this.btn_changePass);
            this.panel1.Controls.Add(this.btn_mess);
            this.panel1.Controls.Add(this.btn_link);
            this.panel1.Controls.Add(this.btn_setting);
            this.panel1.Controls.Add(this.btn_login);
            this.panel1.Controls.Add(this.btn_Logchat);
            this.panel1.Controls.Add(this.btn_addFriend);
            this.panel1.Controls.Add(this.rbtnInvisible);
            this.panel1.Controls.Add(this.rbtnOnline);
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.bunifuSeparator1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(237, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 410);
            this.panel1.TabIndex = 8;
            // 
            // btn_group
            // 
            this.btn_group.BackColor = System.Drawing.Color.Tomato;
            this.btn_group.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_group.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_group.ForeColor = System.Drawing.Color.Silver;
            this.btn_group.Image = ((System.Drawing.Image)(resources.GetObject("btn_group.Image")));
            this.btn_group.Location = new System.Drawing.Point(200, 95);
            this.btn_group.Name = "btn_group";
            this.btn_group.Size = new System.Drawing.Size(70, 66);
            this.btn_group.TabIndex = 45;
            this.btn_group.UseVisualStyleBackColor = false;
            this.btn_group.Click += new System.EventHandler(this.btn_group_Click);
            // 
            // btn_changePass
            // 
            this.btn_changePass.BackColor = System.Drawing.Color.DarkGray;
            this.btn_changePass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_changePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_changePass.ForeColor = System.Drawing.Color.Silver;
            this.btn_changePass.Image = ((System.Drawing.Image)(resources.GetObject("btn_changePass.Image")));
            this.btn_changePass.Location = new System.Drawing.Point(29, 259);
            this.btn_changePass.Name = "btn_changePass";
            this.btn_changePass.Size = new System.Drawing.Size(70, 66);
            this.btn_changePass.TabIndex = 44;
            this.btn_changePass.UseVisualStyleBackColor = false;
            this.btn_changePass.Click += new System.EventHandler(this.btn_changePass_Click);
            // 
            // btn_mess
            // 
            this.btn_mess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btn_mess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_mess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mess.ForeColor = System.Drawing.Color.Silver;
            this.btn_mess.Image = ((System.Drawing.Image)(resources.GetObject("btn_mess.Image")));
            this.btn_mess.Location = new System.Drawing.Point(114, 95);
            this.btn_mess.Name = "btn_mess";
            this.btn_mess.Size = new System.Drawing.Size(70, 66);
            this.btn_mess.TabIndex = 43;
            this.btn_mess.UseVisualStyleBackColor = false;
            this.btn_mess.Click += new System.EventHandler(this.btn_mess_Click);
            // 
            // btn_link
            // 
            this.btn_link.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(166)))), ((int)(((byte)(90)))));
            this.btn_link.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_link.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_link.ForeColor = System.Drawing.Color.Silver;
            this.btn_link.Image = ((System.Drawing.Image)(resources.GetObject("btn_link.Image")));
            this.btn_link.Location = new System.Drawing.Point(114, 177);
            this.btn_link.Name = "btn_link";
            this.btn_link.Size = new System.Drawing.Size(70, 66);
            this.btn_link.TabIndex = 42;
            this.btn_link.UseVisualStyleBackColor = false;
            this.btn_link.Click += new System.EventHandler(this.btn_link_Click);
            // 
            // btn_setting
            // 
            this.btn_setting.BackColor = System.Drawing.Color.Turquoise;
            this.btn_setting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_setting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_setting.ForeColor = System.Drawing.Color.Silver;
            this.btn_setting.Image = ((System.Drawing.Image)(resources.GetObject("btn_setting.Image")));
            this.btn_setting.Location = new System.Drawing.Point(29, 177);
            this.btn_setting.Name = "btn_setting";
            this.btn_setting.Size = new System.Drawing.Size(70, 66);
            this.btn_setting.TabIndex = 41;
            this.btn_setting.UseVisualStyleBackColor = false;
            this.btn_setting.Click += new System.EventHandler(this.btn_setting_Click);
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_login.ForeColor = System.Drawing.Color.Silver;
            this.btn_login.Image = ((System.Drawing.Image)(resources.GetObject("btn_login.Image")));
            this.btn_login.Location = new System.Drawing.Point(200, 177);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(70, 66);
            this.btn_login.TabIndex = 40;
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_Logchat
            // 
            this.btn_Logchat.BackColor = System.Drawing.Color.DarkOrchid;
            this.btn_Logchat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Logchat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Logchat.ForeColor = System.Drawing.Color.Silver;
            this.btn_Logchat.Image = ((System.Drawing.Image)(resources.GetObject("btn_Logchat.Image")));
            this.btn_Logchat.Location = new System.Drawing.Point(114, 259);
            this.btn_Logchat.Name = "btn_Logchat";
            this.btn_Logchat.Size = new System.Drawing.Size(70, 66);
            this.btn_Logchat.TabIndex = 39;
            this.btn_Logchat.UseVisualStyleBackColor = false;
            this.btn_Logchat.Click += new System.EventHandler(this.btn_Logchat_Click);
            // 
            // btn_addFriend
            // 
            this.btn_addFriend.BackColor = System.Drawing.Color.Gray;
            this.btn_addFriend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_addFriend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addFriend.ForeColor = System.Drawing.Color.Silver;
            this.btn_addFriend.Image = ((System.Drawing.Image)(resources.GetObject("btn_addFriend.Image")));
            this.btn_addFriend.Location = new System.Drawing.Point(29, 95);
            this.btn_addFriend.Name = "btn_addFriend";
            this.btn_addFriend.Size = new System.Drawing.Size(70, 66);
            this.btn_addFriend.TabIndex = 38;
            this.btn_addFriend.UseVisualStyleBackColor = false;
            this.btn_addFriend.Click += new System.EventHandler(this.btn_addFriend_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(10, 64);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(18, 17);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 27;
            this.pictureBox6.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(34, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Options";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.bunifuSeparator1.LineThickness = 2;
            this.bunifuSeparator1.Location = new System.Drawing.Point(13, 51);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(275, 10);
            this.bunifuSeparator1.TabIndex = 25;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(23, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(223)))), ((int)(((byte)(226)))));
            this.panel3.Controls.Add(this.bunifuSeparator2);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.pnlContacts);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(231, 410);
            this.panel3.TabIndex = 9;
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bunifuSeparator2.LineThickness = 2;
            this.bunifuSeparator2.Location = new System.Drawing.Point(7, 363);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(219, 10);
            this.bunifuSeparator2.TabIndex = 26;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = false;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(542, 432);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusBar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(232, 314);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " MESSENGER";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion


		[STAThread]
		static void Main() 
		{			
			using(Form1 frm1 = new Form1())
			{
				Application.Run(frm1);
			}
		}

		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			notifyIcon.Dispose();
			ChannelServices.UnregisterChannel(channel);
			try
			{
                if (setting[5] == "2")
                    DeleteAllLogs();
				Global.server.SignOut(Global.username);                
			}
			finally
			{
				Application.Exit();
			}
		}

		private void menuSendMessage_Click(object sender, System.EventArgs e)
		{
			using(FormSelectContact frmContact = new FormSelectContact())
			{
				if(frmContact.ShowDialog(this)==DialogResult.OK)
				{
					if(frmContact.txtContact.Text==Global.username)
					{
						MessageBox.Show("Bạn không thể gửi tin nhắn tới chính bạn được!");
						return;
					}
					if(Global.windowList.Contains(frmContact.txtContact.Text))
					{
						((FormMessage)Global.windowList[frmContact.txtContact.Text]).Focus();
					}
					else
					{
						FormMessage frmMessage = new FormMessage();
						frmMessage.contact=frmContact.txtContact.Text;
						frmMessage.Text=frmContact.txtContact.Text+" - Tin nhắn trực tiếp.";
						Global.windowList.Add(frmContact.txtContact.Text,frmMessage);				
						frmMessage.Show();
					}
				}
			}
		}
		private void tmrMessageReceive_Tick(object sender, System.EventArgs e)
		{
			LetterReceive letter;
			try
			{
				letter = Global.server.Receive(Global.username);
			}
			catch
			{
				AbortConnection();
				return;
			}
			if(letter.From=="")
			{
				return;
			}
			if(Global.windowList.Contains(letter.From))
			{	
				if(letter.Message=="BUZZ IT")
				{
					((FormMessage)Global.windowList[letter.From]).Focus();			
				}
				((FormMessage)Global.windowList[letter.From]).AddText(letter.From,letter.Message);

			}
			else
			{
				FormMessage frmMessage = new FormMessage();
				frmMessage.contact=letter.From;
				frmMessage.Text=letter.From+" - Tin nhắn trực tiếp.";
				frmMessage.AddText(letter.From,letter.Message);
				Global.windowList.Add(letter.From,frmMessage);
				frmMessage.Show();
			}
		}

		private void menuAddContact_Click(object sender, System.EventArgs e)
		{
			FormAddContact frmAddContact = new FormAddContact();
			if(frmAddContact.ShowDialog()==DialogResult.OK)
			{
				UpdatePanelContact();
			}
		}


        private void menuLogMessage_Click(object sender, EventArgs e)
        {
            FormLogsReader f = new FormLogsReader();
            f.Show();
        }

		private void menuSignOut_Click(object sender, System.EventArgs e)
		{
            Global.server.SignOut(Global.username);
            if (setting[5] == "2")
                DeleteAllLogs();
            pnlContacts.Controls.Clear();            
            Global.contactList.Clear();
            Global.username = "";
            this.txtSearchName.Enabled = false;
            rbtnOnline.Enabled = false;
            rbtnInvisible.Enabled = false;
            this.txtSearchName.Clear();
            this.menuAddContact.Enabled = false;
            this.menuSendMessage.Enabled = false;
            this.menuRemoveContact.Enabled = false;
            this.menuLogMessage.Enabled = false;
            this.menuChangeDisplayName.Enabled = false;
            this.menuOpenChatRoom.Enabled = false;
            this.menuJoinRoom.Enabled = false;
            this.menuChangeUser.Text = "Log in";
            this.menuSignOut.Enabled = false;
            this.pnlContacts.ContextMenu = null;
            this.notMenuSend.Enabled = false;
            this.notMenuSignIn.Text = "Log in";
            this.notMenuSignOut.Enabled = false;
            tmrMessageReceive.Enabled = false;
            tmrContactUpdate.Enabled = false;
            //shortcut
            btn_addFriend.Enabled = false;
            btn_changePass.Enabled = false;
            btn_group.Enabled = false;
            btn_mess.Enabled = false;
            btn_Logchat.Enabled = false;

            SignIn();
		}

        // Tham gia một room đã có sẵn
        private void menuJoinRoom_Click(object sender, EventArgs e)
        {
            FormJoinRoom fjr = new FormJoinRoom();
            fjr.Show();
        }

        // Delegate để UnregisterChannel khi FormChatRoom đóng
        bool ChatRoomClosed = false;
        public void GetValue(Boolean b)
        {
            ChatRoomClosed = b;
            if (ChatRoomClosed)
                ChannelServices.UnregisterChannel(channelChatRoom);
        }

        TcpChannel channelChatRoom;
        // Mở một chat room mới.
        public void menuOpenChatRoom_Click(object sender, EventArgs e)
        {
            // Khởi tạo kênh liên lạc với remote Object.
            channelChatRoom = new TcpChannel(7070);
            ChannelServices.RegisterChannel(channelChatRoom, false);

            // Ở đây sẻ sử dụng Singleton để duy trì trạng thái với nhiều kết nối Client 
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(SampleObject), Global.username.ToString(), WellKnownObjectMode.Singleton); // Cho Server chat room
            
            // Mở Room
            if (OpenRoom() == 0)
            {
                ChannelServices.UnregisterChannel(channelChatRoom);
                channelChatRoom = null;
            }
        }

        TcpChannel chan;
        private int OpenRoom()
        {
            ArrayList alOnlineUser = new ArrayList();
            FormChatRoom objChatWin;

            if (true) // lãng xẹt, nhát sửa =))
            {
                chan = new TcpChannel();
                //ChannelServices.RegisterChannel(chan, false);
                chan = null;
                IPHostEntry temp = Dns.GetHostByName(Dns.GetHostName().ToString());
                string IP = temp.AddressList[0].ToString();
                objChatWin = new FormChatRoom();
                objChatWin.MyGetData = new FormChatRoom.GetString(GetValue);
                objChatWin.remoteObj = (SampleObject)Activator.GetObject(typeof(LanMessengerChatRoomBase.SampleObject), "tcp://"+IP+":7070/" + Global.username);

                if (!objChatWin.remoteObj.JoinToChatRoom(Global.username))
                {
                    MessageBox.Show(Global.username + " đã đăng nhập rồi!. Có thể mạng bị lag, hãy thử lại sau!");
                    ChannelServices.UnregisterChannel(chan);
                    chan = null;
                    objChatWin.Dispose();
                    return 1; // 1: da dang nhap roi
                }
                objChatWin.key = objChatWin.remoteObj.CurrentKeyNo();
                objChatWin.yourName = Global.username;
                objChatWin.Show();
                return 2; // 2 : Dang nhap cong
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra khi tạo Room Chat, vui lòng thử lại!");
                chan = null;
                return 0; // 0: Loi
            }
        }

        // Thay đổi tên hiển thị với bạn bè
        private void menuChangeDisplayName_Click(object sender, EventArgs e)
        {
            FormChangeDisplayName fcdn = new FormChangeDisplayName();
            fcdn.Show();
        }

        // Thông báo tên 1 Contact Online
        private void GoOnline(string ContactName)
        {
            TrayBalloon.TrayBalloon tb = new TrayBalloon.TrayBalloon();
            tb.BackgroundLocation = "background.bmp";
            if (File.Exists(setting[1]))
                tb.SoundLocation = setting[1];
            else
                tb.SoundLocation = "sounds/Online.wav";
            tb.Title = "Lan Messenger!";
            tb.Message = Global.server.GetfullName(ContactName) + "  Online!";
            tb.Run();
        }

        // Thông báo tên 1 Contact Offline
        private void GoOffline(string ContactName)
        {
            TrayBalloon.TrayBalloon tb = new TrayBalloon.TrayBalloon();
            tb.BackgroundLocation = "background.bmp";
            if (File.Exists(setting[2]))
                tb.SoundLocation = setting[2];
            else
                tb.SoundLocation = "sounds/Offline.wav";
            tb.Title = "Lan Messenger!";
            tb.Message = Global.server.GetfullName(ContactName) + "  Offline!";
            tb.Run();
        }

        bool Check = false; // Biến cờ kiểm tra đã Check trạng thái của 1 người dùng hay chưa?
        private void tmrContactUpdate_Tick(object sender, System.EventArgs e)
		{
            try
			{
				foreach(object o in Global.contactList)
				{
                    // Thay đổi biến cờ khi bạn bè thay đổi trạng thái.
                    if (((LanMessengerControls.LanMessengerContact)o).Online != Global.server.IsVisible((o as LanMessengerControls.LanMessengerContact).Contact))  Check = !Check;
                    // Cập nhật lại trạng thái trong Contact List
					((LanMessengerControls.LanMessengerContact)o).Online=Global.server.IsVisible((o as LanMessengerControls.LanMessengerContact).Contact);
                    // Thông báo trạng thái của bạn bè!
                    if (Check)
                    {
                        if (Global.server.IsVisible((o as LanMessengerControls.LanMessengerContact).Contact))
                            GoOnline((o as LanMessengerControls.LanMessengerContact).Contact.ToString());
                        else GoOffline((o as LanMessengerControls.LanMessengerContact).Contact.ToString());
                        Check = !Check;
                    }                    
                }
				pnlContacts.Update();                
			}
			catch
			{
                AbortConnection();
				return;
			}
		}

		private void menuRemoveContact_Click(object sender, System.EventArgs e)
		{
			FormSelectContact frmSelectContact = new FormSelectContact();
            if (frmSelectContact.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Global.server.RemoveContact(Global.username, frmSelectContact.txtContact.Text);
                    UpdatePanelContact();
                }
                catch
                {
                    AbortConnection();
                    return;
                }
            }
		}

		private void Form1_Resize(object sender, System.EventArgs e)
		{
			pnlContacts.Width=this.Width-24;
			pnlContacts.Height=this.Height-88;
		}

		private void pnlContacts_Resize(object sender, System.EventArgs e)
		{
			foreach(object o in Global.contactList)
			{
				((LanMessengerControls.LanMessengerContact)o).Width=pnlContacts.Width-32;
			}
		}

		private void menuChangeUser_Click(object sender, System.EventArgs e)
		{
            try
            {
                Global.server.SignOut(Global.username);
                if (setting[5] == "2")
                    DeleteAllLogs();
                pnlContacts.Controls.Clear();
                Global.contactList.Clear();
                this.txtSearchName.Enabled = false;
                rbtnOnline.Enabled = false;
                rbtnInvisible.Enabled = false;
                this.txtSearchName.Clear();
                this.menuAddContact.Enabled = false;
                this.menuSendMessage.Enabled = false;
                this.menuRemoveContact.Enabled = false;
                this.menuLogMessage.Enabled = false;
                this.menuChangeDisplayName.Enabled = false;
                this.menuOpenChatRoom.Enabled = false;
                this.menuJoinRoom.Enabled = false;
                this.menuChangeUser.Text = "Log in";
                this.menuSignOut.Enabled = false;
                this.pnlContacts.ContextMenu = null;
                this.notMenuSend.Enabled = false;
                this.notMenuSignIn.Text = "Log in";
                this.notMenuSignOut.Enabled = false;
                tmrMessageReceive.Enabled = false;
                tmrContactUpdate.Enabled = false;

                //shortcut
                btn_addFriend.Enabled = false;
                btn_changePass.Enabled = false;
                btn_group.Enabled = false;
                btn_mess.Enabled = false;
                btn_Logchat.Enabled = false;
            }
            finally
            {
                SignIn();
            }		
		}

		private void menuExit_Click(object sender, System.EventArgs e)
		{
			try
			{
                if (setting[5] == "2")
                    DeleteAllLogs();
                Global.server.SignOut(Global.username); // Người dùng bấm Exit thì cũng sẻ SignOut nick lun.
			}
			finally
			{
				Application.Exit();
			}			
		}
		
		private void menuNetworkSettings_Click(object sender, System.EventArgs e)
		{
			FormNetworkSettings frmNetworkSettings = new FormNetworkSettings();
            frmNetworkSettings.StartPosition = FormStartPosition.CenterScreen;
			frmNetworkSettings.txtIP.Text=hostIP;
			if(frmNetworkSettings.ShowDialog()==DialogResult.OK)
			{
				hostIP=frmNetworkSettings.txtIP.Text;
				try
				{
					AbortConnection();
					MarshalByRefObject obj = (MarshalByRefObject)RemotingServices.Connect(typeof(IServer),"http://"+hostIP+":9090/Server");
					Global.server=obj as IServer;                    
				}
				catch
				{
					AbortConnection();
					return;
				}
			}
		}

		private void conMenuSendMessage_Click(object sender, System.EventArgs e)
		{
			OpenFormMessage((conMenu.SourceControl as LanMessengerControls.LanMessengerContact).Contact);
		}

		private void UpdatePanelContact()
		{
			statusBar.Text= "Loading friends list from server ...";
			ArrayList contacts=null;
			try
			{
				contacts = Global.server.GetContacts(Global.username);
			}
			catch
			{
				AbortConnection();
				return;
			}
			statusBar.Text= "Friends list has been loaded.";


            Label lblInfo = new Label();
            lblInfo.Text= "Friends List :";
			lblInfo.Location=new System.Drawing.Point(8,4);
			lblInfo.Size=new System.Drawing.Size(200,16);
            
			
			pnlContacts.Controls.Clear();
			Global.contactList.Clear();
			pnlContacts.Controls.Add(lblInfo);
			int i = 20;
			statusBar.Text= "Updating friend list ...";
			foreach(object o in contacts)
			{						
				LanMessengerControls.LanMessengerContact temp = new LanMessengerControls.LanMessengerContact();
                temp.DisplayName = Global.server.GetfullName(o as string); // Hiển thị Display Name thay vì là Username
                temp.Contact = o as string;
				statusBar.Text= "Added" + o as string;
				try
				{
					temp.Online=Global.server.IsVisible(o as String);
				}
				catch
				{
					AbortConnection();
					return;
				}
				temp.Location=new System.Drawing.Point(8,i);
				temp.Size=new System.Drawing.Size(pnlContacts.Width-32,16);
				temp.DoubleClick+=new System.EventHandler(this.Contact_Click); // Sự kiện double click lên contact
				temp.ContextMenu=conMenu;

				pnlContacts.Controls.Add(temp);
				Global.contactList.Add(temp);
				i +=48;
			}
            CreateAutoCompleteTextBox(); // Tạo dữ liệu cho khung SearchContact
			statusBar.Text= "Update friends list successfully.";
		}
		private void OpenFormMessage(string contact)
		{
			if(Global.windowList.Contains(contact))
			{
				((FormMessage)Global.windowList[contact]).Focus();
			}
			else
			{
				FormMessage frmMessage = new FormMessage();
				frmMessage.contact=contact;
				frmMessage.Text= Global.server.GetfullName(contact) + " (" + contact + ")" + " - Tin nhắn trực tiếp.";
				frmMessage.Show();
				Global.windowList.Add(contact,frmMessage);					
			}
		}

        // Xử lý SignOut
		private void SignOut()
		{			
			ArrayList a = new ArrayList();
			foreach(string key in Global.windowList.Keys)
				a.Add(key);
			foreach(string key in a)
				(Global.windowList[key] as FormMessage).Close();

            this.txtSearchName.Enabled = false;
            rbtnOnline.Enabled = false;
            rbtnInvisible.Enabled = false;
            this.txtSearchName.Clear();
            this.menuAddContact.Enabled = false;
            this.menuSendMessage.Enabled = false;
            this.menuRemoveContact.Enabled = false;
            this.menuLogMessage.Enabled = false;
            this.menuChangeDisplayName.Enabled = false;
            this.menuOpenChatRoom.Enabled = false;
            this.menuJoinRoom.Enabled = false;
			this.menuChangeUser.Text= "Log in";
            this.menuSignOut.Enabled = false;
            this.pnlContacts.ContextMenu = null;
            this.notMenuSend.Enabled = false;
            this.notMenuSignIn.Text = "Log in";
            this.notMenuSignOut.Enabled = false;
            tmrMessageReceive.Enabled = false;
            tmrContactUpdate.Enabled = false;

            //shortcut
            btn_addFriend.Enabled = false;
            btn_changePass.Enabled = false;
            btn_group.Enabled = false;
            btn_mess.Enabled = false;
            btn_Logchat.Enabled = false;

            if (setting[5] == "2")
                DeleteAllLogs();
			try
			{
				Global.server.SignOut(Global.username);                
				statusBar.Text="Đã đăng xuất.";                
			}
			catch
			{
				AbortConnection();
				return;
			}
			finally
			{
				pnlContacts.Controls.Clear();
				Global.contactList.Clear();
				Global.username="";
				
			}
		}
		private void conMenuRemoveContact_Click(object sender, System.EventArgs e)
		{
			try
			{
				Global.server.RemoveContact(Global.username,(conMenu.SourceControl as LanMessengerControls.LanMessengerContact).Contact);
				UpdatePanelContact();
			}
			catch
			{
				AbortConnection();
				return;
			}
		}

        // Sự kiện người dùng bấm refresh lại danh sách contact
		private void conMenuRefreshContactsPanel_Click(object sender, System.EventArgs e)
		{
			this.UpdatePanelContact();
		}

        // Xử lý đăng nhập
		private void SignIn()
		{            
			notifyIcon.ContextMenu=null;
			statusBar.Text= "Login action";
            lblWelcome.Text = "No Login";
			FormSignIn frmSignIn = new FormSignIn();
			switch(frmSignIn.ShowDialog(this))
			{
				case DialogResult.OK:					
					Global.username=frmSignIn.txtUsername.Text; // Tên người dùng = tên nhập lúc đầu ở form SignIn
					try
					{
                        // Nếu có tin nhắn offline thì hiển thị ở FormOfflineMessages 
						ArrayList offline = Global.server.ReceiveOffline(Global.username);
						if(offline.Count>0)
						{
							FormOfflineMessages frmOffline = new FormOfflineMessages(offline);
                            frmOffline.Show();                            
						}						
					}
					catch
					{
						AbortConnection();
						return;
					}
                    
                    txtSearchName.Enabled = true;
                    rbtnOnline.Enabled = true;
                    rbtnInvisible.Enabled = true;                    

                    // Xét trạng thái lúc đầu của 2 Radiobutton này
                    if (Global.server.IsVisible(Global.username))
                    {
                        rbtnOnline.Checked = true;
                    }
                    else
                        rbtnInvisible.Checked = true;
                    
					statusBar.Text="Đã đăng nhập";
                    if (Global.server.IsVisible(Global.username))
                        lblWelcome.Text = "Hello " + Global.server.GetfullName(Global.username) + ", Online.";
                    else
                        lblWelcome.Text = "Hello " + Global.server.GetfullName(Global.username) + ", Invisible.";
					tmrMessageReceive.Enabled=true;
					tmrContactUpdate.Enabled=true;
		
					this.menuAddContact.Enabled=true;
					this.menuSendMessage.Enabled=true;
					this.menuRemoveContact.Enabled=true;
                    this.menuLogMessage.Enabled = true;
                    this.menuChangeDisplayName.Enabled = true;
                    this.menuOpenChatRoom.Enabled = true;
                    this.menuJoinRoom.Enabled = true;
                    this.menuChangeUser.Text = "Sign in with another account";
					this.menuSignOut.Enabled=true;
					this.pnlContacts.ContextMenu=this.conMenuContactsPanel;

					this.notMenuSend.Enabled=true;
					this.notMenuSignIn.Text= "Sign in with another account";
					this.notMenuSignOut.Enabled=true;

                    //shortcut
                    btn_addFriend.Enabled = true;
                    btn_changePass.Enabled = true;
                    btn_group.Enabled = true;
                    btn_mess.Enabled = true;
                    btn_Logchat.Enabled = true;

                    this.UpdatePanelContact();
					break;
			}
			notifyIcon.ContextMenu=this.notifyMenu;			
		}

		private void AbortConnection()
		{
			tmrMessageReceive.Enabled=false;
			tmrContactUpdate.Enabled=false;

			this.menuAddContact.Enabled=false;
			this.menuSendMessage.Enabled=false;
			this.menuRemoveContact.Enabled=false;
            this.menuLogMessage.Enabled = false;
            this.menuChangeDisplayName.Enabled = false;
            this.menuOpenChatRoom.Enabled = false;
            this.menuJoinRoom.Enabled = false;
			this.menuChangeUser.Text= "Log in";
			this.menuSignOut.Enabled=false;
			this.pnlContacts.ContextMenu=null;

			this.notMenuSend.Enabled=false;
			this.notMenuSignIn.Text= "Log in";
			this.notMenuSignOut.Enabled=false;

            //shortcut
            btn_addFriend.Enabled = false;
            btn_changePass.Enabled = false;
            btn_group.Enabled = false;
            btn_mess.Enabled = false;
            btn_Logchat.Enabled = false;

            ArrayList a = new ArrayList();
			foreach(string key in Global.windowList.Keys)
				a.Add(key);
			foreach(string key in a)
				(Global.windowList[key] as FormMessage).Close();
			Global.username="";
			pnlContacts.Controls.Clear();
			Global.contactList.Clear();
            //statusBar.Text = "Lỗi kết nối tới Server.";
			this.Focus();
            //MessageBox.Show("Lỗi kết nối tới Server. Vui lòng kiểm tra kết nối và thử lại!");
		}

		private void menuAbout_Click(object sender, System.EventArgs e)
		{
			FormAbout frmAbout = new FormAbout();
			frmAbout.ShowDialog();
		}

        private void menuMin_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            notifyIcon.BalloonTipTitle = "MESSENGER";
            notifyIcon.BalloonTipText = "The program has been scaled down to the system tray.";
            notifyIcon.ShowBalloonTip(2000);
            this.notMenuMin.Enabled = false;
        }

        private void showLanMessenger_Click(object sender, System.EventArgs e)
        {
            this.Show();
            this.menuMin.Enabled = true;
            this.notMenuMin.Enabled = true;
        }

        // Sự kiện mở FormOption
        private void menuItem11_Click(object sender, EventArgs e)
        {
            FormOption fo = new FormOption();
            fo.Show();
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
            setting[5] = w1.ReadString().ToString(); // Tùy chọn việc lưu logs
            w1.Close();
            fs1.Close();
        }

        // Tạo dữ liệu cho khung SearchContact
        private void CreateAutoCompleteTextBox()
        {           
            string[] arrayContact = new string[Global.contactList.Count]; // Khởi tạo mảng chứa tên các Contact trong list
            int i = 0;

            // Đưa tên các Contact trong list vào mảng arrayContact
            foreach (object o in Global.contactList)
            {
                arrayContact[i] = ((LanMessengerControls.LanMessengerContact)o).Contact.ToString();
                i++;
            }

            // Khởi tạo AutoCompleteString
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();                        
            foreach (string name in arrayContact)
            {
                auto.Add(name + " (" + Global.server.GetfullName(name) + ")");
            }
          
            // Gán AutoCompleteSource cho textbox txtSearchContact
            txtSearchName.AutoCompleteCustomSource = auto;
        }

        // Khi nhấn phím Enter thì mở ra khung chat với tên đã Search
        private void SearchKeyPress(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSearchName.Text.IndexOf('(') != -1)
                    OpenFormMessage(txtSearchName.Text.Substring(0, txtSearchName.Text.IndexOf('(') - 1)); // Mở khung chat tới Contact vừa tìm
                this.txtSearchName.Clear();
                this.txtSearchName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtSearchName.ForeColor = System.Drawing.SystemColors.WindowFrame;
                this.txtSearchName.Text = "Search...";
            }
        }

        // Khi tìm người nào đó xong thì Clear nội dung hiện tại của Searchbar
        private void SearchKeyClick(object sender, System.EventArgs e)
        {
            this.txtSearchName.Clear();
            this.txtSearchName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchName.ForeColor = System.Drawing.SystemColors.MenuText;
        }

        // Icon bên thanh tìm kiếm
        private void picSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchName.Text != "" && txtSearchName.Text != "Search...")
            {
                OpenFormMessage(txtSearchName.Text.Substring(0, txtSearchName.Text.IndexOf('(') -1));
            }
        }

        // Sự kiện chọn RadioButton Online
        private void rbtnOnline_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnOnline.Checked == true && !Global.server.IsVisible(Global.username))
            {
                Global.server.ChangeStatus(Global.username);
                lblWelcome.Text = "Hello " + Global.server.GetfullName(Global.username) + ", Online.";
            }                
        }

        private void rbtnInvisible_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnInvisible.Checked == true && Global.server.IsVisible(Global.username))
            {
                Global.server.ChangeStatus(Global.username);
                lblWelcome.Text = "Hello " + Global.server.GetfullName(Global.username) + ", Invisible.";
            }                
        }

        // Thủ tục xóa Logs khi người dùng chọn chế độ "xóa all tin nhắn khi đăng xuất"
        private void DeleteAllLogs()
        {
            if (Global.username != "") // Kiểm tra xem người dùng đã đăng nhập hay chưa thì mới xóa logs dc
            {
                string path = "logs/" + Global.username + "/";
                if (Directory.Exists(path))
                {
                    // Lấy danh sách các folder con của Folder hiện tại.
                    string[] directoryContact = Directory.GetDirectories(path);
                    foreach (string dc in directoryContact)
                    {
                        // Lấy danh sách các file trong folder dc hiện tại
                        string[] fileLogs = Directory.GetFiles(dc);
                        foreach (string fl in fileLogs)
                        {
                            File.Delete(fl); // xóa lần lượt từng file
                        }
                        Directory.Delete(dc); // xóa mục con chứa file
                    }
                    Directory.Delete(path); // xóa mục lưu logs của người dùng
                }
            }            
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void lb_AddFriends_Click(object sender, EventArgs e)
        {
            FormAddContact frmAddContact = new FormAddContact();
            if (frmAddContact.ShowDialog() == DialogResult.OK)
            {
                UpdatePanelContact();
            }
        }

        private void lb_Connect_Click(object sender, EventArgs e)
        {
            FormNetworkSettings frmNetworkSettings = new FormNetworkSettings();
            frmNetworkSettings.txtIP.Text = hostIP;
            if (frmNetworkSettings.ShowDialog() == DialogResult.OK)
            {
                hostIP = frmNetworkSettings.txtIP.Text;
                try
                {
                    AbortConnection();
                    MarshalByRefObject obj = (MarshalByRefObject)RemotingServices.Connect(typeof(IServer), "http://" + hostIP + ":9090/Server");
                    Global.server = obj as IServer;
                }
                catch
                {
                    AbortConnection();
                    return;
                }
            }
        }

        private void lb_Setting_Click(object sender, EventArgs e)
        {
            FormOption fo = new FormOption();
            fo.Show();
        }


        //button shortcut

        private void btn_addFriend_Click(object sender, EventArgs e)
        {
            FormAddContact frmAddContact = new FormAddContact();
            if (frmAddContact.ShowDialog() == DialogResult.OK)
            {
                UpdatePanelContact();
            }
        }

        private void btn_mess_Click(object sender, EventArgs e)
        {
            using (FormSelectContact frmContact = new FormSelectContact())
            {
                if (frmContact.ShowDialog(this) == DialogResult.OK)
                {
                    if (frmContact.txtContact.Text == Global.username)
                    {
                        MessageBox.Show("Bạn không thể gửi tin nhắn tới chính bạn được!");
                        return;
                    }
                    if (Global.windowList.Contains(frmContact.txtContact.Text))
                    {
                        ((FormMessage)Global.windowList[frmContact.txtContact.Text]).Focus();
                    }
                    else
                    {
                        FormMessage frmMessage = new FormMessage();
                        frmMessage.contact = frmContact.txtContact.Text;
                        frmMessage.Text = frmContact.txtContact.Text + " - Tin nhắn trực tiếp.";
                        Global.windowList.Add(frmContact.txtContact.Text, frmMessage);
                        frmMessage.Show();
                    }
                }
            }
        }

        private void btn_group_Click(object sender, EventArgs e)
        {
            // Khởi tạo kênh liên lạc với remote Object.
            channelChatRoom = new TcpChannel(7070);
            ChannelServices.RegisterChannel(channelChatRoom, false);

            // Ở đây sẻ sử dụng Singleton để duy trì trạng thái với nhiều kết nối Client 
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(SampleObject), Global.username.ToString(), WellKnownObjectMode.Singleton); // Cho Server chat room

            // Mở Room
            if (OpenRoom() == 0)
            {
                ChannelServices.UnregisterChannel(channelChatRoom);
                channelChatRoom = null;
            }
        }

        private void btn_setting_Click(object sender, EventArgs e)
        {
            FormOption fo = new FormOption();
            fo.Show();
        }

        private void btn_link_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void Connect()
        {
            FormNetworkSettings frmNetworkSettings = new FormNetworkSettings();
            frmNetworkSettings.txtIP.Text = hostIP;
            if (frmNetworkSettings.ShowDialog() == DialogResult.OK)
            {
                hostIP = frmNetworkSettings.txtIP.Text;
                try
                {
                    AbortConnection();
                    MarshalByRefObject obj = (MarshalByRefObject)RemotingServices.Connect(typeof(IServer), "http://" + hostIP + ":9090/Server");
                    Global.server = obj as IServer;
                }
                catch
                {
                    AbortConnection();
                    return;
                }
            }
        }

        private void btn_Logchat_Click(object sender, EventArgs e)
        {
            FormLogsReader f = new FormLogsReader();
            f.Show();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                Global.server.SignOut(Global.username);
                if (setting[5] == "2")
                    DeleteAllLogs();
                pnlContacts.Controls.Clear();
                Global.contactList.Clear();
                this.txtSearchName.Enabled = false;
                rbtnOnline.Enabled = false;
                rbtnInvisible.Enabled = false;
                this.txtSearchName.Clear();
                this.menuAddContact.Enabled = false;
                this.menuSendMessage.Enabled = false;
                this.menuRemoveContact.Enabled = false;
                this.menuLogMessage.Enabled = false;
                this.menuChangeDisplayName.Enabled = false;
                this.menuOpenChatRoom.Enabled = false;
                this.menuJoinRoom.Enabled = false;
                this.menuChangeUser.Text = "Log in";
                this.menuSignOut.Enabled = false;
                this.pnlContacts.ContextMenu = null;
                this.notMenuSend.Enabled = false;
                this.notMenuSignIn.Text = "Log in";
                this.notMenuSignOut.Enabled = false;
                tmrMessageReceive.Enabled = false;
                tmrContactUpdate.Enabled = false;

                //shortcut
                btn_addFriend.Enabled = false;
                btn_changePass.Enabled = false;
                btn_group.Enabled = false;
                btn_mess.Enabled = false;
                btn_Logchat.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Không thể lấy dữ liệu từ server!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SignIn();
            }
        }

        private void btn_changePass_Click(object sender, EventArgs e)
        {
            FormChangePassword fo = new FormChangePassword();
            fo.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormSendFile fm = new FormSendFile("192.168.1.27");
            fm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormRecieveFile fm = new FormRecieveFile("192.168.1.27");
            fm.Show();
        }
    }
    class Global
	{
		internal static IServer server;
		internal static Hashtable windowList;
		internal static ArrayList contactList;
		internal static string username;

		static Global()
		{
			windowList = new Hashtable();
			contactList = new ArrayList();
			username="";
		}
	}
}