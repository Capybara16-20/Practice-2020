using System;
using System.Collections.Generic;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Point p1 = new Point(1, 3, '*');
            p1.Draw();

            Point p2 = new Point(4, 5, '#');
            p2.Draw();*/

            HorizontalLine hLine = new HorizontalLine(5, 11, 8, '+');
            hLine.Drow();

            VerticalLine vLine = new VerticalLine(3, 13, 8, '+');
            vLine.Drow();

            Console.ReadKey();
        }
    }
}
