namespace Lan_Messenger
{
    partial class FormCaro
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlChessBoard = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.prcbCoolDown = new System.Windows.Forms.ProgressBar();
            this.tmCountDown = new System.Windows.Forms.Timer(this.components);
            this.lblLuotDanh = new System.Windows.Forms.Label();
            this.pctbMark = new System.Windows.Forms.PictureBox();
            this.pctbAvatar = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(880, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.fileToolStripMenuItem.Text = "Menu";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // pnlChessBoard
            // 
            this.pnlChessBoard.Location = new System.Drawing.Point(12, 27);
            this.pnlChessBoard.Name = "pnlChessBoard";
            this.pnlChessBoard.Size = new System.Drawing.Size(570, 570);
            this.pnlChessBoard.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pctbAvatar);
            this.panel2.Location = new System.Drawing.Point(589, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 280);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblLuotDanh);
            this.panel3.Controls.Add(this.prcbCoolDown);
            this.panel3.Controls.Add(this.pctbMark);
            this.panel3.Location = new System.Drawing.Point(589, 317);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(280, 280);
            this.panel3.TabIndex = 4;
            // 
            // prcbCoolDown
            // 
            this.prcbCoolDown.Location = new System.Drawing.Point(5, 77);
            this.prcbCoolDown.Name = "prcbCoolDown";
            this.prcbCoolDown.Size = new System.Drawing.Size(270, 29);
            this.prcbCoolDown.TabIndex = 2;
            // 
            // tmCountDown
            // 
            this.tmCountDown.Tick += new System.EventHandler(this.tmCountDown_Tick);
            // 
            // lblLuotDanh
            // 
            this.lblLuotDanh.AutoSize = true;
            this.lblLuotDanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLuotDanh.Location = new System.Drawing.Point(3, 34);
            this.lblLuotDanh.Name = "lblLuotDanh";
            this.lblLuotDanh.Size = new System.Drawing.Size(192, 31);
            this.lblLuotDanh.TabIndex = 3;
            this.lblLuotDanh.Text = "Lượt đánh của ";
            // 
            // pctbMark
            // 
            this.pctbMark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctbMark.Location = new System.Drawing.Point(91, 121);
            this.pctbMark.Name = "pctbMark";
            this.pctbMark.Size = new System.Drawing.Size(100, 100);
            this.pctbMark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctbMark.TabIndex = 0;
            this.pctbMark.TabStop = false;
            // 
            // pctbAvatar
            // 
            this.pctbAvatar.Image = global::Lan_Messenger.Properties.Resources.logo;
            this.pctbAvatar.Location = new System.Drawing.Point(4, 4);
            this.pctbAvatar.Name = "pctbAvatar";
            this.pctbAvatar.Size = new System.Drawing.Size(273, 273);
            this.pctbAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctbAvatar.TabIndex = 0;
            this.pctbAvatar.TabStop = false;
            // 
            // FormCaro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 607);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlChessBoard);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormCaro";
            this.Text = "Chơi Caro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCaro_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Panel pnlChessBoard;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pctbAvatar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pctbMark;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ProgressBar prcbCoolDown;
        private System.Windows.Forms.Timer tmCountDown;
        private System.Windows.Forms.Label lblLuotDanh;
    }
}