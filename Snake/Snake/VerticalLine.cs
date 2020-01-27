using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class VerticalLine
    {
        List<Point> pList;

        public VerticalLine(int yTop, int yBottom, int x, char sym)
        {
            pList = new List<Point>();
            for (int y = yTop; y <= yBottom; y++)
            {
                pList.Add(new Point(x, y, sym));
            }
        }

        public void Drow()
        {
            foreach (var p in pList)
            {
                p.Draw();
            }
        }
    }
}
