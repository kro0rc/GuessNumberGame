using System;
using Microsoft.Extensions.Configuration;
using GuessNumber_Game.UserInterface;



namespace GuessNumber_Game.GameProcessor
{
    public class GuessNumberGame : GameTemplate
    {
        public int UserNumber { get; private set; }
        public bool NumberIsNotGuessed { get; private set; }   
        public int MinNumberValue { get; private set; }
        public int MaxNumberValue { get; private set; }
        public int GuessedNumber { get; private set; }
        public bool IsContinueGame { get; private set; }
        private readonly string _keyToExit = "q"; 

        public GuessNumberGame(IGameInteraction interactionRealiztion, IConfiguration configuration) : base(interactionRealiztion)
        {
            gameInteraction.ShowGameResponse(MessagesTemplates.Greetings);
            this.MinNumberValue = configuration.GetValue<int>("MinValue");
            this.MaxNumberValue = configuration.GetValue<int>("MaxValue");
        }

        public override void Play()
        {
            Random random = new Random();

            this.NumberIsNotGuessed = true;
            this.IsContinueGame = true;
            this.GuessedNumber = random.Next(this.MinNumberValue, this.MaxNumberValue);

            while (this.NumberIsNotGuessed && this.IsContinueGame)
            {
                CheckUserInput();
                if (this.IsContinueGame)
                {
                    this.NumberIsNotGuessed = GetResult();
                }
            }

            if (!this.NumberIsNotGuessed)
            {
                gameInteraction.ShowGameResponse(MessagesTemplates.GuessedNumberMessage);
            }

           InitNewGame();
        }

        protected override void CheckUserInput()
        {
            string userInput = AskUser(MessagesTemplates.AskUserNumberMessage);

            //TODO: Delete line below
            Console.WriteLine(userInput);
            
            if (Int32.TryParse(userInput, out int parsedNumber))
            {
                this.UserNumber = parsedNumber;
            }
            else if (userInput == this._keyToExit)
            {
                CancelRound();
            }
            else
            {
                gameInteraction.ShowGameResponse(MessagesTemplates.IncorrectInputMessage);
                CheckUserInput();
            }  
        }

        protected override string AskUser(string message)
        {
            gameInteraction.ShowGameResponse(message);

            return gameInteraction.GetUserInput();
        }

        protected override bool GetResult()
        {
            if (this.GuessedNumber == this.UserNumber)
            {
                return false;
            }

            else if (this.GuessedNumber > this.UserNumber)
            {
                gameInteraction.ShowGameResponse(MessagesTemplates.NumberIsSmaller);
            }

            else if (this.GuessedNumber < this.UserNumber)
            {
                gameInteraction.ShowGameResponse(MessagesTemplates.NumberIsBigger);
            }

            return true;
        }

        protected override void InitNewGame()
        {
            gameInteraction.ShowGameResponse(MessagesTemplates.ExitOrRestart);
            bool userDecision = gameInteraction.ExitRestartDialog();

            if (userDecision)
            {
                gameInteraction.ShowGameResponse(MessagesTemplates.RestartIsChosen);
                this.Play();
            }
            else
            {
                gameInteraction.ShowGameResponse(MessagesTemplates.ByeBye);
            }
        }

        protected override void CancelRound()
        {
            this.IsContinueGame = false;
            gameInteraction.ShowGameResponse(MessagesTemplates.ExitIsChosen);
        }
    }
}
