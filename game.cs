using System;
using static System.Console;

class Game {
Player playerOne, playerTwo;
GamesRecord gamesRecord;

public Game (int inputGamesRecordSize=10) {
    playerOne = new Player ();
    playerTwo = new Player ();
    gamesRecord = new GamesRecord (inputGamesRecordSize);
    MainMenuLoop ();
}
public void DisplayRules (bool withWelcomeMessage = true) {
    if (withWelcomeMessage) {
      WriteLine ("Witaj graczu, opowiemy ci historię");
    }
      WriteLine ("The rules are very simple - each player chooses Rock, Paper or Scissors choice by entering the choice's number\n[1] Rock\n[2] Paper\n[3] Scissors\nand confirm it by clicking Enter.\nAfter both player choose, the winner is determined. After each game the application will ask the players if they want to continue, and if the player repond with anything else than [y]es than the game finishes and presents the record of the last up to 10 games.\n\nHave fun!");
}

public string GetPlayerInput (Player player){
  string rawInput;
  string properInput;
  WriteLine ("{0}, Choose:\n[1] Rock\n[2] Paper\n[3] Scissors", player.playerName);
  rawInput = ReadLine();
  while (rawInput != "1" && rawInput != "2" && rawInput != "3") {
  WriteLine ("Wrong input. Please enter correct one.\nPlayer One, choose:\n[1] Rock\n[2] Paper\n[3] Scissors");
  rawInput = ReadLine();
}
  if (rawInput == "1") { properInput = "Rock"; }
  else if (rawInput == "2") { properInput = "Paper"; }
  else { properInput = "Scissors"; }
return properInput;
}

public string DetermineWinner (string wyborpierwszegogracza, string wybordrugiegogracza)
{
     if (wyborpierwszegogracza == wybordrugiegogracza){
          WriteLine ("Remis");         
          return "nie przelala sie krew";}
      if (wyborpierwszegogracza == "Rock" && wybordrugiegogracza == "Paper")
        {
          WriteLine ("wygral Doktor Biceps czyli " + playerTwo.playerName );  
          return playerTwo.playerName+" czyli Doktor Biceps obronil swe wlosci";
        }
      if (wyborpierwszegogracza == "Rock" && wybordrugiegogracza == "Scissors")
        {
          WriteLine ("wygral PlayerONE czyli"+ playerOne.playerName);      
          return  playerOne.playerName + " czyli playerone destroy the game";
        }
      if (wyborpierwszegogracza == "Paper" && wybordrugiegogracza == "Rock")
        {
          WriteLine ("wygral PlayerONE czyli"+ playerOne.playerName);      
          return playerOne.playerName + " czyli playerone destroy the game";
        }
      if (wyborpierwszegogracza == "Paper" && wybordrugiegogracza == "Scissors")
        {
          WriteLine ("wygral Doktor Biceps czyli " + playerTwo.playerName );  
          return playerTwo.playerName+" czyli Doktor Biceps obronil swe wlosci";
        }
      if (wyborpierwszegogracza == "Scissors" && wybordrugiegogracza == "Rock")
        {
          WriteLine ("wygral Doktor Biceps czyli " + playerTwo.playerName );  
          return playerTwo.playerName+" czyli Doktor Biceps obronil swe wlosci";
        }
      if (wyborpierwszegogracza == "Scissors" && wybordrugiegogracza == "Paper")
        {
          WriteLine ("wygral PlayerONE czyli"+ playerOne.playerName);      
          return playerOne.playerName + " czyli playerone destroy the game";
        }
        
       else return "pokwasiorilo sie";
      
}
public void Play () 
{
    Clear ();
    string firstPlayerChoiceString = GetPlayerInput(playerOne);

    Clear ();
    string secondPlayerChoiceString = GetPlayerInput(playerTwo);

    Clear ();

    string gameResult = DetermineWinner(firstPlayerChoiceString,
secondPlayerChoiceString);
    gamesRecord.AddRecord(firstPlayerChoiceString, secondPlayerChoiceString, gameResult);
    
     Console.WriteLine ("Doktor Biceps, czy chcesz się znowu upokorzyć? Wpisz [y] żeby walczyć o czarne złoto [PB]");
      if (ReadKey(true).Key == ConsoleKey.Y){
          Play();
      }
}

public void MainMenuLoop (){
    ConsoleKeyInfo inputKey;
    do {
      Clear();
      WriteLine ("Rock-Paper-Scissors Menu:\n\t[1] Play a game\n\t[2] Show rules\n\t[3] Display last games' record\n\t[ESC] Exit");
      inputKey = ReadKey(true);

      if (inputKey.Key == ConsoleKey.D1){
        Play();
      }
      else if (inputKey.Key == ConsoleKey.D2){
        DisplayRules(false);
      }
      else if (inputKey.Key == ConsoleKey.D3){
        gamesRecord.DisplayGamesHistory();
      }
      else { continue; }
      
      WriteLine ("(click any key to continue)");
      ReadKey(true);
    } while (inputKey.Key != ConsoleKey.Escape);
}

}