using System;
using System.Collections.Generic;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(80, 25);
            Console.SetWindowSize(80, 25);

            Walls walls = new Walls(80, 25);
            walls.Draw();

            int score = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(5, 0);
            Console.WriteLine("SCORE:" + score);

            Point p1 = new Point(4, 5, '*');
            Snake snake = new Snake(p1, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(35, 10);
                    Console.WriteLine("GAME OVER");
                    Console.ReadKey();
                    break;
                }

                if (snake.Eat(food))
                {
                    score += 1;
                    Console.SetCursorPosition(11, 0);
                    Console.WriteLine(score);
                    food = foodCreator.CreateFood();
                    food.Draw();
                    snake.Draw();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(100);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
            Console.ReadKey();
        }
    }
}
