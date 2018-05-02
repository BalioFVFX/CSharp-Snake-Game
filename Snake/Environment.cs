using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Environment
    {

        public static void DrawFood(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("*");
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

                    Console.SetCursorPosition(100, 27);
                    Console.Write("By: BalioFVFX");
                    break;
                default:
                    break;
            }
        }
    }
}
