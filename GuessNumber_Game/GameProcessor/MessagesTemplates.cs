using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber_Game.GameProcessor
{
    internal class MessagesTemplates
    {
        public readonly string Greetings = "Hello! This is game where you should guess number :)";
        public readonly string GuessedNumberMessage = "Well Done! You guessed the number :)";
        public readonly string AskUserNumberMessage = "Enter your number : ";
        public readonly string IncorrectInputMessage = "Incorrect input!";
        public readonly string NumberIsSmaller = "The number you've entered is smaller then guessed number";
        public readonly string NuberIsBigger = "The number you've entered is bigger then guessed number";
        public readonly string ExitOrRestart = "New game? Press R to resstart or Q to exit.";
        public readonly string RestartIsChosen = "New Round!";
        public readonly string ExitIsChosen = "Round Canceled!";
        public readonly string ByeBye = "Good Bye!";
    }
}
