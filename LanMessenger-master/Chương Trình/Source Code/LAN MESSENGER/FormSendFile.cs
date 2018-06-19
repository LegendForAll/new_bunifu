using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using LanMessengerSendFile;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lan_Messenger
{
    public partial class FormSendFile : Form
    {
        public string IP; //IP server nhận
        int port = 9168;
        string splitter = "'\\'"; //Ký tự phân cấp thư mục
        string[] split = null;
        SendData sendData;
        Socket client;

        string fileName;

        public FormSendFile(string IPServer)
        {
            InitializeComponent();

            this.IP = IPServer;

            // Kết nối
            IPEndPoint IPEP = new IPEndPoint(IPAddress.Parse(IP), port);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(IPEP);
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            char[] delimiter = splitter.ToCharArray();
            ofdOpenFile.ShowDialog();
            txtFileLink.Text = ofdOpenFile.FileName;
            split = txtFileLink.Text.Split(delimiter);
            int limit = split.Length;
            fileName = split[limit - 1].ToString();
            if (txtFileLink.Text != null)
                btnSend.Enabled = true;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            // tắt nút send
            btnSend.Enabled = false;

            // đưa dữ liệu thành object DataSend
            sendData = new SendData((int)DataCommand.SEND_DATA, fileName, File.ReadAllBytes(txtFileLink.Text));

            // gửi data
            if (Send(sendData))
            {
                lblStatus.Text = "File sent complete";
                MessageBox.Show("File sent complete");
            }
            else
                lblStatus.Text = "Can't send file";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public bool Send(Object data)
        {
            byte[] sendData = SerializeData(data);
            return SendData(client, sendData);
        }

        private bool SendData(Socket target, byte[] data)
        {
            return target.Send(data) == 1 ? true : false;
        }

        // Nén đối tượng object thành mảng byte[]
        public byte[] SerializeData(Object o)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, o);
            return ms.ToArray();
        }

        private void FormSendFile_Load(object sender, EventArgs e)
        {

        }
    }
}
