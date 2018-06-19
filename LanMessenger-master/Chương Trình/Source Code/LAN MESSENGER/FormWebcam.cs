using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DirectX.Capture;
using System.IO;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace Lan_Messenger
{

    public class FormWebcam : Form
    {
        private Capture capture = null;
        private Filters filters = new Filters();
        private System.Windows.Forms.Panel panelVideo;
        private System.Windows.Forms.PictureBox pictureBox;
        private PictureBox pictureBox_Remote;
        private Button btnExit;
        private IContainer components;
        private string IP;

        public FormWebcam()
        {
            InitializeComponent();
        }

        FormMessage fm;
        public FormWebcam(FormMessage form)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            // Nhận thiết bị đầu tiên được tìm thấy trong list
            #if DEBUG
                capture = new Capture(filters.VideoInputDevices[0], filters.AudioInputDevices[0]);
            #endif
            fm = new FormMessage();
            fm = form;
            if (fm.IPWebcam_rq != "")
            {
                IP = fm.IPWebcam_rq;
            }
            else
            {
                IP = fm.IPWebcam_rp;
            }
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    if (components != null)
                    {
                        components.Dispose();
                    }
                }
                base.Dispose(disposing);
            }
            catch (Exception) { }
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWebcam));
            this.panelVideo = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox_Remote = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Remote)).BeginInit();
            this.SuspendLayout();
            // 
            // panelVideo
            // 
            this.panelVideo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelVideo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelVideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelVideo.Controls.Add(this.pictureBox);
            this.panelVideo.ForeColor = System.Drawing.Color.White;
            this.panelVideo.Location = new System.Drawing.Point(425, 267);
            this.panelVideo.Name = "panelVideo";
            this.panelVideo.Size = new System.Drawing.Size(144, 83);
            this.panelVideo.TabIndex = 6;
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(144, 83);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 9;
            this.pictureBox.TabStop = false;
            // 
            // pictureBox_Remote
            // 
            this.pictureBox_Remote.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox_Remote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox_Remote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Remote.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_Remote.Name = "pictureBox_Remote";
            this.pictureBox_Remote.Size = new System.Drawing.Size(557, 338);
            this.pictureBox_Remote.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Remote.TabIndex = 14;
            this.pictureBox_Remote.TabStop = false;
            this.pictureBox_Remote.Click += new System.EventHandler(this.pictureBox_Remote_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.btnExit.Location = new System.Drawing.Point(468, 356);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 29);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormWebcam
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(574, 394);
            this.Controls.Add(this.panelVideo);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pictureBox_Remote);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormWebcam";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Webcam";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.P2PVideoCall_FormClosing);
            this.Load += new System.EventHandler(this.P2PVideoCall_Load);
            this.panelVideo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Remote)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        bool isSending = false;
        private void CaptureDone(System.Drawing.Bitmap e)
        {
            try
            {
                this.pictureBox.Image = e;
                if (isSending)
                    ThreadPool.QueueUserWorkItem(new WaitCallback(SendVideoBuffer), pictureBox.Image);
            }
            catch (Exception) { }
        }


        // Xử lý đóng Socket, Thread khi đóng Form
        private void P2PVideoCall_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!stoped)
            {
                try
                {
                    isSending = false;
                    server_sock.Close();
                    ServerThread.Abort();
                }
                catch (Exception) { }

                try
                {
                    capture.PreviewWindow = null;
                    if (capture != null)
                        capture.Stop();
                }
                catch (Exception) { }
            }

        }

        private void Start_Webcam()
        {
            try
            {
                if (capture != null)
                {
                    if (capture.PreviewWindow != panelVideo)
                    {
                        capture.PreviewWindow = panelVideo;
                    }
                    capture.FrameEvent2 += new Capture.HeFrame(CaptureDone);
                    capture.GrapImg();
                    isSending = true;
                }
            }
            catch (Exception) { }
        }

        // Khởi tạo server, mở port - Vai trò là người gửi
        Socket server_sock;
        void server()
        {
            try
            {
                server_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server_sock.Bind(new IPEndPoint(IPAddress.Any, 6000));
                server_sock.Listen(-1);

                while (true)
                {
                    try
                    {
                        Socket new_socket = server_sock.Accept();
                        NetworkStream ns = new NetworkStream(new_socket);
                        pictureBox_Remote.Image = Image.FromStream(ns);
                        ns.Close();
                        new_socket.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception) { }

        }

        // Hàm gửi hình ảnh trong bộ nhớ đệm đi.
        void SendVideoBuffer(object bufferIn)
        {
            try
            {
                TcpClient tcp = new TcpClient(IP, 6000);
                NetworkStream ns = tcp.GetStream();
                Image buffer = (Image)bufferIn;
                buffer.Save(ns, System.Drawing.Imaging.ImageFormat.Jpeg);
                ns.Close();
                tcp.Close();
            }
            catch (Exception) { }
        }

        // Sự kiện FormLoad - bật webcam
        Thread ServerThread;
        private void P2PVideoCall_Load(object sender, EventArgs e)
        {
            // khởi tạo tiến trình
            ServerThread = new Thread(new ThreadStart(server));
            ServerThread.IsBackground = true;
            ServerThread.Start();

            if (capture != null)
            {
                capture.FrameRate = 15; // số khung hình/giây
                capture.FrameSize = new Size(320, 240); // mặc định size của webcam là 320x240
            }

            // Hiển thị ảnh webcam
            Start_Webcam();
        }

        // Đóng kết nối socket, thread khi đóng form
        bool stoped = false;
        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                isSending = false;
                server_sock.Close();
                ServerThread.Abort();
            }
            catch (Exception) { }

            try
            {
                capture.PreviewWindow = null;
                if (capture != null)
                    capture.Stop();
            }
            catch (Exception) { }
            stoped = true;
            this.Close();
        }

        private void pictureBox_Remote_Click(object sender, EventArgs e)
        {

        }
    }
}
