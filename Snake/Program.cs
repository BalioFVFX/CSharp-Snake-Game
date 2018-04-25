using System;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Snake Game";

            int snakeXPosition = 0;
            int snakeYPosition = 0;

            while (true)
            {
                Console.SetCursorPosition(snakeXPosition, snakeYPosition);
                Console.Write("*");
                ConsoleKey pressedKey = Console.ReadKey().Key;
                if(pressedKey== ConsoleKey.DownArrow)
                {
                    snakeYPosition++;
                    continue;
                }
                if(pressedKey == ConsoleKey.UpArrow && snakeYPosition != 0)
                {
                    snakeYPosition--;
                    continue;
                }
                if(pressedKey == ConsoleKey.RightArrow)
                {
                    snakeXPosition++;
                    continue;
                }
                if (pressedKey == ConsoleKey.LeftArrow && snakeXPosition != 0)
                {
                    snakeXPosition--;
                    continue;
                }
               
            }
        }
    }
}
