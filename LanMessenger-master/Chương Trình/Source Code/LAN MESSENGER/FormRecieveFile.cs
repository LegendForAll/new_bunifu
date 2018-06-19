using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanMessengerCaro;
using LanMessengerSendFile;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

namespace Lan_Messenger
{
    public partial class FormRecieveFile : Form
    {
        private const int BUFFER = 1024 * 1024 * 50;
        private string IP;
        private int port = 9168;
        private string receivePath;
        private Socket server;
        private Socket client;

        public FormRecieveFile(string IPServer)
        {
            InitializeComponent();

            this.IP = IPServer;

            receivePath = "D:\\";
            txtFileName.Text = receivePath;
        }

        private void FormRecieveFile_Load(object sender, EventArgs e)
        {
            IPEndPoint IPEP = new IPEndPoint(IPAddress.Parse(IP), port);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            server.Bind(IPEP);
            server.Listen(10);
            Thread acceptClient = new Thread(() =>
            {
                client = server.Accept();
                if (client != null)
                {
                    this.Invoke((MethodInvoker)(() =>
                    {
                        Listen();
                    }));
                }    
            });
            acceptClient.IsBackground = true;
            acceptClient.Start();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // Mở folder đã nhận file
            Process ps = new Process();

            ps.StartInfo.FileName = Path.GetFullPath(receivePath);
            ps.Start();
            ps.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        void Listen()
        {
            Thread listenThread = new Thread(() =>
            {
                SendData data = null;
                while (data == null)
                {
                    data = (SendData)Recieve();
                    ProcessData(data);
                }
            });
            listenThread.IsBackground = true;
            listenThread.Start();
        }

        public Object Recieve()
        {
            byte[] recieveData = new byte[BUFFER];
            bool isRecieved = RecieveData(client, recieveData);
            return DeserializeData(recieveData);
        }

        private bool RecieveData(Socket target, byte[] data)
        {
            return target.Receive(data) == 1 ? true : false;
        }

        // Giải nén mảng byte[] thành đối tượng object
        public object DeserializeData(byte[] theByteArray)
        {
            MemoryStream ms = new MemoryStream(theByteArray);
            BinaryFormatter bf1 = new BinaryFormatter();
            ms.Position = 0;
            return bf1.Deserialize(ms);
        }

        private void WriteFile(byte[] bData, string filePath)
        {
            FileStream fs = File.Create(filePath);
            BinaryWriter bw = new BinaryWriter(fs);

            bw.Write(bData);

            bw.Close();
            fs.Close();
        }

        private void ProcessData(SendData data)
        {
            switch (data.Command)
            {
                case (int)DataCommand.SEND_DATA:
                    WriteFile(data.FileData, receivePath + data.FileName);
                    MessageBox.Show("Received " + receivePath + data.FileName);
                    break;
                default:
                    break;
            }
        }
    }
}
