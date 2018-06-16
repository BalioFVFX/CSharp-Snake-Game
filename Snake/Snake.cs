using System;
using System.Collections.Generic;
using System.Linq;
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
            this.Color = ConsoleColor.White;
        }

        public int PositionX { get; set; }
        public int PositionY { get; set; }
        private ConsoleColor Color;
        public List<Snake> SnakeTail { get; set; }

        public ConsoleKey Update(ConsoleKey currentKey, ConsoleKey lastDirectionKey)
        {
            if (currentKey == ConsoleKey.RightArrow)
            {

                if (lastDirectionKey == ConsoleKey.LeftArrow)
                {
                    currentKey = lastDirectionKey;
                    return currentKey;
                }

                this.SnakeTail.RemoveAt(0);
                Snake newSnake = new Snake(this.SnakeTail[this.SnakeTail.Count - 1].PositionX, this.SnakeTail[this.SnakeTail.Count - 1].PositionY);
                newSnake.PositionX++;
                this.SnakeTail.Add(newSnake);

            }

            else if (currentKey == ConsoleKey.DownArrow)
            {

                if (lastDirectionKey == ConsoleKey.UpArrow)
                {
                    currentKey = lastDirectionKey;
                    return currentKey;
                }

                this.SnakeTail.RemoveAt(0);
                Snake newSnake = new Snake(this.SnakeTail[this.SnakeTail.Count - 1].PositionX, this.SnakeTail[this.SnakeTail.Count - 1].PositionY);
                newSnake.PositionY++;
                this.SnakeTail.Add(newSnake);
                return currentKey;
            }

            else if (currentKey == ConsoleKey.LeftArrow)
            {
                if (lastDirectionKey == ConsoleKey.RightArrow)
                {
                    currentKey = lastDirectionKey;
                    return currentKey;
                }

                this.SnakeTail.RemoveAt(0);
                Snake newSnake = new Snake(this.SnakeTail[this.SnakeTail.Count - 1].PositionX, this.SnakeTail[this.SnakeTail.Count - 1].PositionY);
                newSnake.PositionX--;
                this.SnakeTail.Add(newSnake);
                return currentKey;
            }

            else if (currentKey == ConsoleKey.UpArrow)
            {
                if (lastDirectionKey == ConsoleKey.DownArrow)
                {
                    currentKey = lastDirectionKey;
                    return currentKey;
                }

                this.SnakeTail.RemoveAt(0);
                Snake newSnake = new Snake(this.SnakeTail[this.SnakeTail.Count - 1].PositionX, this.SnakeTail[this.SnakeTail.Count - 1].PositionY);
                newSnake.PositionY--;
                this.SnakeTail.Add(newSnake);
                return currentKey;
            }
            return currentKey;
        }
        public void DrawLength()
        {
            Console.SetCursorPosition(100, 5);
            Console.Write("Snake length: {0}", SnakeTail.Count);
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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1 - Blue");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("2 - Cyan");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("3 - Dark Blue");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("4 - Dark Cyan");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("5 - Dark Gray");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("6 - Dark Green");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("7 - Dark Magenta");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("8 - Dark Red");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("9 - Dark Yellow");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("10 - Gray");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("11 - Green");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("12 - Magenta");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("13 - Red");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("14 - White");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("15 - Yellow");
            Console.ForegroundColor = ConsoleColor.White;
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Color = ConsoleColor.Blue;
                    break;
                case 2:
                    Color = ConsoleColor.Cyan;
                    break;
                case 3:
                    Color = ConsoleColor.DarkBlue;
                    break;
                case 4:
                    Color = ConsoleColor.DarkCyan;
                    break;
                case 5:
                    Color = ConsoleColor.DarkGray;
                    break;
                case 6:
                    Color = ConsoleColor.DarkGreen;
                    break;
                case 7:
                    Color = ConsoleColor.DarkMagenta;
                    break;
                case 8:
                    Color = ConsoleColor.DarkRed;
                    break;
                case 9:
                    Color = ConsoleColor.DarkYellow;
                    break;
                case 10:
                    Color = ConsoleColor.Gray;
                    break;
                case 11:
                    Color = ConsoleColor.Green;
                    break;
                case 12:
                    Color = ConsoleColor.Magenta;
                    break;
                case 13:
                    Color = ConsoleColor.Red;
                    break;
                case 14:
                    Color = ConsoleColor.White;
                    break;
                case 15:
                    Color = ConsoleColor.Yellow;
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
                Snake tail = new Snake(SnakeTail[0].PositionX, SnakeTail[0].PositionY);
                soundThread.Start();
                this.SnakeTail.Insert(0, tail);
                return true;
            }
            return false;
        }

        public bool CollisionWithCustomWall(List<Dictionary<int, int>> customLevel)
        {
            foreach (var wall in customLevel)
            {
                if(wall.First().Key == this.SnakeTail[this.SnakeTail.Count - 1].PositionX &&
                    wall.First().Value == this.SnakeTail[this.SnakeTail.Count - 1].PositionY)
                {
                    return true;
                }
            }

            if (this.SnakeTail[this.SnakeTail.Count - 1].PositionX >= 35 && this.SnakeTail[this.SnakeTail.Count - 1].PositionX <= 85 && 
                this.SnakeTail[this.SnakeTail.Count - 1].PositionY <= 5 ||
                this.SnakeTail[this.SnakeTail.Count - 1].PositionX >= 35 && this.SnakeTail[this.SnakeTail.Count - 1].PositionX <= 85 &&
                this.SnakeTail[this.SnakeTail.Count - 1].PositionY >= 20 ||
                this.SnakeTail[this.SnakeTail.Count - 1].PositionX <= 35 &&
                this.SnakeTail[this.SnakeTail.Count - 1].PositionY >= 6 &&
                this.SnakeTail[this.SnakeTail.Count - 1].PositionY <= 19 ||
                this.SnakeTail[this.SnakeTail.Count - 1].PositionX >= 85 &&
                this.SnakeTail[this.SnakeTail.Count - 1].PositionY >= 6 &&
                this.SnakeTail[this.SnakeTail.Count - 1].PositionY <= 19)
            {
                return true;
            }
            return false;
        }

        public static List<Snake> InitializeSnake(int snakeLength, int level)
        {
            List<Snake> snakeTail = new List<Snake>();

           
                for (int i = 0; i < snakeLength; i++)
                {
                    Snake snake = new Snake(42 + i, 6);
                    snakeTail.Add(snake);
                }
   
            return snakeTail;
        }

    }
}
