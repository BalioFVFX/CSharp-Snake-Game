﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Snake
{
    class Game
    {

        public Game()
        {
            this.currentKey = ConsoleKey.Delete;
            this.lastKey = ConsoleKey.Delete;
            this.points = 20;
            this.speed = 300;
            this.randFoodPosition = new Random();
            this.foodPositionX = this.randFoodPosition.Next(31, 90);
            this.foodPositionY = this.randFoodPosition.Next(3, 23);
        }

        public bool GameOver { get; set; }
        private ConsoleKey currentKey;
        private ConsoleKey lastKey;
        private int points;
        private int speed;
        private int foodPositionX;
        private int foodPositionY;
        private Random randFoodPosition;
        public int level { get; set; }

        public void StartGame()
        {
            Snake snake = new Snake(1, 1);
            snake.SnakeTail = Snake.InitializeSnake(3);
            this.points = 20;
            this.GameOver = false;
            this.currentKey = ConsoleKey.Delete;
            this.speed = 300;

            while (this.GameOver == false)
            {
                if (Console.KeyAvailable)
                {
                    this.currentKey = Console.ReadKey(true).Key;

                    if (this.lastKey == this.currentKey)
                    {
                        if (this.speed > 100)
                        {
                            this.speed -= 40;
                        }
                        else if (this.speed > 30)
                        {
                            this.speed -= 10;
                        }

                        continue;
                    }
                    this.speed = 300;

                    this.lastKey = this.currentKey;
                }

                Console.Clear();
                Environment.DrawArea(this.level);
                DrawPoints();
                Environment.DrawFood(this.foodPositionX, this.foodPositionY);
                snake.Update(currentKey);
                snake.Draw();
                if (snake.CollisionWithSnake())
                {
                    this.GameOver = true;
                    break;
                }
                if (snake.CollisionWithFood(foodPositionX, foodPositionY))
                {
                    this.points += 10;
                    this.foodPositionX = this.randFoodPosition.Next(31, 90);
                    this.foodPositionY = this.randFoodPosition.Next(3, 23);
                }
                if (snake.CollisionWithWall(this.level))
                {
                    this.GameOver = true;
                    break;
                }
                
                Thread.Sleep(this.speed);
            }
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("Please enter level number");
            Console.WriteLine("1 - Classic");
            Console.WriteLine("2 - Tunnel");
            Console.WriteLine("3 - Exit the game");
            this.level = 0;
            while (this.level <= 0 || this.level >= 4)
            {
                try
                {
                    this.level = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a number in range 1 -3");
                }
                switch (this.level)
                    {
                        case 1:
                            Environment.DrawArea(this.level);
                            StartGame();
                            break;
                        case 2:
                            Console.Clear();
                            Environment.DrawArea(this.level);
                            StartGame();
                            break;
                        case 3:
                            return;
                        default:
                        Console.WriteLine("Please enter a number in range 1 -3");
                        break;
                    }
                

            }
        }

        public void DrawPoints()
        {
            Console.SetCursorPosition(100, 1);
            Console.Write("Points: {0}", this.points);
        }
    }
}
