using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tankgame
{
    class EmptyCell : Entity
    {
        public EmptyCell(int x, int y)
        {
            this.x = x;
            this.y = y;
            icon.Add(new Icon(' ', ConsoleColor.Black, ConsoleColor.Black));
        }

        
    }
}
