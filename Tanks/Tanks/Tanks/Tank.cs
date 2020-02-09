using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    class Tank : Entities
    {
        public Image tankImg;

        public Tank(int sizeX, int sizeY)
        {
            tankImg = new Bitmap(@"C:\Users\user\Desktop\Папка\EPAM\Внутренние курсы\Practice-2020\Tanks\Tanks\Tanks\img\tank.png");
            Random rnd = new Random();
            this.x = rnd.Next(6, sizeX + 4 - size); ;
            this.y = rnd.Next(6, sizeY + 4 - size); ;
            size = 60;
            direction = Direction.UP;
        }
    }
}
