namespace Lan_Messenger
{
    partial class FormChatRoom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChatRoom));
            this.txtAllChat = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtChatHere = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cbbListContact = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAllChat
            // 
            this.txtAllChat.BackColor = System.Drawing.Color.White;
            this.txtAllChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAllChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAllChat.Location = new System.Drawing.Point(12, 35);
            this.txtAllChat.Name = "txtAllChat";
            this.txtAllChat.ReadOnly = true;
            this.txtAllChat.Size = new System.Drawing.Size(269, 323);
            this.txtAllChat.TabIndex = 3;
            this.txtAllChat.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.Location = new System.Drawing.Point(240, 3);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(47, 36);
            this.btnSend.TabIndex = 1;
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtChatHere
            // 
            this.txtChatHere.BackColor = System.Drawing.Color.White;
            this.txtChatHere.Location = new System.Drawing.Point(12, 3);
            this.txtChatHere.Multiline = true;
            this.txtChatHere.Name = "txtChatHere";
            this.txtChatHere.Size = new System.Drawing.Size(222, 36);
            this.txtChatHere.TabIndex = 0;
            this.txtChatHere.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChatHere_KeyDown);
            this.txtChatHere.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtChatHere_KeyUp);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cbbListContact
            // 
            this.cbbListContact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbListContact.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbListContact.FormattingEnabled = true;
            this.cbbListContact.Location = new System.Drawing.Point(160, 6);
            this.cbbListContact.Name = "cbbListContact";
            this.cbbListContact.Size = new System.Drawing.Size(121, 23);
            this.cbbListContact.TabIndex = 5;
            this.cbbListContact.SelectedIndexChanged += new System.EventHandler(this.cbbListContact_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtChatHere);
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 372);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 43);
            this.panel1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(130, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.bunifuSeparator1.LineThickness = 2;
            this.bunifuSeparator1.Location = new System.Drawing.Point(3, 364);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(284, 2);
            this.bunifuSeparator1.TabIndex = 14;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // FormChatRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(293, 415);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtAllChat);
            this.Controls.Add(this.cbbListContact);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormChatRoom";
            this.ShowIcon = false;
            this.Text = "Group";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormChatRoom_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtAllChat;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtChatHere;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cbbListContact;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
    }
}