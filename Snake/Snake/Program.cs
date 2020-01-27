using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(1, 3, '*');
            //p1.Draw();

            Point p2 = new Point(4, 5, '#');
            //p2.Draw();

            int x = 1;
            Func1(x);
            Console.WriteLine("Call Func1. x = " + x);

            Func2(x);
            Console.WriteLine("Call Func2. x = " + x);

            Func3(x);
            Console.WriteLine("Call Func3. x = " + x);

            Move(p1, 10, 10);
            Console.WriteLine("Call Move(p1, 10, 10). p1.x = " + p1.x + ", p1.y = " + p1.y);

            Reset(p2);
            Console.WriteLine("Call Reset(p2). p2.x = " + p2.x + ", p2.y = " + p2.y);

            p1 = p2;
            p2.x = 8;
            p2.y = 8;
            Console.WriteLine("p1 = p2. p1.x = " + p1.x + ", p1.y = " + p1.y); 
            Console.ReadKey();
        }

        public static void Func1(int value)
        {

        }

        public static void Func2(int value)
        {
            value++;
        }

        public static void Func3(int x)
        {
            x++;
        }

        public static void Reset(Point p)
        {
            p = new Point();
        }

        public static void Move(Point p, int dx, int dy)
        {
            p.x = p.x + dx;
            p.y = p.y + dy;
        }
    }
}
