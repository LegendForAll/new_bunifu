using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace TrayBalloon
{
    internal partial class TrayBalloonFrm : Form
    {
        
        public string Title; // Tiêu để của bảng Notify
        public string Message; // Nội dung (tên) của Contact đã Online/Offline

        public volatile int StartingOffsetIndex;

        private float OpacityStep;

        public TrayBalloonFrm()
        {
            InitializeComponent();

            Title = null;
            StartingOffsetIndex = 0;

            SetStyle(ControlStyles.Selectable, false);
            MessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            MessageLabel.ForeColor = ForeColor = System.Drawing.Color.Green;
            MessageLabel.MouseDown += new MouseEventHandler(TrayBalloonFrm_MouseDown);
        }

        public string SoundLocation;
        public string BackgroundLocation;

        private bool _LightWeight;
        public bool LightWeight
        {
            get
            {
                return _LightWeight;
            }
            set
            {
                _LightWeight = value;
            }
        }

        private Image _BackgroundImage;
        public override Image BackgroundImage
        {
            get
            {
                if (LightWeight)
                    return null;

                if (_BackgroundImage != null)
                    return _BackgroundImage;

                if (!string.IsNullOrEmpty(BackgroundLocation))
                {
                    try
                    {
                        _BackgroundImage = Bitmap.FromFile(BackgroundLocation);
                    }
                    catch (System.IO.IOException)
                    { }
                    catch (ArgumentException)
                    { }
                    catch (UnauthorizedAccessException)
                    { }
                    catch (OutOfMemoryException)
                    { }
                }

                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            CloseTimer.Stop();
            MoveTimer.Stop();
        }

        private double _OpacityValue;
        public double OpacityValue
        {
            get
            {
                if (UseOpacity)
                {
                    return Opacity;
                }
                else
                {
                    if (_OpacityValue < 0)
                        return 0;
                    else if (_OpacityValue > 1)
                        return 1;

                    return _OpacityValue;
                }
            }
            set
            {
                _OpacityValue = value;
                if (UseOpacity)
                    Opacity = value;
            }
        }

        public bool UseOpacity = true;

        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            OpacityValue += OpacityStep;
            if (Location.Y > Screen.PrimaryScreen.WorkingArea.Height - Height)
            {
                Location = new Point(Location.X, Location.Y - 2);
            }
            else
            {
                if (OpacityValue == 1.0)
                {
                    MoveTimer.Stop();
                    CloseTimer.Start();
                }
            }
        }

        private void CloseTimer_Tick(object sender, EventArgs e)
        {
            if (Bounds.Contains(Cursor.Position))
                return;

            CloseTimer.Interval = MoveTimer.Interval / 2;

            if (OpacityValue == 0)
                Close();
            else
                OpacityValue -= OpacityStep;

            MessageLabel.Refresh();
        }

        // Dùng Regular Expression để kiểm tra có phải là 1 liên kết?
        private static readonly System.Text.RegularExpressions.Regex A = new System.Text.RegularExpressions.Regex(
            "\\<a\\W+href=\"(?<href>[^\"]*)\"\\W*\\>(?<text>[^\\<]*)\\</a\\>", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Multiline);
        private void SetupText()
        {
            string msg = Message ?? string.Empty;

            var matches = A.Matches(msg);
            if (matches == null || matches.Count == 0)
            {
                MessageLabel.Text = msg;                
                MessageLabel.LinkArea = new LinkArea(msg.Length, 0);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                int last_index = 0;
                foreach (System.Text.RegularExpressions.Match match in matches)
                {
                    var href = match.Groups["href"].Value;
                    var text = match.Groups["text"].Value;

                    sb.Append(msg, last_index, match.Index - last_index);
                    MessageLabel.Links.Add(new LinkLabel.Link(sb.Length, text.Length) { LinkData = href });
                    sb.Append(text);
                    last_index = match.Index + match.Length;
                }
                if (last_index < msg.Length)
                    sb.Append(msg.Substring(last_index));

                MessageLabel.Text = sb.ToString();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!UseOpacity)
                Opacity = 1;

            SetupText();

            Width = 400;
            Height = 100;

            OpacityStep = (float)(((float)SystemInformation.WorkingArea.Height / (float)SystemInformation.VirtualScreen.Height) / 10.0);

            MoveTimer.Start();

            Play(SoundLocation);
        }

        private static void Play(string SoundLocation)
        {
            if (string.IsNullOrEmpty(SoundLocation))
                return;

            try
            {
                System.Media.SoundPlayer Player = new System.Media.SoundPlayer();
                Player.SoundLocation = SoundLocation;
                Player.Play();
            }
            catch (System.IO.IOException)
            { }
            catch (UnauthorizedAccessException)
            { }
            catch (InvalidOperationException)
            { }
            catch (System.ServiceProcess.TimeoutException)
            { }
        }

        private void TrayBalloonFrm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (LightWeight)
            {
                LinearGradientBrush lgb = new LinearGradientBrush(
                    ClientRectangle, SystemColors.MenuHighlight, Color.LightBlue, 90);
                e.Graphics.FillRectangle(lgb, ClientRectangle);
                e.Graphics.DrawRectangle(new Pen(Color.White, 3), ClientRectangle);
                e.Graphics.DrawRectangle(new Pen(SystemColors.MenuHighlight, 1), ClientRectangle);
            }
        }

        public const int WM_NCCALCSIZE = 0x83;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCCALCSIZE)
            { return; }
            base.WndProc(ref m);
        }

        private void MessageLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Link == null)
                return;

            var Link = e.Link.LinkData as string;

            if (string.IsNullOrEmpty(Link))
                return;

            try
            {
                var psi = new System.Diagnostics.ProcessStartInfo();
                psi.UseShellExecute = true;
                psi.FileName = Link;
                System.Diagnostics.Process.Start(Link);
            }
            catch (System.IO.IOException)
            { }
            catch (InvalidOperationException)
            { }
            catch (ArgumentException)
            { }
            catch (System.ComponentModel.Win32Exception)
            { }
        }
    }
}