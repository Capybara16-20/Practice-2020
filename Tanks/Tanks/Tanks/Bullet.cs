using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    class Bullet : Entities
    {
        public Bullet(Image img)
        {
            this.img = img;
            this.x = -20;
            this.y = -20;
            size = 20;
        }
    }
}
