using System;
using System.Collections.Generic;
using System.Text;
using GuessNumber_Game.UserInterface;

namespace GuessNumber_Game.GameProcessor
{
    public class Game : GameTemplate
    {
        public int GuessedNumber;
        public int UserNumber;
        public bool Coincidense;
        public bool ExitRoundIsChosen;

        Random random = new Random();
        IGameIteraction adapter = new OutputAdapter();

        public override void Play()
        {
            this.Coincidense = false;
            this.ExitRoundIsChosen = false;
            this.GuessedNumber = random.Next(0, 101);

            while (!this.Coincidense && !this.ExitRoundIsChosen)
            {
                CheckUserInput();
                if (!this.ExitRoundIsChosen)
                {
                    this.Coincidense = GetResult();
                }
            }

            if (this.Coincidense)
            {
                adapter.ShowGameResponse("Well Done! You guessed the number :)");
            }

            InitNewGame();
        }

        protected override void CheckUserInput()
        {
            string userInput = AskUser("Enter your number : ");

            if (Int32.TryParse(userInput, out int parsedNumber))
            {
                this.UserNumber = parsedNumber;
            }
            else if (userInput == "q")
            {
                CancelRound();
            }
            else
            {
                adapter.ShowGameResponse("Incorrect input!");
                CheckUserInput();
            }  
        }

        protected override string AskUser(string message)
        {
            adapter.ShowGameResponse(message);
            return adapter.GetUserInput();
        }

        protected override bool GetResult()
        {
            if (this.GuessedNumber == this.UserNumber)
            {
                return true;
            }

            if (this.GuessedNumber > this.UserNumber)
            {
                InformUser("smaller");
            }

            if (this.GuessedNumber < this.UserNumber)
            {
                InformUser("bigger");
            }

            return false;
        }

        protected override void InformUser(string comparisonResult)
        {
            adapter.ShowGameResponse($"The number you've entered is {comparisonResult} then guessed number");
        }

        protected override void InitNewGame()
        {
            adapter.ShowGameResponse("New game? Press R to resstart or Q to exit.");
            bool userDecision = adapter.GetUserDecision();

            if (userDecision)
            {
                adapter.ShowGameResponse("New Round!");
                this.Play();
            }

        }

        protected override void CancelRound()
        {
            this.ExitRoundIsChosen = true;
            adapter.ShowGameResponse("Round Canceled!");
        }
    }
}
