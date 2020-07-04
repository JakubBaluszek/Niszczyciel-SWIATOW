using System;
using System.Collections.Generic;
using static System.Console;

namespace paperscissors
{
    class Player
    {
        public string playerName;
        public int attack = 10;
        public int hp = 100;
        public string lastInput;

        public Player(string playerName)
        {
            this.playerName = playerName;
        }
        public Player()
        {
            SetPlayerName();
        }

        virtual public void SetPlayerName()
        {
            Write("podaj imie gracza gosciu: ");

            playerName = ReadLine();

            while (playerName.Length > 10 || playerName == "")
            {
                Write("imie jest dluzsze niz 10 znakow lub nic nie wpisales, podaj jeszcze raz i nie nerwuj czlowieka: ");
                playerName = ReadLine();

            }
        }
        virtual public void GetInput(Dictionary<string, string> inputTable)
        {
            string rawInput;
            WriteLine("{0}, Choose:", playerName);
            foreach (KeyValuePair<string, string> entry in inputTable)
            {
                WriteLine("[{0}] {1}", entry.Key, entry.Value);
            }
            rawInput = ReadLine();
            while (!inputTable.TryGetValue(rawInput, out lastInput))
            {
                WriteLine("Wrong input. Please enter correct one.");
                rawInput = ReadLine();
            }

        }

        public void showHP() { WriteLine("{0}'s has {1} hp left!\n", playerName, hp); }

        internal void Reset()
        {
            hp = 100;
        }
        internal void hit(int atk)
        {
            hp -= atk;
        }
    }
}