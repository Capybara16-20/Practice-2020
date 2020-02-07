using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    class Tank
    {
        public int x;
        public int y;
        public int size;
        public Image tankImg;

        public Tank(int x, int y)
        {
            tankImg = new Bitmap(@"C:\Users\user\Desktop\Папка\EPAM\Внутренние курсы\Practice-2020\Tanks\Tanks\Tanks\img\tank.png");
            this.x = x;
            this.y = y;
            size = 60;
        }
    }
}
