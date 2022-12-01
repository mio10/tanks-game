using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tankgame
{
    abstract class Entity
    {
        protected int x, y;
        protected List<Icon> icon = new List<Icon>();
        protected int numIcon = 0;

        public void Destroy()
        {
            for (int i = 0; i < Globals.roomObjects.Count; i++)
            {
                if (Globals.roomObjects[i] == this)
                {
                    int oldx, oldy;
                    oldx = x;
                    oldy = y;

                    if (this is EnemyTank)
                    {
                        (Globals.roomObjects[0] as PlayerTank).killCount++;
                        Globals.Msg(2, "Kills: " + (Globals.roomObjects[0] as PlayerTank).killCount.ToString());
                    }

                    if (!(this is PlayerTank))
                        Globals.roomObjects.Remove(this);
                    else
                        Globals.gameOver = true;

                    if (Globals.CellEmpty(oldx, oldy))
                    {
                        EmptyCell empty = new EmptyCell(x, y);
                        empty.Draw(0);
                    }


                }
            }
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        protected bool Near(Entity obj) {
            if (Math.Abs(x - obj.x) <= 1 && Math.Abs(y - obj.y) <= 1)
                return true;
            return false;
        }

        public void Draw() {

           
            try
            {
                Console.ForegroundColor = icon[0].color;
                Console.BackgroundColor = icon[0].background;
                Console.SetCursorPosition(x, y);
                Console.Write(icon[0].icon);
            }
            catch
            {
                throw new Exception("Entity drawing error.");
            }
        }

        public void Draw(int numIcon)
        {

            

            try
            {
                Console.ForegroundColor = icon[numIcon].color;
                Console.BackgroundColor = icon[numIcon].background;
                Console.SetCursorPosition(x, y);
                Console.Write(icon[numIcon].icon);
            }
            catch
            {
                throw new Exception("Entity drawing error.");
            }
        }
    }
}
