using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tankgame
{
    class Tank : MovableObject
    {
        public long shotTime;
        public long moveTime;

       

        public Globals.Direction GetDirection()
        {
            return direction;
        }

        public Tank()
        {
            throw new Exception("No tank coordinates.");
        }
        
        public Tank(int x, int y)
        {
            this.x = x;
            this.y = y;
            direction = Globals.Direction.Down;
        }

        public void Shot()
        {
            if (Globals.ticks - shotTime > Globals.SHOT_SPEED)
            {
                shotTime = Globals.ticks;
                Bullet bullet = new Bullet(x, y, direction);
                Globals.roomObjects.Add(bullet);
            }

            

        }

        protected void UpdateIcon()
        {
            switch (direction)
            {
                case Globals.Direction.Up:
                    numIcon = 0;
                    break;
                case Globals.Direction.Right:
                    numIcon = 1;
                    break;
                case Globals.Direction.Down:
                    numIcon = 2;
                    break;
                case Globals.Direction.Left:
                    numIcon = 3;
                    break;
                default:
                    throw new Exception("Tank icon updating error.");
            }
        }

        protected void SetDirection(Globals.Direction newDir)
        {
            direction = newDir;
        }

        public void Step(Globals.Direction dir)
        {

            EmptyCell empty = new EmptyCell(x, y);
            empty.Draw(0);
            SetDirection(dir);

            switch (dir)
            {
                case Globals.Direction.Up:
                    if (Collision(x, y, dir) == Globals.CollisionType.NoCollision)
                        y--;
                    break;
                case Globals.Direction.Right:
                    if (Collision(x, y, dir) == Globals.CollisionType.NoCollision)
                        x++;
                    break;
                case Globals.Direction.Down:
                    if (Collision(x, y, dir) == Globals.CollisionType.NoCollision)
                        y++;
                    break;
                case Globals.Direction.Left:
                    if (Collision(x, y, dir) == Globals.CollisionType.NoCollision)
                        x--;
                    break;
                default:
                    throw new Exception("Tank step error.");
            }
            UpdateIcon();
            this.Draw(numIcon);
        }
    }
}
