﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    public class Kolobok
    {
        public int x;
        public int y;
        public int size;
        public Image kolobokImg;

        public Kolobok(int x, int y)
        {
            kolobokImg = new Bitmap(@"C:\Users\user\Desktop\Папка\EPAM\Внутренние курсы\Practice-2020\Tanks\Tanks\Tanks\img\kolobok.png");
            this.x = x;
            this.y = y;
            size = 60; 
        }
    }
}
