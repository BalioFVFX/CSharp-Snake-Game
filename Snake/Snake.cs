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
        public List<Snake> SnakeTail { get; set; }

        public void Update(ConsoleKey currentKey )
        {
            if (currentKey == ConsoleKey.RightArrow)
            {
                SnakeTail.RemoveAt(0);
                Snake newSnake = new Snake(SnakeTail[SnakeTail.Count - 1].PositionX, SnakeTail[SnakeTail.Count - 1].PositionY);
                newSnake.PositionX++;
                SnakeTail.Add(newSnake);
            }

            else if (currentKey == ConsoleKey.DownArrow)
            {
                SnakeTail.RemoveAt(0);
                Snake newSnake = new Snake(SnakeTail[SnakeTail.Count - 1].PositionX, SnakeTail[SnakeTail.Count - 1].PositionY);
                newSnake.PositionY++;
                SnakeTail.Add(newSnake);
            }

            else if (currentKey == ConsoleKey.LeftArrow)
            {
                SnakeTail.RemoveAt(0);
                Snake newSnake = new Snake(SnakeTail[SnakeTail.Count - 1].PositionX, SnakeTail[SnakeTail.Count - 1].PositionY);
                newSnake.PositionX--;
                SnakeTail.Add(newSnake);
            }

            else if (currentKey == ConsoleKey.UpArrow)
            {
                SnakeTail.RemoveAt(0);
                Snake newSnake = new Snake(SnakeTail[SnakeTail.Count - 1].PositionX, SnakeTail[SnakeTail.Count - 1].PositionY);
                newSnake.PositionY--;
                SnakeTail.Add(newSnake);
            }
        }

        public void Draw()
        {
            foreach (var snakePart in SnakeTail)
            {
                Console.SetCursorPosition(snakePart.PositionX, snakePart.PositionY);
                Console.Write("*");
            }
        }

        public bool CollisionWithSnake()
        {
            for (int i = 0; i < SnakeTail.Count - 1; i++)
            {
                if (SnakeTail[i].PositionX == SnakeTail[SnakeTail.Count - 1].PositionX && SnakeTail[i].PositionY == SnakeTail[SnakeTail.Count - 1].PositionY)
                {
                    SnakeTail.RemoveRange(0, SnakeTail.Count - 1);
                    return true;
                }
            }
            return false;
        }

        public static void PlaySound()
        {
            Console.Beep(150, 100);
        }

        public bool CollisionWithFood(int foodPositionX, int foodPositionY)
        {
            if (SnakeTail[SnakeTail.Count - 1].PositionX == foodPositionX && SnakeTail[SnakeTail.Count - 1].PositionY == foodPositionY)
            {
                Thread soundThread = new Thread(PlaySound);
                Snake tail = new Snake(SnakeTail[SnakeTail.Count - 1].PositionX, SnakeTail[SnakeTail.Count - 1].PositionY);
                soundThread.Start();
                SnakeTail.Add(tail);
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

            return snakeTail;
        }

    }
}
