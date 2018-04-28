using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Snake
{
    class Game
    {
        public bool GameOver { get; set; }

        public void StartGame(int level, ConsoleKey currentKey, ConsoleKey lastKey, int speed, List<Snake> snakeTail, int foodPositionX, int foodPositionY, Random randFoodPosition, int points)
        {
            Environment.DrawArea(level);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    currentKey = Console.ReadKey(true).Key;

                    if (lastKey == currentKey)
                    {
                        if (speed > 100)
                        {
                            speed -= 40;
                        }
                        else if (speed > 30)
                        {
                            speed -= 10;
                        }

                        continue;
                    }
                    speed = 300;

                    lastKey = currentKey;
                }

                if (currentKey == ConsoleKey.RightArrow)
                {
                    snakeTail.RemoveAt(0);

                    Snake newSnake = new Snake(snakeTail[snakeTail.Count - 1].PositionX, snakeTail[snakeTail.Count - 1].PositionY);
                    newSnake.PositionX++;
                    snakeTail.Add(newSnake);


                    Console.Clear();
                    Environment.DrawArea(level);
                    Environment.DrawFood(foodPositionX, foodPositionY);
                    if (Snake.CollisionWithSnake(snakeTail))
                    {
                        break;
                    }
                    if (Snake.CollisionWithFood(snakeTail, foodPositionX, foodPositionY))
                    {
                        foodPositionX = randFoodPosition.Next(31, 90);
                        foodPositionY = randFoodPosition.Next(3, 23);
                        points += 10;
                    }
                    DrawPoints(points);

                    foreach (var snakePart in snakeTail)
                    {
                        Console.SetCursorPosition(snakePart.PositionX, snakePart.PositionY);
                        Console.Write("*");
                    }
                }

                else if (currentKey == ConsoleKey.DownArrow)
                {
                    snakeTail.RemoveAt(0);
                    Snake newSnake = new Snake(snakeTail[snakeTail.Count - 1].PositionX, snakeTail[snakeTail.Count - 1].PositionY);
                    newSnake.PositionY++;
                    snakeTail.Add(newSnake);

                    Console.Clear();
                    Environment.DrawArea(level);
                    Environment.DrawFood(foodPositionX, foodPositionY);
                    if (Snake.CollisionWithSnake(snakeTail))
                    {
                        break;
                    }
                    if (Snake.CollisionWithFood(snakeTail, foodPositionX, foodPositionY))
                    {
                        foodPositionX = randFoodPosition.Next(31, 90);
                        foodPositionY = randFoodPosition.Next(3, 23);
                        points += 10;
                    }
                    DrawPoints(points);

                    foreach (var snakePart in snakeTail)
                    {
                        Console.SetCursorPosition(snakePart.PositionX, snakePart.PositionY);
                        Console.Write("*");
                    }
                }

                else if (currentKey == ConsoleKey.LeftArrow)
                {
                    snakeTail.RemoveAt(0);
                    Snake newSnake = new Snake(snakeTail[snakeTail.Count - 1].PositionX, snakeTail[snakeTail.Count - 1].PositionY);
                    newSnake.PositionX--;
                    snakeTail.Add(newSnake);

                    Console.Clear();
                    Environment.DrawArea(level);
                    Environment.DrawFood(foodPositionX, foodPositionY);

                    if (Snake.CollisionWithSnake(snakeTail))
                    {
                        break;
                    }
                    if (Snake.CollisionWithFood(snakeTail, foodPositionX, foodPositionY))
                    {
                        foodPositionX = randFoodPosition.Next(31, 90);
                        foodPositionY = randFoodPosition.Next(3, 23);
                        points += 10;
                    }
                    DrawPoints(points);

                    foreach (var snakePart in snakeTail)
                    {
                        Console.SetCursorPosition(snakePart.PositionX, snakePart.PositionY);
                        Console.Write("*");
                    }
                }

                else if (currentKey == ConsoleKey.UpArrow)
                {
                    snakeTail.RemoveAt(0);
                    Snake newSnake = new Snake(snakeTail[snakeTail.Count - 1].PositionX, snakeTail[snakeTail.Count - 1].PositionY);
                    newSnake.PositionY--;
                    snakeTail.Add(newSnake);

                    Console.Clear();
                    Environment.DrawArea(level);
                    Environment.DrawFood(foodPositionX, foodPositionY);
                    if (Snake.CollisionWithSnake(snakeTail))
                    {
                        break;
                    }
                    if (Snake.CollisionWithFood(snakeTail, foodPositionX, foodPositionY))
                    {
                        foodPositionX = randFoodPosition.Next(31, 90);
                        foodPositionY = randFoodPosition.Next(3, 23);
                        points += 10;
                    }

                    DrawPoints(points);
                    foreach (var snakePart in snakeTail)
                    {
                        Console.SetCursorPosition(snakePart.PositionX, snakePart.PositionY);
                        Console.Write("*");
                    }
                }
                Thread.Sleep(speed);
            }
        }

        public int Menu()
        {
            Console.WriteLine("Please enter level number");
            Console.WriteLine("1 - Classic");
            Console.WriteLine("2 - Tunnel");
            Console.WriteLine("3 - Exit the game");
            int level = 4;
            while (level <= 0 || level >= 4)
            {
                try
                {
                    level = int.Parse(Console.ReadLine());
                    switch (level)
                    {
                        case 1:
                            Console.Clear();
                            Environment.DrawArea(level);
                            return 1;
                        case 2:
                            Console.Clear();
                            Environment.DrawArea(level);
                            return 2;
                        case 3:
                            break;
                        default:
                            return 3;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a number in range 1 -3");
                }
            }
            return 0;
        }

        public void DrawPoints(int points)
        {
            Console.SetCursorPosition(100, 1);
            Console.Write("Points: {0}", points);
        }
    }
}
