using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using LanMessengerLib;

namespace Lan_Messenger
{
	/// <summary>
	/// Summary description for FormOfflineMessages.
	/// </summary>
	public class FormOfflineMessages : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.RichTextBox rtbOfflineMessages;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private string[] setting = new string[6]; // Có 6 Options tất cả
		public FormOfflineMessages()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public FormOfflineMessages(ArrayList offlineMessages)
		{
			InitializeComponent();

			for(int i = 0;i < offlineMessages.Count; i++)
			{
				LetterReceive letter= offlineMessages[i] as LetterReceive;
				string message = letter.Message;
				string person = letter.From;
				if(message=="BUZZ IT")
				{							
					message=@"<DING>";
					this.Focus();
				}
                if (File.Exists("UserSetting.dat"))
                    ReadUserSetting();
                else
                    setting[5] = "1";
				rtbOfflineMessages.SelectionFont=new System.Drawing.Font("Microsoft Sans Serif",8.25f,System.Drawing.FontStyle.Bold);
				rtbOfflineMessages.AppendText(person+" : ");
				rtbOfflineMessages.SelectionFont=new System.Drawing.Font("Microsoft Sans Serif",8.25f,System.Drawing.FontStyle.Regular);
				rtbOfflineMessages.AppendText(message+" \n");
                if (setting[5] == "1" || setting[5] == "2")
                    WriteLogs(person + " : " + message, person); // Ghi logs chat Offline
			}			
		}

        private void WriteLogs(string s, string contact)
        {
            //Download source code FREE tai Sharecode.vn
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


        private void ReadUserSetting()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOfflineMessages));
            this.rtbOfflineMessages = new System.Windows.Forms.RichTextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbOfflineMessages
            // 
            this.rtbOfflineMessages.Location = new System.Drawing.Point(8, 8);
            this.rtbOfflineMessages.Name = "rtbOfflineMessages";
            this.rtbOfflineMessages.ReadOnly = true;
            this.rtbOfflineMessages.Size = new System.Drawing.Size(440, 208);
            this.rtbOfflineMessages.TabIndex = 0;
            this.rtbOfflineMessages.Text = "";
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Location = new System.Drawing.Point(376, 224);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 24);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormOfflineMessages
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(456, 254);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.rtbOfflineMessages);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOfflineMessages";
            this.Text = "Những tin nhắn Offlines được gửi tới bạn";
            this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
