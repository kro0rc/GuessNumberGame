using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber_Game.UserInterface
{
    public class ConsoleIteraction : IGameIteraction
    {
        public string GetUserInput()
        {           
            return Console.ReadLine();
        }

        public void ShowGameResponse(string str)
        {
            Console.WriteLine(str);
        }

        public bool ExitRestartDialog()
        {
            var input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.R:
                    Console.Clear();
                    return true;

                case ConsoleKey.Q:
                    Console.Clear();
                    return false;

                default:
                    break;
            }

            return ExitRestartDialog();
        }
    }
}
