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
            List<Snake> snakeTail = InitializeSnake();
            
            DrawArea();

            

            while (true)
            {
                ConsoleKey currentKey = ConsoleKey.Delete;

                if (Console.KeyAvailable)
                {
                    currentKey = Console.ReadKey().Key;
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

                if (currentKey == ConsoleKey.DownArrow)
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

                if (currentKey == ConsoleKey.LeftArrow)
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

                if (currentKey == ConsoleKey.UpArrow)
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
            }

            Console.WriteLine("GAME OVER!");
        }
        public static List<Snake> InitializeSnake()
        {
            Snake snake = new Snake(31, 3);
            Snake snake2 = new Snake(32, 3);
            Snake snake3 = new Snake(33, 3);
            List<Snake> snakeTail = new List<Snake>();
            snakeTail.Add(snake);
            snakeTail.Add(snake2);
            snakeTail.Add(snake3);

            Console.SetCursorPosition(31, 3);
            Console.Write(new string('*', 3));

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
        }
    }
}