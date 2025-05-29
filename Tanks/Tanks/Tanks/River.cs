using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class River : FixedEntities
    {
        public River(int sizeX, int sizeY)
        {
            this.img = new Bitmap(@"..\..\img\water.png");
            Random rnd = new Random();
            size = 60;
            this.x = rnd.Next(6, sizeX + 4 - size);
            this.y = rnd.Next(6, sizeY + 4 - size);
        }
    }
}
