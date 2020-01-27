using System;
using System.Collections.Generic;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(1, 3, '*');
            p1.Draw();

            Point p2 = new Point(4, 5, '#');
            p2.Draw();

            List<int> numList = new List<int>();
            numList.Add(0);
            numList.Add(1);
            numList.Add(2);

            int x = numList[0];
            int y = numList[1];
            int z = numList[2];

            foreach(var i in numList)
            {
                Console.WriteLine(i);
            }

            numList.RemoveAt(0);

            List<Point> pList = new List<Point>();
            pList.Add(p1);
            pList.Add(p2);

            Point p3 = new Point(10, 10, '$');
            Point p4 = new Point(13, 14, '&');
            pList.Add(p3);
            pList.Add(p4);

            List<char> cList = new List<char>();
            cList.Add('$');
            cList.Add('%');
            cList.Add('^');
            cList.Add('@');

            Console.ReadKey();
        }
    }
}
