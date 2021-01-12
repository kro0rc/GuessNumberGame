using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber_Game
{
    class UserChecker
    {
        public bool Result;
        public void CheckUserAnswer(int generatedNumber, int userNumber)
        {
            if (userNumber == generatedNumber)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Congratulations! You guessed number :)");
                Console.ResetColor();

                this.Result = true;

                return;
            }

            if (userNumber > generatedNumber)
            {
                Console.WriteLine("Your number is greater then should be. Try again...");
            }

            if (userNumber < generatedNumber)
            {
                Console.WriteLine("Your number is less then should be. Try again...");
            }

            this.Result = false;
        }
    }
}
