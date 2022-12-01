using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tankgame
{
    class PlayerTank : Tank
    {
        public int killCount = 0;

        public PlayerTank(int x, int y) : base(x, y)
        {
            icon.Add(new Icon('▲', ConsoleColor.Green, ConsoleColor.DarkGreen));
            icon.Add(new Icon('►', ConsoleColor.Green, ConsoleColor.DarkGreen));
            icon.Add(new Icon('▼', ConsoleColor.Green, ConsoleColor.DarkGreen));
            icon.Add(new Icon('◄', ConsoleColor.Green, ConsoleColor.DarkGreen));
            direction = Globals.Direction.Up;
        }

        public void Act(ConsoleKeyInfo key)
        {
            switch (key.KeyChar)
            {
                case 'w':
                    if (Globals.ticks - moveTime > Globals.MOVE_SPEED / 3) // TO TANK
                    {
                        moveTime = Globals.ticks;
                        Step(Globals.Direction.Up);
                    }

                    break;
                case 'd':
                    if (Globals.ticks - moveTime > Globals.MOVE_SPEED / 3)  // TO TANK
                    {
                        moveTime = Globals.ticks;
                        Step(Globals.Direction.Right);
                    }
                    break;
                case 's':
                    if (Globals.ticks - moveTime > Globals.MOVE_SPEED / 3)
                    {
                        moveTime = Globals.ticks;
                        Step(Globals.Direction.Down);
                    }
                    break;
                case 'a':
                    if (Globals.ticks - moveTime > Globals.MOVE_SPEED / 3)
                    {
                        moveTime = Globals.ticks;
                        Step(Globals.Direction.Left);
                    }
                    break;
                case 'x':
                    Shot();
                    break;
                default:
                    break;
            }
        }
    }
}
