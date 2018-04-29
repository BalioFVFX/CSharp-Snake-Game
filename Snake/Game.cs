using System;
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

        public void StartGame(int level, Snake snake)
        {

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

                Console.Clear();
                Environment.DrawArea(level);
                DrawPoints(points);
                Environment.DrawFood(foodPositionX, foodPositionY);
                snake.Update(currentKey);
                if(snake.CollisionWithFood(foodPositionX, foodPositionY))
                {
                    points += 10;
                    foodPositionX = randFoodPosition.Next(31, 90);
                    foodPositionY = randFoodPosition.Next(3, 23);
                }
                
                snake.Draw();
                
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
