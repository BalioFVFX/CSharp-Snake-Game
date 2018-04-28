using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Snake
{
    class Snake
    {
        public Snake(int x, int y)
        {
            this.PositionX = x;
            this.PositionY = y;
            this.SnakeTail = new List<Snake>();
        }

        public int PositionX;
        public int PositionY;
        public List<Snake> SnakeTail;

        public static void Update(ConsoleKey currentKey, List<Snake> snakeTail)
        {
            if (currentKey == ConsoleKey.RightArrow)
            {
                snakeTail.RemoveAt(0);
                Snake newSnake = new Snake(snakeTail[snakeTail.Count - 1].PositionX, snakeTail[snakeTail.Count - 1].PositionY);
                newSnake.PositionX++;
                snakeTail.Add(newSnake);
            }

            else if (currentKey == ConsoleKey.DownArrow)
            {
                snakeTail.RemoveAt(0);
                Snake newSnake = new Snake(snakeTail[snakeTail.Count - 1].PositionX, snakeTail[snakeTail.Count - 1].PositionY);
                newSnake.PositionY++;
                snakeTail.Add(newSnake);
            }

            else if (currentKey == ConsoleKey.LeftArrow)
            {
                snakeTail.RemoveAt(0);
                Snake newSnake = new Snake(snakeTail[snakeTail.Count - 1].PositionX, snakeTail[snakeTail.Count - 1].PositionY);
                newSnake.PositionX--;
                snakeTail.Add(newSnake);
            }

            else if (currentKey == ConsoleKey.UpArrow)
            {
                snakeTail.RemoveAt(0);
                Snake newSnake = new Snake(snakeTail[snakeTail.Count - 1].PositionX, snakeTail[snakeTail.Count - 1].PositionY);
                newSnake.PositionY--;
                snakeTail.Add(newSnake);
            }
        }

        public static void Draw(List<Snake> snakeTail)
        {
            foreach (var snakePart in snakeTail)
            {
                Console.SetCursorPosition(snakePart.PositionX, snakePart.PositionY);
                Console.Write("*");
            }
        }

        public static bool CollisionWithSnake(List<Snake> snakeTail)
        {
            for (int i = 0; i < snakeTail.Count - 1; i++)
            {
                if (snakeTail[i].PositionX == snakeTail[snakeTail.Count - 1].PositionX && snakeTail[i].PositionY == snakeTail[snakeTail.Count - 1].PositionY)
                {
                    return true;
                }
            }
            return false;
        }

        public static void PlaySound()
        {
            Console.Beep(150, 100);
        }

        public static bool CollisionWithFood(List<Snake> snakeTail, int foodPositionX, int foodPositionY)
        {
            if (snakeTail[snakeTail.Count - 1].PositionX == foodPositionX && snakeTail[snakeTail.Count - 1].PositionY == foodPositionY)
            {
                Thread soundThread = new Thread(PlaySound);
                Snake tail = new Snake(snakeTail[snakeTail.Count - 1].PositionX, snakeTail[snakeTail.Count - 1].PositionY);
                soundThread.Start();
                snakeTail.Add(tail);
                return true;
            }
            return false;
        }

        public static List<Snake> InitializeSnake(int snakeLength)
        {
            List<Snake> snakeTail = new List<Snake>();
            for (int i = 0; i < snakeLength; i++)
            {
                Snake snake = new Snake(31 + i, 3);
                snakeTail.Add(snake);
            }

            Console.SetCursorPosition(31, 3);
            Console.Write(new string('*', snakeLength));

            return snakeTail;
        }

    }
}
