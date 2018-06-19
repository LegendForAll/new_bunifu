using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Lan_Messenger
{
    public partial class FormLogsReader : Form
    {
        public FormLogsReader()
        {
            InitializeComponent();
            InitializeListView(); // Khởi tạo giao diện lvMessage
        }

        public void InitializeListView()
        {
            ColumnHeader header1 = this.lvListMessage.Columns.Add("Tên", 27 * Convert.ToInt32(lvListMessage.Font.SizeInPoints), HorizontalAlignment.Center);
            ColumnHeader header2 = this.lvListMessage.Columns.Add("Thời gian", 20 * Convert.ToInt32(lvListMessage.Font.SizeInPoints), HorizontalAlignment.Center);
        }
        string path = "logs/" + Global.username + "/"; // đường dẫn mặc định
        string[] listContact;
        string[] listFile;

        private void FormLogsReader_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(path))
            {
                listContact = Directory.GetDirectories(path);
                List<string> items = new List<string>();
                for (int i = 0; i < listContact.Length; i++)
                {
                    items.Add(GetFolderContact(listContact[i])); // Đưa tên tất cả contact vào 1 list
                }
                lbListContact.DataSource = items; // Gán dữ liệu cho listbox
            }
            else
            {
                btnDelete.Enabled = false;
            }
        }

        // Lọc tên của folder Contact
        private string GetFolderContact(string path)
        {
            string name;
            int index = path.IndexOf("/", 5) + 1; // Số 5 là vị trí bắt đầu của tên người dùng. vd: logs/a
            name = path.Substring(index, path.Length - index); // Cắt ra tên Contact trong path
            return name;
        }

        // Lọc tên file logs chat của 1 Contact xác định
        private string GetFileContact(string path)
        {            
            string pattern = "[0-9]+.dat";
            Regex filename = new Regex(pattern);
            Match m = filename.Match(path);
            if (m.Success)
            {
                return m.Value;
            }
            return "";
        }

        // Lấy ngày tháng từ tên file
        private string FileNametoTime(string name)
        {
            string s;
            s = name;
            s = s.Insert(2, "/");
            s = s.Insert(5, "/");
            s = s.Substring(0, s.Length - 4);
            return s;
        }
        
        // Sự kiện khi chọn 1 đối tượng trên lbListContact
        private void lbListContact_SelectedValueChanged(object sender,EventArgs e)
        {            
            lvListMessage.Clear();
            InitializeListView();
            listFile = Directory.GetFiles(path + lbListContact.SelectedItem.ToString());
            for (int i = 0; i < listFile.Length; i++)
            {
                AddItemstoListView(lbListContact.SelectedItem.ToString(), FileNametoTime(GetFileContact(listFile[i])));
            }
            rtbLogMessage.Clear();
        }

        // Hàm đưa các Item vào Listview
        private void AddItemstoListView(string Contact, string time)
        {            
            int n = this.lvListMessage.Items.Count;
            this.lvListMessage.Items.Add(Contact);
            this.lvListMessage.Items[n].SubItems.Add(time);
        }

        // Sự kiện khi chọn 1 đối tượng trong lvListMessage
        private void lvListMessage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;
            if (this.lvListMessage.SelectedItems.Count > 0)
                index = this.lvListMessage.SelectedIndices[0]; // Lấy stt của 1 Items trên lvMessage
                        
            FileStream fs = new FileStream(listFile[index],FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            rtbLogMessage.Clear();
            rtbLogMessage.AppendText(sr.ReadToEnd());
            fs.Close();           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Bạn chắc chắn muốn xóa log Chat này", "Xóa log chat...", MessageBoxButtons.YesNo))
            { 
                case DialogResult.Yes:
                    for (int i = 0; i < lvListMessage.Items.Count; i++)
                    {
                        if (lvListMessage.Items[i].Checked)
                        {
                            lvListMessage.Items[i].Remove();
                            File.Delete(listFile[i]);
                            i--; // Sau khi xóa thì chỉ sụt 1 chỉ số phòng trường hợp xóa 2 ô liên tiếp (tick 2 ô).
                            listFile = Directory.GetFiles(path + lbListContact.SelectedItem.ToString()); // Cập nhật lại listfile
                            rtbLogMessage.Clear();
                        }
                    }
                    break;
                case DialogResult.No:
                    this.DialogResult = DialogResult.None;
                    break;                    
            }            
        }

        private void lvMessage_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Checked == true || lvListMessage.CheckedItems.Count > 0)
                btnDelete.Enabled = true;
            else
                btnDelete.Enabled = false;            
        }        
    }
}
