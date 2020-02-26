using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Tank : Entities
    {
        public Tank(int sizeX, int sizeY)
        {
            this.img = new Bitmap(@"..\..\img\tank.png");
            Random rnd = new Random();
            size = 60;
            this.x = rnd.Next(6, sizeX + 4 - size);
            this.y = rnd.Next(6, sizeY + 4 - size);
            direction = Direction.UP;
        }

        public void TankShooting(Bullet bullet, bool bulletDisappeared)
        {
            if (bulletDisappeared)
            {
                bullet.x = x + size / 2 - bullet.size / 2;
                bullet.y = y + size / 2 - bullet.size / 2;
                bullet.direction = direction;
            }
        }
    }
}
