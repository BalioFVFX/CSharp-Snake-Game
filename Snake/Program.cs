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
            Console.CursorVisible = false;

            Game game = new Game();

            game.Menu();

            while (game.level != 9)
            {
                if(game.GameOver == false)
                {
                    game.StartGame();
                }
                else
                {
                    game.Menu();
                }
            }

            
        }
    }
}