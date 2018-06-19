using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lan_Messenger
{
    public partial class FormChangeDisplayName : Form
    {
        public FormChangeDisplayName()
        {
            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
                MessageBox.Show("Display name NOT NULL,...", "Error!");
            else
            {
                Global.server.ChangeDisplayName(Global.username, txtName.Text);
                MessageBox.Show("Tên hiển thị của bạn đã được thay đổi thành công. Vui lòng đăng nhập trở lại để thấy sự thay đổi");
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormChangeDisplayName_Load(object sender, EventArgs e)
        {
            lblusername.Text += Global.username;
        }
    }
}
