using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    class Environment
    {

        private static ConsoleColor Color = ConsoleColor.White;

        public static void DrawFood(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("*");
        }


        public static void DrawMArea()
        {
            // TOP
            Console.SetCursorPosition(35, 5);
            for (int i = 20; i <= 70; i++)
            {
                Console.Write("#");
            }

            // BOTTOM
            Console.SetCursorPosition(35, 20);
            for (int i = 20; i <= 70; i++)
            {
                Console.Write("#");
            }

            // LEFT
            
            for (int i = 6; i <= 19; i++)
            {
                Console.SetCursorPosition(35, i);
                Console.Write("#");
            }

            // RIGHT

            for (int i = 6; i <= 19; i++)
            {
                Console.SetCursorPosition(85, i);
                Console.Write("#");
            }
        }
        public static void DrawCustomArea(List<Dictionary<int, int>> customLevel)
        {
            Console.Clear();
            DrawMArea();
            for (int i = 0; i < customLevel.Count; i++)
            {
                Console.SetCursorPosition(customLevel[i].First().Key, customLevel[i].First().Value);
                Console.Write("#");
            }
        }

        public static void DrawArea(int level)
        {
            Console.ForegroundColor = Color;
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

                    Console.ForegroundColor = ConsoleColor.White;
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

                    // Tunnel TOP
                    for (int i = 50; i < 71; i++)
                    {
                        Console.SetCursorPosition(i, 10);
                        Console.Write("#");
                    }

                    // Tunnel BOTTOM
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

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(100, 27);
                    Console.Write("By: BalioFVFX");
                    break;
                case 3:
                    // TOP
                    for (int i = 41; i <= 77; i++)
                    {
                        Console.SetCursorPosition(i, 5);
                        Console.Write("#");
                    }

                    // LEFT
                    for (int i = 6; i <= 19; i++)
                    {
                        Console.SetCursorPosition(41, i);
                        Console.WriteLine("#");
                    }

                    // RIGHT
                    for (int i = 6; i <= 19; i++)
                    {
                        Console.SetCursorPosition(77, i);
                        Console.WriteLine("#");
                    }

                    // DOWN
                    for (int i = 41; i <= 77; i++)
                    {
                        Console.SetCursorPosition(i, 20);
                        Console.Write("#");
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(100, 27);
                    Console.Write("By: BalioFVFX");
                    break;

                case 4:
                    // TOP
                    for (int i = 41; i <= 55; i++)
                    {
                        Console.SetCursorPosition(i, 5);
                        Console.Write("#");
                    }

                    // LEFT
                    for (int i = 6; i <= 10; i++)
                    {
                        Console.SetCursorPosition(41, i);
                        Console.WriteLine("#");
                    }

                    // RIGHT
                    for (int i = 6; i <= 10; i++)
                    {
                        Console.SetCursorPosition(55, i);
                        Console.WriteLine("#");
                    }

                    // DOWN
                    for (int i = 41; i <= 55; i++)
                    {
                        Console.SetCursorPosition(i, 10);
                        Console.Write("#");
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(100, 27);
                    Console.Write("By: BalioFVFX");
                    break;
                case 5:

                    break;
                default:
                    break;
            }
            
        }

        public static void SetColor()
        {
            Console.WriteLine("Select environment color 1 - 4");
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
    }
}
