using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tankgame
{
    class Icon
    {
        public char icon;
        public ConsoleColor color;
        public ConsoleColor background;

        public Icon()
        {
            icon = ' ';
            color = ConsoleColor.Black;
            background = ConsoleColor.Black;
        }

        public Icon(char icon, ConsoleColor color, ConsoleColor background)
        {
            this.icon = icon;
            this.color = color;
            this.background = background;
        }
    }
}
