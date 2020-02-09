using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public static class Colides
    {
        public static bool Collides(int x1, int y1, int w1, int h1, int x2, int y2, int w2, int h2)
        {
            Rectangle rect1 = new Rectangle(x1, y1, w1, h1);
            Rectangle rect2 = new Rectangle(x2, y2, w2, h2);
            return rect1.IntersectsWith(rect2);
        }

    }
}
