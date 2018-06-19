using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Drawing.Imaging;
using System.Diagnostics;
namespace Lan_Messenger
{
    public partial class FormPhotoReceive : Form
    {
        Thread t1;
        int flag = 0;
        string receivedPath;
        public static string IP_Server;
        public delegate void UpdateStatusDelegate(string newStatus); // Sử dụng Delegate để update lại satatus mà ko bị xung đột Thread

        public FormPhotoReceive()
        {
            InitializeComponent();
            ResetSlideShow(); // Sửa lại file html
            DeleteAllPicture(); // Xóa tất cả các ảnh cũ

            t1 = new Thread(new ThreadStart(StartListening)); // khởi tạo luồng
            t1.Start();
            SlideShow(); // Khởi tạo slide.
        }

        private void SlideShow()
        {
            string path = "data/photosharing.html";
            path = Path.GetFullPath(path);
            Uri url = new Uri(path);
            webBrowser1.Url = url;
        }

        public class StateObject
        {
            // Client socket.
            public Socket workSocket = null;

            public const int BufferSize = 1024;
            // Receive buffer.
            public byte[] buffer = new byte[BufferSize];
        }

        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public void StartListening()
        {
            byte[] bytes = new Byte[1024];
            IPEndPoint ipEnd = new IPEndPoint(IPAddress.Any, 5656);
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listener.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true); // tái sử dụng socket
                listener.Bind(ipEnd);
                listener.Listen(100);
                while (true)
                {
                    allDone.Reset();
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                    allDone.WaitOne();
                    webBrowser1.Refresh();
                    webBrowser1.Refresh();
                    UpdateStatus("Đã nhận hình ảnh thành công!");
                }
            }
            catch (Exception ex)
            {
                UpdateStatus(ex.Message);
            }
        }
        public void AcceptCallback(IAsyncResult ar)
        {

            allDone.Set();
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);
            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
            new AsyncCallback(ReadCallback), state);
            flag = 0;
        }

        public string PictureName;
        public void ReadCallback(IAsyncResult ar)
        {

            int fileNameLen = 1;
            String content = String.Empty;
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;
            int bytesRead = handler.EndReceive(ar);
            if (bytesRead > 0)
            {
                if (flag == 0)
                {
                    fileNameLen = BitConverter.ToInt32(state.buffer, 0);
                    string fileName = Encoding.UTF8.GetString(state.buffer, 4, fileNameLen);
                    PictureName = fileName;
                    receivedPath = "data/images/" + fileName;
                    UpdateStatus("Đang nhận hình ảnh...");
                    flag++;
                }
                if (flag >= 1)
                {
                    BinaryWriter writer = new BinaryWriter(File.Open(receivedPath, FileMode.Append));
                    if (flag == 1)
                    {
                        writer.Write(state.buffer, 4 + fileNameLen, bytesRead - (4 + fileNameLen));
                        flag++;
                    }
                    else
                        writer.Write(state.buffer, 0, bytesRead);
                    writer.Close();
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                }
            }
            else
            {
                AddImagetoHtml(PictureName);
                resize(receivedPath);
                UpdateStatus("Đã nhận hình ảnh thành công!");
            }
        }

        private void UpdateStatus(string newStatus)
        {
            if (lblStatus.InvokeRequired)
            {
                try
                {
                    UpdateStatusDelegate del = new UpdateStatusDelegate(UpdateStatus);
                    lblStatus.Invoke(del, new object[] { newStatus });
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                lblStatus.Text = newStatus;
            }
        }

        private void FormPhotoReceive_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        // Sau khi nhận được một hình mới thì add tên file ảnh vào mã HTML
        private void AddImagetoHtml(string filename)
        {
            string path = "data/photosharing.html";
            string content;
            int index;
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            content = sr.ReadToEnd();
            index = content.IndexOf("[");
            content = content.Insert(index + 1, "'" + filename + "',");
            sr.Close();
            fs.Close();

            try
            {
                if (File.Exists(path)) File.Delete(path);
            }
            catch (Exception ex)
            {
                UpdateStatus(ex.Message);
            }
            FileStream fs2 = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs2);
            sw.Write(content);
            sw.Close();
            fs2.Close();
            webBrowser1.Refresh(); // Làm mới lại Slideshow sau khi add thêm ảnh mới.
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //t1.Abort();
            this.Hide();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Process ps = new Process();
            ps.StartInfo.FileName = Path.GetFullPath("data/images");
            ps.Start();
            ps.Close();
        }

        // reset lại nội dung html của photosharing.html
        private void ResetSlideShow()
        {
            string content;
            FileStream fs1 = new FileStream("data/photoconfig.dat", FileMode.Open);
            StreamReader sr = new StreamReader(fs1);
            content = sr.ReadToEnd();
            sr.Close();
            fs1.Close();

            string path = "data/photosharing.html";
            if (File.Exists(path))
                File.Delete(path);
            FileStream fs2 = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs2);
            sw.Write(content);
            sw.Close();
            fs2.Close();
        }

        // Resize ảnh tạo thumbnail
        private void resize(string path)
        {
            Bitmap bm = new Bitmap(path);//Tạo 1 ảnh bitmap từ file ảnh ban đầu.
            Bitmap bm2 = new Bitmap(50, 40);//Tạo 1 ảnh bitmap có kích thước 50x40 để làm thumbnail
            Graphics gr2 = Graphics.FromImage((Image)(bm2));
            gr2.DrawImage(bm, 0, 0, 50, 40);//
            path = path.Insert(path.Length - 4, "t");

            string tag = path.Substring(path.Length - 4);
            // Lưu ảnh thumbanil với cùng định dạng ảnh gốc.
            if (tag == ".jpg" || tag == ".JPG")
                bm2.Save(path, ImageFormat.Jpeg);
            else
                if (tag == ".png" || tag == ".PNG")
                    bm2.Save(path, ImageFormat.Png);
                else
                    if (tag == ".bmp" || tag == ".BMP")
                        bm2.Save(path, ImageFormat.Bmp);
                    else
                        bm2.Save(path, ImageFormat.Gif);
            gr2.Dispose();
            webBrowser1.Refresh();
        }

        // Xóa tất cả ảnh đã nhận sau khi Close form
        private void DeleteAllPicture()
        {
            string path = "data/images/";
            string[] listFile;
            listFile = Directory.GetFiles(path);
            try
            {
                for (int i = 0; i < listFile.Length; i++)
                {
                    File.Delete(listFile[i]);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message);
            }
        }
    }
}
