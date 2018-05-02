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

        public int PositionX { get; set; }
        public int PositionY { get; set; }
        private ConsoleColor Color;
        public List<Snake> SnakeTail { get; set; }

        public void Update(ConsoleKey currentKey, ConsoleKey lastDirectionKey)
        {
            if (currentKey == ConsoleKey.RightArrow)
            {
                this.SnakeTail.RemoveAt(0);
                Snake newSnake = new Snake(this.SnakeTail[this.SnakeTail.Count - 1].PositionX, this.SnakeTail[this.SnakeTail.Count - 1].PositionY);
                newSnake.PositionX++;
                this.SnakeTail.Add(newSnake);
            }

            else if (currentKey == ConsoleKey.DownArrow)
            {
                this.SnakeTail.RemoveAt(0);
                Snake newSnake = new Snake(this.SnakeTail[this.SnakeTail.Count - 1].PositionX, this.SnakeTail[this.SnakeTail.Count - 1].PositionY);
                newSnake.PositionY++;
                this.SnakeTail.Add(newSnake);
            }

            else if (currentKey == ConsoleKey.LeftArrow && lastDirectionKey != ConsoleKey.RightArrow)
            {
                this.SnakeTail.RemoveAt(0);
                Snake newSnake = new Snake(this.SnakeTail[this.SnakeTail.Count - 1].PositionX, this.SnakeTail[this.SnakeTail.Count - 1].PositionY);
                newSnake.PositionX--;
                this.SnakeTail.Add(newSnake);
            }

            else if (currentKey == ConsoleKey.UpArrow)
            {
                this.SnakeTail.RemoveAt(0);
                Snake newSnake = new Snake(this.SnakeTail[this.SnakeTail.Count - 1].PositionX, this.SnakeTail[this.SnakeTail.Count - 1].PositionY);
                newSnake.PositionY--;
                this.SnakeTail.Add(newSnake);
            }
        }

        public void Draw()
        {
            Console.ForegroundColor = Color;
            foreach (var snakePart in this.SnakeTail)
            {
                Console.SetCursorPosition(snakePart.PositionX, snakePart.PositionY);
                Console.Write("*");
            }
        }

        public void SetColor()
        {
            Console.WriteLine("Select snake color 1 - 4");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1 - White");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("2 - Magenta");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("3 - Dark Green");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("4 - Green");
            Console.ForegroundColor = ConsoleColor.White;
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Color = ConsoleColor.White;
                    break;
                case 2:
                    Color = ConsoleColor.Magenta;
                    break;
                case 3:
                    Color = ConsoleColor.DarkGreen;
                    break;
                case 4:
                    Color = ConsoleColor.Green;
                    break;
                default:
                    Color = ConsoleColor.Gray;
                    break;
            }
        }

        public bool CollisionWithSnake()
        {
            for (int i = 0; i < this.SnakeTail.Count - 1; i++)
            {
                if (this.SnakeTail[i].PositionX == this.SnakeTail[this.SnakeTail.Count - 1].PositionX && this.SnakeTail[i].PositionY == this.SnakeTail[this.SnakeTail.Count - 1].PositionY)
                {
                    this.SnakeTail.RemoveRange(0, this.SnakeTail.Count - 1);
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
            if (this.SnakeTail[this.SnakeTail.Count - 1].PositionX == foodPositionX && this.SnakeTail[this.SnakeTail.Count - 1].PositionY == foodPositionY)
            {
                Thread soundThread = new Thread(PlaySound);
                Snake tail = new Snake(this.SnakeTail[this.SnakeTail.Count - 1].PositionX, this.SnakeTail[this.SnakeTail.Count - 1].PositionY);
                soundThread.Start();
                this.SnakeTail.Add(tail);
                return true;
            }
            return false;
        }

        public bool CollisionWithWall(int level)
        {
            switch (level)
            {
                case 1:
                if (this.SnakeTail[this.SnakeTail.Count - 1].PositionX <= 30 ||
                this.SnakeTail[this.SnakeTail.Count - 1].PositionY <= 2 ||
                this.SnakeTail[this.SnakeTail.Count - 1].PositionX >= 90 ||
                this.SnakeTail[this.SnakeTail.Count - 1].PositionY >= 24)
                    {
                        return true;
                    }
                    break;
                case 2:
                if (this.SnakeTail[this.SnakeTail.Count - 1].PositionX <= 30 ||
                this.SnakeTail[this.SnakeTail.Count - 1].PositionY <= 2 ||
                this.SnakeTail[this.SnakeTail.Count - 1].PositionX >= 90 ||
                this.SnakeTail[this.SnakeTail.Count - 1].PositionY >= 24 ||
                this.SnakeTail[this.SnakeTail.Count - 1].PositionX >= 50 && this.SnakeTail[this.SnakeTail.Count - 1].PositionX <= 70 && this.SnakeTail[this.SnakeTail.Count - 1].PositionY == 10 ||
                this.SnakeTail[this.SnakeTail.Count - 1].PositionX >= 50 && this.SnakeTail[this.SnakeTail.Count - 1].PositionX <= 70 && this.SnakeTail[this.SnakeTail.Count - 1].PositionY == 15)
                    {
                        return true;
                    }
                    break;
                case 3:
                    if (this.SnakeTail[this.SnakeTail.Count - 1].PositionX <= 41 ||
                    this.SnakeTail[this.SnakeTail.Count - 1].PositionY <= 5 ||
                    this.SnakeTail[this.SnakeTail.Count - 1].PositionX >= 77 ||
                    this.SnakeTail[this.SnakeTail.Count - 1].PositionY >= 20)
                    {
                        return true;
                    }
                    break;
                        default:
                    break;
            }
            
            return false;
        }

        public static List<Snake> InitializeSnake(int snakeLength, int level)
        {
            List<Snake> snakeTail = new List<Snake>();
            if(level < 3)
            {
                for (int i = 0; i < snakeLength; i++)
                {
                    Snake snake = new Snake(31 + i, 3);
                    snakeTail.Add(snake);
                }
            }
            else
            {
                for (int i = 0; i < snakeLength; i++)
                {
                    Snake snake = new Snake(42 + i, 6);
                    snakeTail.Add(snake);
                }
            }


            return snakeTail;
        }

    }
}
