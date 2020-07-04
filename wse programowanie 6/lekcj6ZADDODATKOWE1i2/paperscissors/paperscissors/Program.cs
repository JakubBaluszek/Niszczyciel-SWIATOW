using System;

namespace paperscissors
{
    class Program
    {

        static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Witaj graczu, opowiemy ci historię");
            
        }
        static void Main(string[] args)
        {


            //MainMenuLoop();
            Game game = new Game();
        }
    }
}
