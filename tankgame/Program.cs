using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace tankgame
{
    class Program
    {

        static void Main(string[] args)
        {
            Game game = new Game();
            Globals.Msg(15, "GAME OVER");
            Thread.Sleep(50000);
        }
    }
}
