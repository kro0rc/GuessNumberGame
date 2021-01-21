using System;
using GuessNumber_Game.UserInterface;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber_Game.GameProcessor
{
    public abstract class GameTemplate
    {
        public abstract void Play();
        protected abstract void InitNewGame();
        protected abstract void CancelRound();
        protected abstract string AskUser(string str);
        protected abstract void CheckUserInput();
        protected abstract bool GetResult();
        protected abstract void InformUser(string str);

    }
}
