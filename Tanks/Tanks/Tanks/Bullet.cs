using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Bullet : Entities
    {
        public Bullet(Image img)
        {
            this.img = img;
            this.x = -20;
            this.y = -20;
            size = 20;
        }

        public bool BulletDisappearance(int sizeX, int sizeY)
        {
            return ((x > sizeX + 10) || (x < -20) || (y < -20) || (y > sizeY + 10));
        }
    }
}
