using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tankgame
{
    static class Globals
    {
        public enum Direction
        {
            Up,
            Right,
            Down,
            Left
        }

        public enum CollisionType
        {
            NoCollision,
            Solid,
            Bullet,
            Tank
        }


        public static List<Entity> roomObjects = new List<Entity>();
        public static Random rand = new Random();
        public static long ticks = 0;
        public static bool gameOver = false;
        public static bool CellEmpty(int x, int y)
        {
            for (int i = 0; i < roomObjects.Count; i++)
            {
                if (roomObjects[i].GetX() == x && roomObjects[i].GetY() == y)
                    return false;
            }
            return true;
        }

        public static bool NoOthers(Entity obj)
        {
            return true;
        }

        public static CollisionType RoomObjectCollisionType(int numRoomObj)
        {
            if (Globals.roomObjects[numRoomObj] is Bullet)
                return Globals.CollisionType.Bullet;
            if (Globals.roomObjects[numRoomObj] is Brick)
                return Globals.CollisionType.Solid;
            if (Globals.roomObjects[numRoomObj] is Tank)
                return Globals.CollisionType.Tank;
            
            
            return CollisionType.NoCollision;
        }

        public static void Msg(int pos, string msg)
        {
            Console.ResetColor();
            Console.SetCursorPosition(15, pos);
            Console.Write("                                        ");
            Console.SetCursorPosition(15, pos);
            Console.Write(msg);
        }

        public static int FIELD_SIZE = 13;
        public static int SHOT_SPEED = 40;
        public static int MOVE_SPEED = 10;
    }
}
