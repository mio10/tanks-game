using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tankgame
{
    class EnemyTank : Tank
    {
        public EnemyTank(int x, int y) : base(x, y)
        {
            icon.Add(new Icon('▲', ConsoleColor.Gray, ConsoleColor.DarkGray));
            icon.Add(new Icon('►', ConsoleColor.Gray, ConsoleColor.DarkGray));
            icon.Add(new Icon('▼', ConsoleColor.Gray, ConsoleColor.DarkGray));
            icon.Add(new Icon('◄', ConsoleColor.Gray, ConsoleColor.DarkGray));
            direction = Globals.Direction.Up;
            Draw(3);
            moveTime = Globals.ticks;
        }

        public void Shot()
        {
            if (Globals.ticks - shotTime > Globals.SHOT_SPEED * 2)
            {
                shotTime = Globals.ticks;
                EnemyBullet bullet = new EnemyBullet(x, y, direction);
                Globals.roomObjects.Add(bullet);
            }
        }

        public void Step()
        {
            if (Globals.ticks - moveTime > Globals.MOVE_SPEED * 3)
            {
                moveTime = Globals.ticks;

                Globals.Direction dir;
                if (Globals.rand.Next(1, 3) == 1)
                    dir = RandomDirection();
                else
                {
                    if (Collision(x, y, direction) != Globals.CollisionType.NoCollision)
                        dir = RandomDirection();
                    else
                        dir = direction;
                }
                    

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
}
