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
            List<Snake> snakeTail = InitializeSnake(5);
            
            DrawArea();


            ConsoleKey currentKey = ConsoleKey.Delete;

            ConsoleKey lastKey = ConsoleKey.Delete;

            int speed = 300;
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
                    DrawArea();
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
                    DrawArea();
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
                    DrawArea();
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
                    DrawArea();
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
        public static void DrawArea()
        {
            for (int i = 30; i <= 90; i++)
            {
                Console.SetCursorPosition(i, 2);
                Console.Write("#");
            }

            for (int i = 3; i <= 24; i++)
            {
                Console.SetCursorPosition(30, i);
                Console.WriteLine("#");
            }

            for (int i = 3; i <= 24; i++)
            {
                Console.SetCursorPosition(90, i);
                Console.WriteLine("#");
            }

            for (int i = 30; i <= 90; i++)
            {
                Console.SetCursorPosition(i, 24);
                Console.Write("#");
            }

            Console.SetCursorPosition(100, 27);
            Console.Write("By: BalioFVFX");
        }
    }
}