using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    class Apple : Entities
    {
        public Apple(int sizeX, int sizeY)
        {
            this.img = new Bitmap(@"C:\Users\user\Desktop\Папка\EPAM\Внутренние курсы\Practice-2020\Tanks\Tanks\Tanks\img\apple.png");
            Random rnd = new Random();
            size = 60;
            this.x = rnd.Next(6, sizeX + 4 - size);
            this.y = rnd.Next(6, sizeY + 4 - size);
            
        }
    }
}
