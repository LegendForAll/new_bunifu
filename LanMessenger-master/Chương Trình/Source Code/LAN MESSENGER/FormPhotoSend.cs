using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Drawing.Imaging;

namespace Lan_Messenger
{
    public partial class FormPhotoSend : Form
    {
        public static string IP; // IP của server nhận ảnh
        string splitter = "'\\'";
        string fName;
        string[] split = null;
        byte[] clientData;
        public FormPhotoSend()
        {
            InitializeComponent();
        }

        FormMessage f;
        public FormPhotoSend(FormMessage form)
        {
            ResetSlideShow(); // Sửa lại file html
            DeleteAllPicture(); // Xóa tất cả các ảnh cũ
            InitializeComponent();
            f = new FormMessage();
            f = form;
            SlideShow(); // Khởi tạo slide.
        }

        private void SlideShow()
        {
            string path = "data/photosharing.html";
            path = Path.GetFullPath(path);
            Uri url = new Uri(path);
            webBrowser1.Url = url;
        }

        private void FormPhotoSend_Load(object sender, EventArgs e)
        {
            IP = f.IPContact;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectPhoto_Click(object sender, EventArgs e)
        {
            char[] delimiter = splitter.ToCharArray();
            openFileDialog1.ShowDialog();
            txtPictureLink.Text = openFileDialog1.FileName;
            split = txtPictureLink.Text.Split(delimiter);
            int limit = split.Length;
            fName = split[limit - 1].ToString();
            if (txtPictureLink.Text != null)
                btnSend.Enabled = true;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Socket clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            byte[] fileName = Encoding.UTF8.GetBytes(fName); // tên file
            byte[] fileData = File.ReadAllBytes(txtPictureLink.Text); // dữ liệu
            byte[] fileNameLen = BitConverter.GetBytes(fileName.Length); // độ dài tên file
            clientData = new byte[4 + fileName.Length + fileData.Length];

            fileNameLen.CopyTo(clientData, 0);
            fileName.CopyTo(clientData, 4);
            fileData.CopyTo(clientData, 4 + fileName.Length);

            lblStatus.Text = "Đang kết nối tới người nhận...";
            clientSock.Connect(IP, 5656); // IP máy đích
            lblStatus.Text = "Đang truyền tải dữ liệu. Làm ơn đợi...";
            clientSock.Send(clientData);
            clientSock.Close();
            lblStatus.Text = "Hình ảnh đã được chuyển đi thành công!";

            // Thêm ảnh vào slide của mình
            AddImagetoHtml(fName);
            resize(txtPictureLink.Text, fName); // tạo thumbnail
        }

        private void txtPictureLink_TextChanged(object sender, EventArgs e)
        {
            if (txtPictureLink.Text != "")
                txtPictureLink.Enabled = true;
            else
                txtPictureLink.Enabled = false;
        }

        private void AddImagetoHtml(string filename)
        {
            string path = "data/photosharing.html";
            string content;
            int index;
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            content = sr.ReadToEnd();
            index = content.IndexOf("[");
            content = content.Insert(index + 1, "'send/" + filename + "',");
            sr.Close();
            fs.Close();

            if (File.Exists(path)) File.Delete(path);
            FileStream fs2 = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs2);
            sw.Write(content);
            sw.Close();
            fs2.Close();
            File.Copy(txtPictureLink.Text, "data/images/send/" + filename); // Copy ảnh vào mục Send để hiển thị trên slide.
            webBrowser1.Refresh(); // Làm mới lại Slideshow sau khi add thêm ảnh mới.
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
        private void resize(string path, string Name)
        {
            Bitmap bm = new Bitmap(path);//Tạo 1 ảnh bitmap từ file ảnh ban đầu.
            Bitmap bm2 = new Bitmap(50, 40);//Tạo 1 ảnh bitmap có kích thước 50x40 để làm thumbnail
            Graphics gr2 = Graphics.FromImage((Image)(bm2));
            gr2.DrawImage(bm, 0, 0, 50, 40);//
            string SavePath = "data/images/send/" + Name;
            SavePath = SavePath.Insert(SavePath.Length - 4, "t");

            string tag = path.Substring(path.Length - 4);
            // Lưu ảnh thumbanil với cùng định dạng ảnh gốc.
            if (tag == ".jpg" || tag == ".JPG")
                bm2.Save(SavePath, ImageFormat.Jpeg);
            else
                if (tag == ".png" || tag == ".PNG")
                    bm2.Save(SavePath, ImageFormat.Png);
                else
                    if (tag == ".bmp" || tag == ".BMP")
                        bm2.Save(SavePath, ImageFormat.Bmp);
                    else
                        bm2.Save(SavePath, ImageFormat.Gif);
            gr2.Dispose();
        }

        // Xóa tất cả ảnh đã nhận sau khi Close form
        private void DeleteAllPicture()
        {
            string path = "data/images/send/";
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