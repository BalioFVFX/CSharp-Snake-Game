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
            ConsoleKey lastKey = ConsoleKey.Delete;

            while (true)
            {
                ConsoleKey currentKey = ConsoleKey.Delete;

                if (Console.KeyAvailable)
                {
                    currentKey = Console.ReadKey().Key;
                }


                
                
                if(currentKey == ConsoleKey.DownArrow)
                {
                    snakeYPosition++;
                    lastKey = currentKey;
                }
                else if (currentKey == ConsoleKey.UpArrow)
                {
                    snakeYPosition--;
                    lastKey = currentKey;
                }
                else if (currentKey == ConsoleKey.LeftArrow)
                {
                    snakeXPosition--;
                    lastKey = currentKey;
                }
                else if (currentKey == ConsoleKey.RightArrow)
                {
                    snakeXPosition++;
                    lastKey = currentKey;
                }
                
                
                Console.SetCursorPosition(snakeXPosition, snakeYPosition);
                Console.Write("*");
                Thread.Sleep(500);

                if (!Console.KeyAvailable)
                {
                    if (lastKey == ConsoleKey.DownArrow)
                    {
                        snakeYPosition++;
                    }
                    else if (lastKey == ConsoleKey.UpArrow)
                    {
                        snakeYPosition--;
                    }
                    else if (lastKey == ConsoleKey.LeftArrow)
                    {
                        snakeXPosition--;
                    }
                    else if (lastKey == ConsoleKey.RightArrow)
                    {
                        snakeXPosition++;
                    }
                }

                Console.SetCursorPosition(snakeXPosition, snakeYPosition);
                Console.Write("*");
                Console.Clear();
            }
        }
    }
}
