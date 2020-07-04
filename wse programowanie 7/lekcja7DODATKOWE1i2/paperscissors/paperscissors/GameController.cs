using System;
using System.Collections.Generic;
using System.Text;

namespace paperscissors
{
    class GameController
    {
        Game game;
        GamesRecord gamesRecord;


        public GameController() 
        {
            gamesRecord = new GamesRecord();
           
        }

        
        static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Witaj graczu, opowiemy ci historię");

        }
        public void MainMenuLoop()//bool AI)
        {
            ConsoleKeyInfo inputKey;
            do
            {
                Console.Clear();
                Console.WriteLine("Rock-Paper-Scissors Menu:\n\t[1] Play vs human\n\t[2] Play vs robot\n\t[3] Show rules\n\t[4] Display last games' record\n\t[ESC] Exit");
                inputKey = Console.ReadKey(true);

                if (inputKey.Key == ConsoleKey.D1)
                {
                    game = new Game();
                    game.Play();// AI);
                    gamesRecord += game.gamesRecord;
                }
                else if (inputKey.Key == ConsoleKey.D2)
                {
                    game = new Game(true);
                    game.Play();// AI);
                    gamesRecord += game.gamesRecord;
                }
                else if (inputKey.Key == ConsoleKey.D3)
                {
                    game.DisplayRules(false);
                }
                else if (inputKey.Key == ConsoleKey.D4)
                {
                    gamesRecord.DisplayGamesHistory();
                }
                else { continue; }

                Console.WriteLine("(click any key to continue)");
                Console.ReadKey(true);
            } while (inputKey.Key != ConsoleKey.Escape);
        }

        

    }
}
