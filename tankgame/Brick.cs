using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tankgame
{
    class Brick : Entity
    {
        public Brick(int x, int y)
        {
            this.x = x;
            this.y = y;
            icon.Add(new Icon(' ', ConsoleColor.Black, ConsoleColor.Red));
        }
        /*
        public void Destroy()
        {
            for (int i = 0; i < Globals.roomObjects.Count; i++)
            {

                if (Globals.roomObjects[i] == this)
                {
                    int oldx, oldy;
                    oldx = x;
                    oldy = y;

                    if (Globals.CellEmpty(oldx, oldy))
                    {
                        EmptyCell empty = new EmptyCell(x, y);
                        empty.Draw(0);
                    }
                }
            }

        }*/
    }
}
