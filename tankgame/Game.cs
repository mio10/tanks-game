using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace tankgame
{
    class Game
    {
        public Game()
        {
            
            Console.CursorVisible = false;
            Console.ResetColor();

            Globals.roomObjects.Add(new PlayerTank(10, 10));
            Globals.roomObjects[0].Draw(0);

            Brick b1 = new Brick(2, 3);
            Brick b2 = new Brick(5, 4);
            Brick b3 = new Brick(9, 11);
            List<Entity> bricks = new List<Entity>();
            bricks.Add(b1);
            bricks.Add(b2);
            bricks.Add(b3);
            DrawBorders();
            DrawAllList(bricks);

            Globals.roomObjects = Globals.roomObjects.Concat(bricks).ToList();

            Globals.roomObjects.Add(new EnemyTank(0, 0));

            while (!Globals.gameOver)
            {
                while (!Console.KeyAvailable)
                {
                    if (Globals.gameOver)
                        break;
                    
                    Thread.Sleep(20);
                    Globals.ticks++;
                    
                    if (Globals.ticks % 5 == 0)
                        BulletsFly();

                    if (Globals.ticks % 200 == 0)
                        Globals.roomObjects.Add(new EnemyTank(Globals.rand.Next(0, 12), 0));

                    EnemiesStep();
                    EnemiesShoot();
                    
                }

                if (Globals.gameOver)
                    break;

                ConsoleKeyInfo key = new ConsoleKeyInfo();
                key = Console.ReadKey(true);
                (Globals.roomObjects[0] as PlayerTank).Act(key);
                
            }

        }

        private void EnemiesStep()
        {
            int enemyTankCount = 0;
            for (int i = 0; i < Globals.roomObjects.Count; i++)
            {
                if (Globals.roomObjects[i] is EnemyTank)
                {
                    enemyTankCount++;
                    (Globals.roomObjects[i] as EnemyTank).Step();

                }
            }
            Globals.Msg(4, "Alive: " + enemyTankCount.ToString());
        }

        private void EnemiesShoot()
        {
            
            for (int i = 0; i < Globals.roomObjects.Count; i++)
            {
                if (Globals.roomObjects[i] is EnemyTank)
                {
                    
                    (Globals.roomObjects[i] as EnemyTank).Shot();

                }
            }
            
        }

        private void BulletsFly()
        {
            
            for (int i = 0; i < Globals.roomObjects.Count; i++)
            {
                if (Globals.roomObjects[i] is Bullet)
                {
                    
                    (Globals.roomObjects[i] as Bullet).Step();
                    
                }
            }
            
        }

        private void DrawAllList(List<Entity> objects)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].Draw();
            }
        }
        
        private void DrawBorders()
        {
            for (int i = 0; i <= Globals.FIELD_SIZE; i++)
            {
                Console.SetCursorPosition(13, i);
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(' ');
            }
            for (int i = 0; i < Globals.FIELD_SIZE; i++)
            {
                Console.SetCursorPosition(i, 13);
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(' ');
            }
        }

    }
}
