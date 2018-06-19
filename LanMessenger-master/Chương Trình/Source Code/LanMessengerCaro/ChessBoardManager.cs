using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LanMessengerCaro
{
    public class ChessBoardManager
    {
        #region Properties
        int chessBoardWidth;

        public int ChessBoardWidth
        {
            get { return chessBoardWidth; } 
            set { chessBoardWidth = value; }
        }

        int chessBoardHeight;

        public int ChessBoardHeight
        {
            get { return chessBoardHeight; } 
            set { chessBoardHeight = value; }
        }

        private List<Player> player;

        public List<Player> Player
        {
            get { return player; }
            set { player = value; }
        }

        private Panel chessBoard;

        public Panel ChessBoard
        {
            get { return chessBoard; }
            set { chessBoard = value; }
        }

        PictureBox mark;

        public PictureBox Mark
        {
            get { return mark; } 
            set { mark = value; }
        }

        Label turn;

        public Label Turn
        {
            get { return turn; } 
            set { turn = value; }
        }

        private int currentPlayer;

        public int CurrentPlayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; }
        }

        private string winnerName;

        public string WinnerName
        {
            get { return winnerName; } 
            set { winnerName = value; }
        }

        List<List<Button>> matrix;

        public List<List<Button>> Matrix
        {
            get { return matrix; } 
            set { matrix = value; }
        }

        private event EventHandler<ButtonClickedEvent> playerMarked;
        public event EventHandler<ButtonClickedEvent> PlayerMarked
        {
            add
            {
                playerMarked += value;
            }
            remove
            {
                playerMarked -= value;
            }
        }

        private event EventHandler endedGame;
        public event EventHandler EndedGame
        {
            add
            {
                endedGame += value;
            }
            remove
            {
                endedGame -= value;
            }
        }
        #endregion

        #region Initialize
        public ChessBoardManager(Panel chessBoard, PictureBox mark, Label turn)
        {
            this.chessBoard = chessBoard;
            this.turn = turn;
            this.mark = mark;
            this.player = new List<Player>()
            {
                new Player("player1", Image.FromFile(Application.StartupPath + "\\Resources\\X.png")),
                new Player("player2", Image.FromFile(Application.StartupPath + "\\Resources\\O.png"))
            };
            chessBoardWidth = chessBoard.Width / Cons.CHESS_WIDTH;
            chessBoardHeight = chessBoard.Height / Cons.CHESS_HEIGHT;
            currentPlayer = 0;
            ChangePlayer();
        }
        #endregion

        #region Methods
        public void DrawChessBoard()
        {
            chessBoard.Enabled = true;
            chessBoard.Controls.Clear();
            Matrix = new List<List<Button>>();
            Button preButton = new Button()
            {
                Width = 0,
                Height = 0,
                Location = new Point(0, 0)
            };
            for (int i = 0; i < chessBoardWidth; i++)
            {
                Matrix.Add(new List<Button>());
                for (int j = 0; j <= chessBoardHeight; j++)
                {
                    Button newButton = new Button()
                    {
                        Width = Cons.CHESS_WIDTH,
                        Height = Cons.CHESS_HEIGHT,
                        Location = new Point(preButton.Location.X + preButton.Width, preButton.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = i.ToString()
                };
                    newButton.Click += NewButton_Click;
                    ChessBoard.Controls.Add(newButton);
                    Matrix[i].Add(newButton);
                    preButton = newButton;
                }
                preButton.Width = 0;
                preButton.Height = 0;
                preButton.Location = new Point(0, preButton.Location.Y + Cons.CHESS_HEIGHT);
            }
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackgroundImage != null)
                return;
            ShowMark(btn);
            ChangePlayer();
            chessBoard.Enabled = false;
            if (playerMarked != null)
                playerMarked(this, new ButtonClickedEvent(GetChessPoint(btn)));
            if (IsEndGame(btn))
                EndGame();
        }

        public void OtherPlayerMark(Point point)
        {
            chessBoard.Enabled = true;
            Button btn = Matrix[point.Y][point.X];
            if (btn.BackgroundImage != null)
                return;
            ShowMark(btn);
            ChangePlayer();
            if (IsEndGame(btn))
                EndGame();
        }

        private void EndGame()
        {
            if (endedGame != null)
                endedGame(this, new EventArgs());
        }

        private bool IsEndGame(Button btn)
        {
            winnerName = player[currentPlayer].Name;
            return IsEndGameHorizontal(btn) || IsEndGameVertical(btn) || IsEndGamePrimaryDiagnosis(btn) || IsEndGameSubDiagnosis(btn);
        }

        private Point GetChessPoint(Button btn)
        {
            int vertical = Convert.ToInt32(btn.Tag);
            int horizontal = Matrix[vertical].IndexOf(btn);

            Point point = new Point(horizontal, vertical);

            return point;
        }

        private bool IsEndGameHorizontal(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countLeft = 0;
            for (int i = point.X; i >= 0; i--)
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countLeft++;
                }
                else
                    break;
            }

            int countRight = 0;
            for (int i = point.X + 1; i < ChessBoardWidth; i++)
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countRight++;
                }
                else
                    break;
            }

            return countLeft + countRight == Cons.WIN_CHESS_NUM;
        }

        private bool IsEndGameVertical(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countTop = 0;
            for (int i = point.Y; i >= 0; i--)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;
            }

            int countBottom = 0;
            for (int i = point.Y + 1; i < ChessBoardHeight; i++)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else
                    break;
            }

            return countTop + countBottom == Cons.WIN_CHESS_NUM;
        }

        private bool IsEndGamePrimaryDiagnosis(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countTop = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X - i < 0 || point.Y - i < 0)
                    break;

                if (Matrix[point.Y - i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;
            }

            int countBottom = 0;
            for (int i = 1; i <= ChessBoardWidth - point.X; i++)
            {
                if (point.Y + i >= ChessBoardHeight || point.X + i >= ChessBoardWidth)
                    break;

                if (Matrix[point.Y + i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else
                    break;
            }

            return countTop + countBottom == Cons.WIN_CHESS_NUM;
        }

        private bool IsEndGameSubDiagnosis(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countTop = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X + i > ChessBoardWidth || point.Y - i < 0)
                    break;

                if (Matrix[point.Y - i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;
            }

            int countBottom = 0;
            for (int i = 1; i <= ChessBoardWidth - point.X; i++)
            {
                if (point.Y + i >= ChessBoardHeight || point.X - i < 0)
                    break;

                if (Matrix[point.Y + i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else
                    break;
            }

            return countTop + countBottom == Cons.WIN_CHESS_NUM;
        }

        private void ShowMark(Button btn)
        {
            btn.BackgroundImage = player[currentPlayer].Mark;
            currentPlayer = currentPlayer == 1 ? 0 : 1;
        }

        private void ChangePlayer()
        {
            turn.Text = "Lượt đi của " + player[currentPlayer].Name;
            mark.Image = player[currentPlayer].Mark;
        }
        #endregion
    }

   public class ButtonClickedEvent : EventArgs
    {
        private Point clickedPoint;

        public Point ClickedPoint {
            get { return clickedPoint; } 
            set { clickedPoint = value; }
        }

        public ButtonClickedEvent(Point point)
        {
            this.clickedPoint = point;
        }
    }
}
