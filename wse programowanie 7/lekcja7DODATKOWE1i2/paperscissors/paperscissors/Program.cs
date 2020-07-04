using System;

namespace paperscissors
{
    class Program
    {


        static void Main(string[] args)
        {           

            GameController gameController = new GameController();
            gameController.MainMenuLoop();
        }
    }
}
