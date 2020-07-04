using System;
using static System.Console;

class Player
{
    public string playerName;
    public int attack=10;
    public int hp=100;

    public Player(string playerName)
    {
        this.playerName = playerName;
    }
    public Player()
    {
        SetPlayerName();
    }

    public void SetPlayerName()
    {
        Write("podaj imie gracza gosciu: ");

        playerName = ReadLine();

        while (playerName.Length > 10 || playerName == "")
        {
            Write("imie jest dluzsze niz 10 znakow lub nic nie wpisales, podaj jeszcze raz i nie nerwuj czlowieka: ");
            playerName = ReadLine();

        }
    }
    public void showHP() { WriteLine("{0}'s has {1} hp left!\n", playerName, hp); }

    internal void reset()
    {
        this.hp = 100;
    }
    internal void hit(int atk)
    {
        this.hp -= atk;
    }
}