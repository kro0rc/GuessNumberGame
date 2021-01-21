using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber_Game.UserInterface
{
    public class OutputAdapter : IGameIteraction
    {
        public bool UserDecision;

        public OutputAdapter()
        {
            Console.WriteLine("Hello! This is game where you should guess number :)");
        }
        public string GetUserInput()
        {
            return Console.ReadLine();
        }

        public void ShowGameResponse(string str)
        {
            Console.WriteLine(str);
        }

        public bool GetUserDecision()
        {
            var input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.R:
                    Console.Clear();
                    return true;

                case ConsoleKey.Q:
                    Console.Clear();
                    Console.WriteLine("Good Bye!");
                    return false;

                default:
                    break;
            }

            return GetUserDecision();
        }
    }
}
