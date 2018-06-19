using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace LanMessengerCaro
{
    public class Player
    {
        private String name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private Image mark;

        public Image Mark
        {
            get { return mark; }
            set { mark = value; }
        }

        public Player(string name, Image mark)
        {
            this.name = name;
            this.mark = mark;
        }
    }
}
