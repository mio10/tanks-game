using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tankgame
{
    class EnemyBullet : Bullet
    {
        public EnemyBullet(int x, int y, Globals.Direction dir) : base(x, y, dir) {

        }
    }
}
