using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            this.lastDirectionKey = ConsoleKey.Delete;
            this.points = 20;
            this.speed = 300;
            this.randFoodPosition = new Random();
            this.bestScore = 0;
            this.positionX = 0;
            this.positionY = 0;
            this.customLevel = new List<Dictionary<int, int>>();
            this.currentCustomLevelName = "";
        }

        public bool GameOver { get; set; }
        private ConsoleKey currentKey;
        private ConsoleKey lastKey;
        private ConsoleKey lastDirectionKey;
        private int points;
        private int speed;
        private int foodPositionX;
        private int foodPositionY;
        private Random randFoodPosition;
        private int bestScore;
        private int positionX;
        private int positionY;
        private string currentCustomLevelName;
        private List<Dictionary<int, int>> customLevel;
        public int level { get; set; }
        Snake snake = new Snake(1, 1);

        public void StartGame()
        {

            snake.SnakeTail = Snake.InitializeSnake(2, this.level);
            this.points = 20;
            this.GameOver = false;
            this.currentKey = ConsoleKey.Delete;
            this.speed = 300;

            
          
                GenerateFoodCustomLevel();

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


                    }
                    // Drawing and updating
                    Console.Clear();


                Environment.DrawCustomArea(this.customLevel);
                DrawSpeed();
                DrawPoints();
                Environment.DrawFood(this.foodPositionX, this.foodPositionY);
                currentKey = snake.Update(currentKey, lastDirectionKey);
                snake.Draw();
                snake.DrawLength();

                if (snake.CollisionWithSnake())
                    {
                        this.GameOver = true;
                        break;
                    }
                    if (snake.CollisionWithCustomWall(this.customLevel))
                    {
                        this.GameOver = true;
                        break;
                    }
                    if (snake.CollisionWithFood(this.foodPositionX, this.foodPositionY))
                    {
                        this.points += 10;
                        GenerateFoodCustomLevel();
                    }



                
                
                Thread.Sleep(this.speed);
                    this.lastKey = this.currentKey;
                    lastDirectionKey = currentKey;

               
            }
            
                this.bestScore = int.Parse(File.ReadLines(Directory.GetCurrentDirectory() + @"\scores\" + currentCustomLevelName + "Score" + ".txt").First());

            Console.Clear();

            if (this.points > this.bestScore)
            {
                File.WriteAllText(Directory.GetCurrentDirectory() + @"\scores\" + this.currentCustomLevelName + "Score" + ".txt", this.points.ToString());
                Console.WriteLine($"New record: {points}");
                Console.WriteLine($"Previus best score: {bestScore}");
            }
            else
            {
                Console.WriteLine($"Current score: {points}");
                Console.WriteLine($"Best score score: {bestScore}");
            }

            
            
            Thread.Sleep(2500);

        }

        private void GenerateFoodCustomLevel()
        {
            bool foodIsInsideTheSnake = false;
            bool inWall = false;

            do
            {
                foodIsInsideTheSnake = false;
                inWall = false;

                this.foodPositionX = this.randFoodPosition.Next(36, 85);
                this.foodPositionY = this.randFoodPosition.Next(7, 19);

                foreach (var snakeTail in snake.SnakeTail)
                {
                    if (snakeTail.PositionX == this.foodPositionX && snakeTail.PositionY == this.foodPositionY)
                    {
                        foodIsInsideTheSnake = true;
                        break;
                    }
                }

                foreach (var wall in this.customLevel)
                {
                    if (wall.First().Key == foodPositionX && wall.First().Value == foodPositionY)
                    {
                        inWall = true;
                        break;
                    }
                }
            }
            while (foodIsInsideTheSnake == true || inWall == true);
        }

        private void GenerateFood()
        {
            bool foodIsInsideTheSnake = false;
            switch (this.level)
            {
                case 1:
                    do
                    {
                        foodIsInsideTheSnake = false;
                        this.foodPositionX = this.randFoodPosition.Next(31, 90);
                        this.foodPositionY = this.randFoodPosition.Next(3, 23);

                        foreach (var snakeTail in snake.SnakeTail)
                        {
                            if (snakeTail.PositionX == this.foodPositionX && snakeTail.PositionY == this.foodPositionY)
                            {
                                foodIsInsideTheSnake = true;
                            }
                        }
                    }
                    while (foodIsInsideTheSnake == true);

                    break;
                case 2:
                    bool foodIsInsideTheTunnel = false;
                    do
                    {
                        this.foodPositionX = this.randFoodPosition.Next(31, 90);
                        this.foodPositionY = this.randFoodPosition.Next(3, 23);
                        foodIsInsideTheSnake = false;
                        foodIsInsideTheTunnel = false;

                        foreach (var snakeTail in snake.SnakeTail)
                        {
                            if (snakeTail.PositionX == this.foodPositionX && snakeTail.PositionY == this.foodPositionY)
                            {
                                foodIsInsideTheSnake = true;
                            }
                        }

                        if (this.foodPositionX >= 50 && this.foodPositionX <= 70 && this.foodPositionY == 10)
                        {
                            foodIsInsideTheTunnel = true;
                        }
                        else if (this.foodPositionX >= 50 && this.foodPositionX <= 70 && this.foodPositionY == 15)
                        {
                            foodIsInsideTheTunnel = true;
                        }
                    }
                    while (foodIsInsideTheSnake == true || foodIsInsideTheTunnel == true);

                    break;
                case 3:
                    do
                    {
                        foodIsInsideTheSnake = false;
                        this.foodPositionX = this.randFoodPosition.Next(42, 77);
                        this.foodPositionY = this.randFoodPosition.Next(7, 20);

                        foreach (var snakeTail in snake.SnakeTail)
                        {
                            if (snakeTail.PositionX == this.foodPositionX && snakeTail.PositionY == this.foodPositionY)
                            {
                                foodIsInsideTheSnake = true;
                            }
                        }
                    }
                    while (foodIsInsideTheSnake == true);

                    break;

                case 4:
                    do
                    {
                        foodIsInsideTheSnake = false;
                        this.foodPositionX = this.randFoodPosition.Next(42, 55);
                        this.foodPositionY = this.randFoodPosition.Next(7, 10);

                        foreach (var snakeTail in snake.SnakeTail)
                        {
                            if (snakeTail.PositionX == this.foodPositionX && snakeTail.PositionY == this.foodPositionY)
                            {
                                foodIsInsideTheSnake = true;
                            }
                        }
                    }
                    while (foodIsInsideTheSnake == true);
                    break;
                default:
                    break;
            }
        }

        public void Menu()
        {
            this.GameOver = false;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please enter level number");
            Console.WriteLine("1 - Classic");
            Console.WriteLine("2 - Custom levels");
            Console.WriteLine("3 - Level editor");
            Console.WriteLine("4 - Snake color");
            Console.WriteLine("5 - Environment color");
            Console.WriteLine("6 - Scores");
            Console.WriteLine("7 - Exit the game");
            this.level = 0;
            while (this.level <= 0 || this.level >= 7)
            {
                try
                {
                    this.level = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a number in range 1 - 7");
                }
                switch (this.level)
                {
                    case 1:
                        this.currentCustomLevelName = "level1";
                        UpdateCustomLevel("level1");
                        Environment.DrawCustomArea(this.customLevel);
                        break;
                    case 2:
                        Console.Clear();
                        PrintCustomLevels();
                        Console.Write("Level name: ");
                        this.currentCustomLevelName = Console.ReadLine();
                        UpdateCustomLevel(this.currentCustomLevelName);
                        Environment.DrawCustomArea(this.customLevel);
                        break;
                    case 3:
                        Console.Clear();
                        StartLevelEditorMenu();
                        Menu();
                        break;
                    case 4:
                        Console.Clear();
                        snake.SetColor();
                        Menu();
                        break;
                    case 5:
                        Console.Clear();
                        Environment.SetColor();
                        Menu();
                        break;
                    case 6:
                        Console.Clear();
                        DrawScores();
                        Menu();
                        break;
                    case 7:
                        return;
                    default:
                        Console.WriteLine("Please enter a number in range 1 - 7");
                        break;
                }
            }
        }

        private void DrawPoints()
        {
            Console.SetCursorPosition(100, 1);
            Console.Write("Points: {0}", this.points);
        }

        private void DrawLevels()
        {
            string[] levels = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\levels", "*.txt").Select(Path.GetFileName).ToArray();

            for (int i = 0; i < levels.Length; i++)
            {
                Console.WriteLine(levels[i].Substring(0, levels[i].Length - 4));
            }
        }

        private void DrawSpeed()
        {
            Console.SetCursorPosition(100, 3);
            int convertedSpeed = 0;
            switch (this.speed)
            {
                case 300:
                    convertedSpeed = 1;
                    break;
                case 260:
                    convertedSpeed = 2;
                    break;
                case 220:
                    convertedSpeed = 3;
                    break;
                case 180:
                    convertedSpeed = 4;
                    break;
                case 140:
                    convertedSpeed = 5;
                    break;
                case 100:
                    convertedSpeed = 6;
                    break;
                case 90:
                    convertedSpeed = 7;
                    break;
                case 80:
                    convertedSpeed = 8;
                    break;
                case 70:
                    convertedSpeed = 9;
                    break;
                case 60:
                    convertedSpeed = 10;
                    break;
                case 50:
                    convertedSpeed = 11;
                    break;
                case 40:
                    convertedSpeed = 12;
                    break;
                case 30:
                    convertedSpeed = 13;
                    break;
                default:
                    break;
            }
            Console.Write("Speed: " + convertedSpeed);
        }

        private void DrawScores()
        {
            Console.WriteLine("Classic - " + File.ReadAllText(Directory.GetCurrentDirectory() + @"\level" + 1 + ".txt"));
            Console.WriteLine("Tunnel - " + File.ReadAllText(Directory.GetCurrentDirectory() + @"\level" + 2 + ".txt"));
            Console.WriteLine("Classic small - " + File.ReadAllText(Directory.GetCurrentDirectory() + @"\level" + 3 + ".txt"));
            Console.ReadKey();
        }

        private void StartLevelEditorMenu()
        {
            Console.Clear();
            Console.WriteLine("Select a command: ");
            Console.WriteLine("1. Create a new level");
            Console.WriteLine("2. Edit level");
            Console.WriteLine("3. Delete level");
            int command = int.Parse(Console.ReadLine());


            if (command == 1)
            {
                Console.Write("New level name: ");
                string levelName = Console.ReadLine();

                File.CreateText(Directory.GetCurrentDirectory() + @"\levels\" + levelName + ".txt").Close();
                //Scores
               
                File.WriteAllText(Directory.GetCurrentDirectory() + @"\scores\" + levelName + "Score" + ".txt", "20");
                StartLevelEditor(levelName);
            }
            else if (command == 2)
            {
                Console.Write("Enter the name of the level you want to edit: ");
                string levelName = Console.ReadLine();
                StartLevelEditor(levelName);
            }

            Console.WriteLine("Controls: ");
            Console.WriteLine("Use arrows to navigate");
            Console.WriteLine("Use enter to place a wall");
            Console.WriteLine("Use ESC to save and exit");
        }

        private void StartLevelEditor(string fileName)
        {
            ConsoleKey editKey = ConsoleKey.Multiply;
            Console.CursorVisible = true;
            Console.Clear();
            this.customLevel.RemoveRange(0, this.customLevel.Count);
            DrawCustomLevel(fileName);

            Console.ForegroundColor = ConsoleColor.Red;
            Environment.DrawMArea();
            Console.ForegroundColor = ConsoleColor.White;
            Environment.DrawInstructions();

            while (true)
            {
                editKey = UpdateLevelEditorCursor();

                if (editKey == ConsoleKey.Enter)
                {
                    Console.Write("#");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Environment.DrawMArea();
                    Console.ForegroundColor = ConsoleColor.White;
                    Environment.DrawInstructions();

                    using (StreamWriter sw = File.AppendText(Directory.GetCurrentDirectory() + @"\levels\" + fileName + ".txt"))
                    {
                        sw.WriteLine(positionX);
                        sw.WriteLine(positionY);
                    }
                    UpdateCustomLevel(fileName);

                }
                else if (editKey == ConsoleKey.Delete)
                {
                    for (int i = 0; i < this.customLevel.Count; i++)
                    {
                        if (this.customLevel[i].First().Key == this.positionX && this.customLevel[i].First().Value == this.positionY)
                        {
                            this.customLevel.RemoveAt(i);
                            File.WriteAllText(Directory.GetCurrentDirectory() + @"\levels\" + fileName + ".txt", string.Empty);
                            for (int j = 0; j < this.customLevel.Count; j++)
                            {
                                using (StreamWriter sw = File.AppendText(Directory.GetCurrentDirectory() + @"\levels\" + fileName + ".txt"))
                                {
                                    sw.WriteLine(this.customLevel[j].First().Key);
                                    sw.WriteLine(this.customLevel[j].First().Value);
                                }
                            }
                            DrawCustomLevel(fileName);
                            break;
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    Environment.DrawMArea();
                    Console.ForegroundColor = ConsoleColor.White;
                    Environment.DrawInstructions();
                }

            }
        }

        private void DrawCustomLevel(string fileName)
        {
            Console.Clear();

            UpdateCustomLevel(fileName);

            for (int i = 0; i < this.customLevel.Count; i++)
            {
                Console.SetCursorPosition(this.customLevel[i].First().Key, this.customLevel[i].First().Value);
                Console.Write("#");
            }
        }

        private void UpdateCustomLevel(string fileName)
        {
            int[] wallCoordinates = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\levels\" + fileName + ".txt").Select(int.Parse).ToArray();
            this.customLevel.RemoveRange(0, this.customLevel.Count);
            for (int i = 0; i < wallCoordinates.Length; i += 2)
            {
                Dictionary<int, int> currentCoordinates = new Dictionary<int, int>();

                currentCoordinates.Add(wallCoordinates[i], wallCoordinates[i + 1]);
                this.customLevel.Add(currentCoordinates);
            }

        }

        private ConsoleKey UpdateLevelEditorCursor()
        {
            ConsoleKey editKey = ConsoleKey.Multiply;
            if (Console.KeyAvailable)
            {
                editKey = Console.ReadKey(true).Key;
            }

            if (editKey == ConsoleKey.RightArrow)
            {
                positionX++;
            }
            else if (editKey == ConsoleKey.DownArrow)
            {
                positionY++;
            }
            else if (editKey == ConsoleKey.LeftArrow)
            {
                positionX--;
            }
            else if (editKey == ConsoleKey.UpArrow)
            {
                positionY--;
            }

            Console.SetCursorPosition(positionX, positionY);
            return editKey;
        }

        private void PrintCustomLevels()
        {
            string[] levelNames = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\levels\", "*.txt").Select(Path.GetFileName).ToArray();
            Console.WriteLine("Levels:");
            for (int i = 0; i < levelNames.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {levelNames[i].Substring(0, levelNames[i].Length - 4)}");
            }
        }
    }
}
