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

        public static void DrawInstructions()
        {
            Console.SetCursorPosition(85, 23);
            Console.Write("Use the Arrows to navigate.");
            Console.SetCursorPosition(85, 24);
            Console.Write("Press Enter to place a block.");
            Console.SetCursorPosition(85, 25);
            Console.Write("Press Delete to delete a block.");
            Console.SetCursorPosition(85, 26);
            Console.Write("Press Esc to exit.");
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
