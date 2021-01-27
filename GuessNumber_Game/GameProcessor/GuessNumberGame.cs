using System;
using Microsoft.Extensions.Configuration;


namespace GuessNumber_Game.GameProcessor
{
    public class GuessNumberGame : GameTemplate
    {
        public int UserNumber;
        public bool Coincidense { get; private set; }
        public bool IsContinueGame { get; private set; }        
        public int MinNumberValue { get; private set; }
        public int MaxNumberValue { get; private set; }
        private int _guessedNumber;


        MessagesTemplates messages = new MessagesTemplates();

        public GuessNumberGame(object IteractionRealiztion) : base(IteractionRealiztion)
        {
            gameIteraction.ShowGameResponse(messages.Greetings);

            var configuration = InitConfiguration();

            this.MinNumberValue = configuration.RandomizerSettings.MinValue;
            this.MaxNumberValue = configuration.RandomizerSettings.MaxValue;
        }

        private static AppSettings InitConfiguration()
        {
            IConfiguration configuration = new ConfigurationBuilder()
               .AddJsonFile("appSettings.json", false, true)
               .Build();

            var cfg = configuration.Get<AppSettings>();
            return cfg;
        }

        public override void Play()
        {
            Random random = new Random();

            this.Coincidense = false;
            this.IsContinueGame = true;
            this._guessedNumber = random.Next(this.MinNumberValue, this.MaxNumberValue);

            while (!this.Coincidense && this.IsContinueGame)
            {
                CheckUserInput();
                if (this.IsContinueGame)
                {
                    this.Coincidense = GetResult();
                }
            }

            if (this.Coincidense)
            {
                gameIteraction.ShowGameResponse(messages.GuessedNumberMessage);
            }

           InitNewGame();
        }

        protected override void CheckUserInput()
        {
            string userInput = AskUser(messages.AskUserNumberMessage);
  
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
                gameIteraction.ShowGameResponse(messages.IncorrectInputMessage);
                CheckUserInput();
            }  
        }

        protected override string AskUser(string message)
        {
            gameIteraction.ShowGameResponse(message);

            return gameIteraction.GetUserInput();
        }

        protected override bool GetResult()
        {
            if (this._guessedNumber == this.UserNumber)
            {
                return true;
            }

            else if (this._guessedNumber > this.UserNumber)
            {
                gameIteraction.ShowGameResponse(messages.NumberIsSmaller);
            }

            else if (this._guessedNumber < this.UserNumber)
            {
                gameIteraction.ShowGameResponse(messages.NuberIsBigger);
            }

            return false;
        }

        protected override void InitNewGame()
        {
            gameIteraction.ShowGameResponse(messages.ExitOrRestart);
            bool userDecision = gameIteraction.ExitRestartDialog();

            if (userDecision)
            {
                gameIteraction.ShowGameResponse(messages.RestartIsChosen);
                this.Play();
            }
            else
            {
                gameIteraction.ShowGameResponse(messages.ByeBye);
            }
        }

        protected override void CancelRound()
        {
            this.IsContinueGame = false;
            gameIteraction.ShowGameResponse(messages.ExitIsChosen);
        }
    }
}
