using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tankgame
{
    class MovableObject : Entity
    {
        public Globals.Direction direction = new Globals.Direction();

        public Globals.Direction OppositeDirection()
        {
            switch (direction)
            {
                case Globals.Direction.Up:
                    return Globals.Direction.Down;
                case Globals.Direction.Right:
                    return Globals.Direction.Left;
                case Globals.Direction.Down:
                    return Globals.Direction.Up;
                case Globals.Direction.Left:
                    return Globals.Direction.Right;
                default:
                    break;
            }
            throw new Exception("OppositeDirection method error.");
        }

        protected Globals.Direction RandomDirection()
        {
            
            switch (Globals.rand.Next(1, 5))
            {
                case 1:
                    return Globals.Direction.Up;
                case 2:
                    return Globals.Direction.Right;
                case 3:
                    return Globals.Direction.Down;
                case 4:
                    return Globals.Direction.Left;
                default:
                    break;
            }
            return Globals.Direction.Up;
        }

        public Globals.CollisionType Collision(int x, int y, Globals.Direction dir)
        {
            for (int i = 0; i < Globals.roomObjects.Count; i++)
            {
                switch (dir)
                {
                    case Globals.Direction.Up:
                        if (Globals.roomObjects[i].GetY() == y - 1 && Globals.roomObjects[i].GetX() == x)
                        {
                            return Globals.RoomObjectCollisionType(i);
                        }
                        if (y < 1)
                            return Globals.CollisionType.Solid;
                        break;
                    case Globals.Direction.Right:
                        if (Globals.roomObjects[i].GetX() == x + 1 && Globals.roomObjects[i].GetY() == y)
                        {
                            return Globals.RoomObjectCollisionType(i);
                        }
                        if (x > Globals.FIELD_SIZE - 2)
                            return Globals.CollisionType.Solid;
                        break;
                    case Globals.Direction.Down:
                        if (Globals.roomObjects[i].GetY() == y + 1 && Globals.roomObjects[i].GetX() == x)
                        {
                            return Globals.RoomObjectCollisionType(i);
                        }
                        if (y > Globals.FIELD_SIZE - 2)
                            return Globals.CollisionType.Solid;
                        break;
                    case Globals.Direction.Left:
                        if (Globals.roomObjects[i].GetX() == x - 1 && Globals.roomObjects[i].GetY() == y)
                        {
                            return Globals.RoomObjectCollisionType(i);
                        }
                        if (x < 1)
                            return Globals.CollisionType.Solid;
                        break;
                    default:
                        break;
                }
            }
            return Globals.CollisionType.NoCollision;
        }

        public Globals.CollisionType Collision(int x, int y, Globals.Direction dir, Globals.CollisionType interestingType)
        {
            for (int i = 0; i < Globals.roomObjects.Count; i++)
            {
                switch (interestingType) {
                    case Globals.CollisionType.Bullet:
                        if (Globals.roomObjects[i] is Bullet)
                            break;
                        else
                            continue;
                    case Globals.CollisionType.Tank:
                        if (Globals.roomObjects[i] is Tank)
                            break;
                        else
                            continue;
                    default:
                        break;
                }

                switch (dir)
                {
                    case Globals.Direction.Up:
                        if (Globals.roomObjects[i].GetY() == y - 1 && Globals.roomObjects[i].GetX() == x)
                        {
                            return Globals.RoomObjectCollisionType(i);
                        }
                        if (y < 1)
                            return Globals.CollisionType.Solid;
                        break;
                    case Globals.Direction.Right:
                        if (Globals.roomObjects[i].GetX() == x + 1 && Globals.roomObjects[i].GetY() == y)
                        {
                            return Globals.RoomObjectCollisionType(i);
                        }
                        if (x > Globals.FIELD_SIZE - 2)
                            return Globals.CollisionType.Solid;
                        break;
                    case Globals.Direction.Down:
                        if (Globals.roomObjects[i].GetY() == y + 1 && Globals.roomObjects[i].GetX() == x)
                        {
                            return Globals.RoomObjectCollisionType(i);
                        }
                        if (y > Globals.FIELD_SIZE - 2)
                            return Globals.CollisionType.Solid;
                        break;
                    case Globals.Direction.Left:
                        if (Globals.roomObjects[i].GetX() == x - 1 && Globals.roomObjects[i].GetY() == y)
                        {
                            return Globals.RoomObjectCollisionType(i);
                        }
                        if (x < 1)
                            return Globals.CollisionType.Solid;
                        break;
                    default:
                        break;
                }
            }

            return Globals.CollisionType.NoCollision;
        }


    }


}
