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


            Game game = new Game();

           

            game.Menu();

            while (game.level != 3)
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