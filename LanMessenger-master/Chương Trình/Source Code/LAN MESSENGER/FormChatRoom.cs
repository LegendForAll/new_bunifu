using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using LanMessengerChatRoomBase;

namespace Lan_Messenger
{
    public partial class FormChatRoom : Form
    {
        internal SampleObject remoteObj;
        internal int key = 0;
        internal string yourName;
        public delegate void GetString(Boolean b);
        public GetString MyGetData;      

        ArrayList alOnlineUser = new ArrayList();

        public FormChatRoom()
        {
            InitializeComponent();

            // Danh sách bạn
            foreach (object o in Global.contactList)
            {
                cbbListContact.Items.Add(Global.server.GetfullName(((LanMessengerControls.LanMessengerContact)o).Contact.ToString()) + " (" + ((LanMessengerControls.LanMessengerContact)o).Contact.ToString() + ")");
            }
        }
        int skipCounter = 4;
        ArrayList onlineUser;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (remoteObj != null)
            {
                string tempStr = remoteObj.GetMsgFromSvr(key);
                if (tempStr.Trim().Length > 0)
                {
                    key++;
                    txtAllChat.Text = txtAllChat.Text + "\n" + tempStr;
                }
                {
                    onlineUser = remoteObj.GetOnlineUser();
                    skipCounter = 0;

                    if (onlineUser.Count < 2)
                    {
                        txtChatHere.Text = "There should be at least 2 people to chat with each other.";
                        txtChatHere.Enabled = false;
                    }
                    else if (txtChatHere.Text == "There should be at least 2 people to chat with each other." && txtChatHere.Enabled == false)
                    {
                        txtChatHere.Text = "";
                        txtChatHere.Enabled = true;
                    }
                }
                //else
                //  skipCounter++;
            }
        }

        // Gửi 1 tin
        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void SendMessage()
        {

            if (remoteObj != null && txtChatHere.Text.Trim().Length > 0)
            {
                remoteObj.SendMsgToSvr(Global.server.GetfullName(yourName) + ": " + txtChatHere.Text);
                txtChatHere.Text = "";
            }
        }

        // Xử lý logout ra khỏi room
        private void FormChatRoom_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (remoteObj != null)
            {
                remoteObj.LeaveChatRoom(yourName);
                txtChatHere.Text = "";
            }
            if (MyGetData != null)
            {
                MyGetData(true);
            }
            this.Dispose();
            this.Close();
        }

        
        private void txtChatHere_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtChatHere.Clear();
            }
        }

        // nhấn enter -> gửi
        private void txtChatHere_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtChatHere.Text != "")
                    btnSend_Click(null, null);
            }
        }

        //Mời tham gia chat
        private void cbbListContact_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool Joined = false;
            bool Host = false;
            string name = cbbListContact.SelectedItem.ToString();
            int indexChar = name.IndexOf('(');
            string contact = name.Substring(indexChar + 1, name.Length - indexChar - 2);
            if (onlineUser[0].ToString() == Global.username)
                Host = true;
            else
                Host = false;
            foreach (string c in onlineUser)
            {
                if (c == contact)
                    Joined = true;
            }

            if (Host)
            {
                if (!Joined)
                {
                    if (Global.server.IsVisible(contact))
                    {
                        Global.server.Send(Global.username, contact, "You are invited to Chat Room ...");
                        MessageBox.Show("Lời mời đã được gửi tới " + contact);
                    }
                    else
                        MessageBox.Show("Người này hiện không Online!","Lỗi!");
                }
                else
                    MessageBox.Show("Người này đã ở trong Chat Room rồi", "Lỗi!");
            }
            else
                MessageBox.Show("Bạn không đủ quyền!. Chỉ có chủ Chat Room mới được phép mời thêm bạn chat!", "Lỗi!");
        }
    }
}
