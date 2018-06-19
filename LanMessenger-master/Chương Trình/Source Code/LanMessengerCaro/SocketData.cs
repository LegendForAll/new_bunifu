using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace LanMessengerCaro
{
    [Serializable]
    public class SocketData
    {
        private int command;

        public int Command
        {
            get { return command; } 
            set { command = value; }
        }

        private Point point;

        public Point Point
        {
            get { return point; }
            set { point = value; }
        }

        public string Message
        {
            get { return message; } 
            set { message = value; }
        }

        private string message;

        public SocketData(int command, string message, Point point)
        {
            this.command = command;
            this.message = message;
            this.point = point;
        }
    }

    public enum SocketCommand
    {
        SEND_POINT,
        NOTIFY,
        NEW_GAME,
        UNDO,
        QUIT,
        END_GAME
    }
}
