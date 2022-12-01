using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tankgame
{
    class Bullet : MovableObject
    {
        protected int steps;
        
        public Bullet(int x, int y, Globals.Direction dir)
        {
            this.x = x;
            this.y = y;
            icon.Add(new Icon('.', ConsoleColor.White, ConsoleColor.Black));
            direction = dir;
            steps = 0;
        }

        public Entity CollisionObj(int x, int y, Globals.Direction dir)
        {
            for (int i = 0; i < Globals.roomObjects.Count; i++)
            {
                switch (dir)
                {
                    case Globals.Direction.Up:
                        if (Globals.roomObjects[i].GetY() == y - 1 && Globals.roomObjects[i].GetX() == x)
                        {
                            return Globals.roomObjects[i];
                        }
                        if (y < 1)
                            return new EmptyCell(x, y);
                        break;
                    case Globals.Direction.Right:
                        if (Globals.roomObjects[i].GetX() == x + 1 && Globals.roomObjects[i].GetY() == y)
                        {
                            return Globals.roomObjects[i];
                        }
                        if (x > Globals.FIELD_SIZE - 2)
                            return new EmptyCell(x, y);
                        break;
                    case Globals.Direction.Down:
                        if (Globals.roomObjects[i].GetY() == y + 1 && Globals.roomObjects[i].GetX() == x)
                        {
                            return Globals.roomObjects[i];
                        }
                        if (y > Globals.FIELD_SIZE - 2)
                            return new EmptyCell(x, y);
                        break;
                    case Globals.Direction.Left:
                        if (Globals.roomObjects[i].GetX() == x - 1 && Globals.roomObjects[i].GetY() == y)
                        {
                            return Globals.roomObjects[i];
                        }
                        if (x < 1)
                            return new EmptyCell(x, y);
                        break;
                    default:
                        break;
                }
            }
            return new EmptyCell(x, y);
        }


        public void Step() {
            
            if (Collision(x, y, direction) == Globals.CollisionType.Tank)
            {
                
                
                for (int i = 0; i < Globals.roomObjects.Count; i++)
                {
                    if (Globals.roomObjects[i] is Tank)
                    {
                        
                        if ((Globals.roomObjects[i] as Tank).Collision(Globals.roomObjects[i].GetX(), Globals.roomObjects[i].GetY(), OppositeDirection(), Globals.CollisionType.Bullet) == Globals.CollisionType.Bullet)
                        {
                            
                            if ((Globals.roomObjects[i] is PlayerTank && this is EnemyBullet) ||
                            (Globals.roomObjects[i] is EnemyTank && !(this is EnemyBullet)))
                            {
                                if (Globals.roomObjects[i] is PlayerTank && this is EnemyBullet)
                                {
                                    Globals.Msg(8, this.x + " " + this.y + " " + this.direction.ToString());
                                    Globals.Msg(9, Globals.roomObjects[i].GetX() + " " + Globals.roomObjects[i].GetY());
                                }

                                if (!(Globals.roomObjects[i] is PlayerTank))
                                    Globals.roomObjects[i].Destroy();
                                else
                                    if (Near(Globals.roomObjects[i]))
                                        Globals.roomObjects[i].Destroy();

                            }

                            Destroy();
                            return;
                            
                        }
                    }
                }
            }
            
            if (steps > 0)
            {
                EmptyCell empty = new EmptyCell(x, y);
                empty.Draw(0);
                    
            }
            steps++;
            switch (direction)
            {
                case Globals.Direction.Up:
                    if (Collision(x, y, direction) == Globals.CollisionType.NoCollision)
                        y--;
                    else
                    {
                        if (CollisionObj(x, y, direction) is Bullet)
                            CollisionObj(x, y, direction).Destroy();
                        Destroy();
                        return;
                    }
                    break;
                case Globals.Direction.Right:
                    if (Collision(x, y, direction) == Globals.CollisionType.NoCollision)
                        x++;
                    else
                    {
                        if (CollisionObj(x, y, direction) is Bullet)
                            CollisionObj(x, y, direction).Destroy();
                        Destroy();
                        return;
                    }
                    break;
                case Globals.Direction.Down:
                    if (Collision(x, y, direction) == Globals.CollisionType.NoCollision)
                        y++;
                    else
                    {
                        if (CollisionObj(x, y, direction) is Bullet)
                            CollisionObj(x, y, direction).Destroy();
                        Destroy();
                        return;
                    }
                    break;
                case Globals.Direction.Left:
                    if (Collision(x, y, direction) == Globals.CollisionType.NoCollision)
                        x--;
                    else
                    {
                        if (CollisionObj(x, y, direction) is Bullet)
                            CollisionObj(x, y, direction).Destroy();
                        Destroy();
                        return;
                    }
                    break;
                default:
                    throw new Exception("Bullet step error.");
            }
            Draw();
        }
    }
}
