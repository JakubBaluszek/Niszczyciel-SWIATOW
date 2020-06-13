using System;
using static System.Console;

class Player {
public string playerName;
  public Player (string playerName) {
   this.playerName = playerName;
  }
  public Player () {
   SetPlayerName();
  }

  public void SetPlayerName () {
    Write("podaj imie gracza gosciu: ");

    playerName = ReadLine();

    while(playerName.Length > 10 || playerName=="")
    { 
         Write("imie jest dluzsze niz 10 znakow lub nic nie wpisales, podaj jeszcze raz i nie prowokuj doktora czlowieka: ");
         playerName = ReadLine();

    }
  }

}