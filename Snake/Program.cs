﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace Snake
{
    class Program
    {



        static void Main(string[] args)
        {
            Console.Title = "Snake Game";
            int speed = 300;
            int level = Menu();
            Random randFoodPosition = new Random();
            int foodPositionX = randFoodPosition.Next(31, 90);
            int foodPositionY = randFoodPosition.Next(3, 23);

            List<Snake> snakeTail = InitializeSnake(5);
            
            ConsoleKey currentKey = ConsoleKey.Delete;
            ConsoleKey lastKey = ConsoleKey.Delete;


            while (true)
            {
                if (Console.KeyAvailable)
                {
                    currentKey = Console.ReadKey(true).Key;

                    if (lastKey == currentKey)
                    {
                        if(speed > 100)
                        {
                            speed -= 40;
                        }
                        else if(speed > 30)
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
                    DrawArea(level);
                    DrawFood(foodPositionX, foodPositionY);
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
                    DrawArea(level);
                    DrawFood(foodPositionX, foodPositionY);
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
                    DrawArea(level);
                    DrawFood(foodPositionX, foodPositionY);
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
                    DrawArea(level);
                    DrawFood(foodPositionX, foodPositionY);
                    foreach (var snakePart in snakeTail)
                    {
                        Console.SetCursorPosition(snakePart.PositionX, snakePart.PositionY);
                        Console.Write("*");
                    }
                }
                Thread.Sleep(speed);
            }
            
            Console.WriteLine("GAME OVER!");
        }

        public static void DrawFood(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("*");
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

        public static int Menu()
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
                            DrawArea(level);
                            return 1;
                        case 2:
                            Console.Clear();
                            DrawArea(level);
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

        public static void DrawArea(int level)
        {
            switch (level)
            {
                case 1:
                    // TOP
                    for (int i = 30; i <= 90; i++)
                    {
                        Console.SetCursorPosition(i, 2);
                        Console.Write("#");
                    }

                    // LEFT
                    for (int i = 3; i <= 24; i++)
                    {
                        Console.SetCursorPosition(30, i);
                        Console.WriteLine("#");
                    }

                    // RIGHT
                    for (int i = 3; i <= 24; i++)
                    {
                        Console.SetCursorPosition(90, i);
                        Console.WriteLine("#");
                    }

                    // DOWN
                    for (int i = 30; i <= 90; i++)
                    {
                        Console.SetCursorPosition(i, 24);
                        Console.Write("#");
                    }

                    Console.SetCursorPosition(100, 27);
                    Console.Write("By: BalioFVFX");
                    break;
                case 2:
                    // TOP
                    for (int i = 30; i <= 90; i++)
                    {
                        Console.SetCursorPosition(i, 2);
                        Console.Write("#");
                    }
                    // LEFT
                    for (int i = 3; i <= 24; i++)
                    {
                        Console.SetCursorPosition(30, i);
                        Console.WriteLine("#");
                    }
                    // RIGHT
                    for (int i = 3; i <= 24; i++)
                    {
                        Console.SetCursorPosition(90, i);
                        Console.WriteLine("#");
                    }

                    // Tunnel
                    for (int i = 50; i < 71; i++)
                    {
                        Console.SetCursorPosition(i, 10);
                        Console.Write("#");
                    }

                    // Tunnel
                    for (int i = 50; i < 71; i++)
                    {
                        Console.SetCursorPosition(i, 15);
                        Console.Write("#");
                    }

                    // DOWN
                    for (int i = 30; i <= 90; i++)
                    {
                        Console.SetCursorPosition(i, 24);
                        Console.Write("#");
                    }

                    Console.SetCursorPosition(100, 27);
                    Console.Write("By: BalioFVFX");
                    break;
                default:
                    break;
            }
        }
    }
}