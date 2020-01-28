using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Figure
    {
        protected List<Point> pList;

        public virtual void Drow()
        {
            foreach (var p in pList)
            {
                p.Draw();
            }
        }
    }
}
