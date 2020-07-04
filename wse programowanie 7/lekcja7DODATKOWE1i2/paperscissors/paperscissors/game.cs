using System;
using System.Collections.Generic;
using static System.Console;

namespace paperscissors
{
    class Game
    {
        public Player playerOne, playerTwo;
        public GamesRecord gamesRecord;

        public Game(bool singleplayer = false)
        {

           

            playerOne = new Player();

            if (singleplayer)
                playerTwo = new AIPlayer();
            else
                playerTwo = new Player();
            gamesRecord = new GamesRecord();


        }
        public void DisplayRules(bool withWelcomeMessage = true)
        {
            if (withWelcomeMessage)
            {
                WriteLine("Witaj graczu, opowiemy ci historię");
            }
            WriteLine("The rules are very simple - each player chooses Rock, Paper or Scissors choice by entering the choice's number\n[1] Rock\n[2] Paper\n[3] Scissors\nand confirm it by clicking Enter.\nAfter both player choose, the winner is determined. After each game the application will ask the players if they want to continue, and if the player repond with anything else than [y]es than the game finishes and presents the record of the last up to 10 games.\n\nHave fun!");
        }

        public string GetPlayerInput(Player player)
        {
            string rawInput;
            string properInput;
            WriteLine("{0}, Choose:\n[1] Rock\n[2] Paper\n[3] Scissors", player.playerName);
            rawInput = ReadLine();
            while (rawInput != "1" && rawInput != "2" && rawInput != "3")
            {
                WriteLine("Wrong input. Please enter correct one.\nPlayer One, choose:\n[1] Rock\n[2] Paper\n[3] Scissors");
                rawInput = ReadLine();
            }
            if (rawInput == "1") { properInput = "Rock"; }
            else if (rawInput == "2") { properInput = "Paper"; }
            else { properInput = "Scissors"; }
            return properInput;
        }
        public string GetAiAnswer()
        {
            var randomnizer = new Random();
            int rawInput = randomnizer.Next(1, 3);

            if (rawInput == 1) { return "Rock"; }
            else if (rawInput == 2) { return "Paper"; }
            else { return "Scissors"; }

        }
        Dictionary<string, string> inputTable = new Dictionary<string, string>()
    {
      {"1", "Rock"},
      {"2", "Paper"},
      {"3", "Scissors"}
    };


        public int DetermineWinner(string wyborpierwszegogracza, string wybordrugiegogracza)
        {
            if (wyborpierwszegogracza == wybordrugiegogracza)
            {
                return 3;
            }
            if (wyborpierwszegogracza == "Rock" && wybordrugiegogracza == "Paper")
            {
                return 2;
            }
            if (wyborpierwszegogracza == "Rock" && wybordrugiegogracza == "Scissors")
            {
                return 1;
            }
            if (wyborpierwszegogracza == "Paper" && wybordrugiegogracza == "Rock")
            {

                return 1;
            }
            if (wyborpierwszegogracza == "Paper" && wybordrugiegogracza == "Scissors")
            {

                return 2;
            }
            if (wyborpierwszegogracza == "Scissors" && wybordrugiegogracza == "Rock")
            {

                return 2;
            }
            if (wyborpierwszegogracza == "Scissors" && wybordrugiegogracza == "Paper")
            {

                return 1;
            }
            else { return 99; }
        }

        public string yellWinner(int fin)
        {
            if (fin == 1)
            {
                WriteLine("wygral PlayerONE czyli" + playerOne.playerName);
                return playerOne.playerName + " czyli playerone destroy the game";

            }

            else if (fin == 2)
            {
                WriteLine("wygral Doktor Biceps czyli " + playerTwo.playerName);
                return playerTwo.playerName + " czyli Doktor Biceps obronil swe wlosci";
            }
            else
            {
                WriteLine("Remis");
                return "nie przelala sie krew";
            }

        }
        public void Play()
        {
            Clear();
            playerOne.GetInput(inputTable);
            playerTwo.GetInput(inputTable);
            /* string firstPlayerChoiceString = GetPlayerInput(playerOne);
             string secondPlayerChoiceString;

             Clear();
             if(AI==false)
                 secondPlayerChoiceString = GetPlayerInput(playerTwo);
             else
                 secondPlayerChoiceString = GetAiAnswer();
             Clear();
            */

            string gameResult = yellWinner(DetermineWinner(playerOne.lastInput, playerTwo.lastInput));
            gamesRecord.AddRecord(playerOne.lastInput, playerTwo.lastInput, gameResult);

            Console.WriteLine("Doktor Biceps, czy chcesz się znowu upokorzyć? Wpisz [y] żeby walczyć o czarne złoto [PB]");
            if (ReadKey(true).Key == ConsoleKey.Y)
            {
                Play();
            }
        }
       /* public void Duel(bool AI)
        {
            Clear();
            string firstPlayerChoiceString = GetPlayerInput(playerOne);
            string secondPlayerChoiceString;

            Clear();
            if (AI == false)
                secondPlayerChoiceString = GetPlayerInput(playerTwo);
            else
                secondPlayerChoiceString = GetAiAnswer();
            Clear();

            int gameResult = DetermineWinner(firstPlayerChoiceString, secondPlayerChoiceString);


            if (gameResult == 2)
                playerOne.hit(playerTwo.attack);
            else if (gameResult == 1)
                playerTwo.hit(playerOne.attack);

            yellWinner(gameResult);
            playerOne.showHP();
            playerTwo.showHP();

            if (playerOne.hp <= 0)
                Console.WriteLine("Wygral {0}\n", playerOne.playerName);
            else if (playerTwo.hp <= 0)
                Console.WriteLine("Wygral {0}\n", playerTwo.playerName);
            else
            {
                Console.WriteLine("Doktor Biceps, czy chcesz się znowu upokorzyć? Wpisz [y] żeby walczyć o czarne złoto (PB)]\n");
                if (ReadKey(true).Key == ConsoleKey.Y)
                {
                    Duel(AI);
                }
            }
        }
        public bool chooseGameFormat()
        {



            while (true)
            {

                Console.WriteLine("Game format Menu:\n\t[1] 2 human players \n\t[2] human and computer \n\t");
                string answ = ReadLine();
                if (answ == "1")
                {
                    return false;
                }
                else if (answ == "2")
                {
                    return true;
                }
                Clear();
                Console.WriteLine("Type [1] or [2] \n\t");
            }
        }*/



    }
}