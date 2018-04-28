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
            int points = 20;
            Random randFoodPosition = new Random();
            int foodPositionX = randFoodPosition.Next(31, 90);
            int foodPositionY = randFoodPosition.Next(3, 23);

            Game game = new Game();


            
            Snake snake = new Snake(1, 1);

            snake.SnakeTail = Snake.InitializeSnake(3);
            int level = game.Menu();

            game.StartGame(level, speed, snake.SnakeTail, foodPositionX, foodPositionY, randFoodPosition, points);
            
            
            
        }
    }
}