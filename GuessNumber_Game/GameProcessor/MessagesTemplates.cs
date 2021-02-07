using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber_Game.GameProcessor
{
    internal class MessagesTemplates
    {
        public const string Greetings = "Hello! This is game where you should guess number :)";
        public const string GuessedNumberMessage = "Well Done! You guessed the number :)";
        public const string AskUserNumberMessage = "Enter your number : ";
        public const string IncorrectInputMessage = "Incorrect input!";
        public const string NumberIsSmaller = "The number you've entered is smaller then guessed number";
        public const string NuberIsBigger = "The number you've entered is bigger then guessed number";
        public const string ExitOrRestart = "New game? Press R to resstart or Q to exit.";
        public const string RestartIsChosen = "New Round!";
        public const string ExitIsChosen = "Round Canceled!";
        public const string ByeBye = "Good Bye!";
    }
}
