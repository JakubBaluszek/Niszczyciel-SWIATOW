using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace paperscissors
{
    class AIPlayer : Player
    {
        Random random;
        readonly string[] names = new string[10] { "Szymon", "Kapitan Biceps", "Jakub", "Paulina", "Laura", "Dawid", "Łukasz", "Madzia", "Staszek", "Syn Golema" };
        

        public AIPlayer() {
            this.playerName += "[AI Player]";
            random = new Random();
        }

        public override void GetInput(Dictionary<string, string> inputTable)
        {
            lastInput = inputTable.ElementAt(random.Next(inputTable.Count)).Value;
        }

        public override void SetPlayerName()
        {
            random = new Random();
            playerName = names[random.Next(10)];
        }
    }
}
