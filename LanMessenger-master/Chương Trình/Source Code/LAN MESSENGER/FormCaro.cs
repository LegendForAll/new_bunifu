using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanMessengerCaro;
using System.Net.NetworkInformation;
using System.Threading;

namespace Lan_Messenger
{
    public partial class FormCaro : Form
    {
        ChessBoardManager chessBoard;
        SocketManager socket;
        bool isServer;

        public FormCaro(string playerName1, string playerName2, string IP, bool isServer)
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            chessBoard = new ChessBoardManager(pnlChessBoard, this.pctbMark, this.lblLuotDanh);
            chessBoard.EndedGame += ChessBoard_EndedGame;
            chessBoard.PlayerMarked += ChessBoard_PlayerMarked;

            prcbCoolDown.Step = Cons.COUNT_DOWN_STEP;
            prcbCoolDown.Maximum = Cons.COUNT_DOWN_TIME;
            prcbCoolDown.Value = 0;
            tmCountDown.Interval = Cons.COUNT_DOWN_INTERVAL;
            socket = new SocketManager();

            this.isServer = isServer;
            chessBoard.Player[0].Name = playerName1;
            chessBoard.Player[1].Name = playerName2;
            lblLuotDanh.Text = "Lượt đánh của " + playerName1;
            socket.IP = IP;

            NewGame();
            tmCountDown.Stop();

            Connect();
        }

        private void EndGame()
        {
            tmCountDown.Stop();
            pnlChessBoard.Enabled = false;
            MessageBox.Show("Người chơi " + chessBoard.WinnerName + " đã chiến thắng!");
        }

        private void NewGame()
        {            
            prcbCoolDown.Value = 0;
            tmCountDown.Stop();
            chessBoard.DrawChessBoard();
        }

        private void Undo()
        {

        }

        private void Quit()
        {
            this.Close();
        }

        private void ChessBoard_PlayerMarked(object sender, ButtonClickedEvent e)
        {
            tmCountDown.Start();
            prcbCoolDown.Value = 0;

            socket.Send(new SocketData((int)SocketCommand.SEND_POINT, "",e.ClickedPoint));
            Listen();
        }

        private void ChessBoard_EndedGame(object sender, EventArgs e)
        {
            EndGame();
        }

        private void tmCountDown_Tick(object sender, EventArgs e) 
        {
            prcbCoolDown.PerformStep();
            if (prcbCoolDown.Value >= prcbCoolDown.Maximum)
            {
                chessBoard.WinnerName = chessBoard.Player[chessBoard.CurrentPlayer == 0 ? 1 : 0].Name;
                EndGame();          
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to play a new game?", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                NewGame();
                socket.Send(new SocketData((int)SocketCommand.NEW_GAME, "", new Point()));
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }

        private void FormCaro_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                socket.Send(new SocketData((int)SocketCommand.QUIT, "", new Point(0, 0)));
            }
            catch
            {

            }
        }

        private void FormCaro_Shown(object sender, EventArgs e)
        {
            //
        }

        void Listen()
        {
            Thread listenThread = new Thread(() =>
            {
                try
                {
                    SocketData data = (SocketData)socket.Recieve();
                    ProcessData(data);
                }
                catch
                {

                }
            });
            listenThread.IsBackground = true;
            listenThread.Start();
        }

        private void ProcessData(SocketData data)
        {
            switch(data.Command)
            {
                case (int)SocketCommand.NEW_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        NewGame();
                        pnlChessBoard.Enabled = false;
                    })); 
                    break;
                case (int)SocketCommand.NOTIFY:
                    MessageBox.Show(data.Message);
                    break;
                case (int)SocketCommand.SEND_POINT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        pnlChessBoard.Enabled = true;
                        prcbCoolDown.Value = 0;
                        tmCountDown.Start();
                        chessBoard.OtherPlayerMark(data.Point);
                    }));
                    break;
                case (int)SocketCommand.QUIT:
                    tmCountDown.Stop();
                    MessageBox.Show("Đối thủ đã thoát!");
                    Close();
                    break;
                default:
                    break;
            }
            Listen();
        }

        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void Connect()
        {
            if (!socket.connectServer())
            {
                socket.isServer = true;
                pnlChessBoard.Enabled = true;
                socket.createServer();
            }
            else
            {
                socket.isServer = false;
                pnlChessBoard.Enabled = false;
                Listen();
            }
        }
    }
}
