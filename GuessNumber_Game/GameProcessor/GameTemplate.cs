using System;
using GuessNumber_Game.UserInterface;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber_Game.GameProcessor
{
    public abstract class GameTemplate
    { 
        public GameTemplate(object IteractionRealiztion)
        {
            gameIteraction = (IGameIteraction)IteractionRealiztion;
        }
        public abstract void Play();
        protected readonly IGameIteraction gameIteraction;
        protected abstract void InitNewGame();
        protected abstract void CancelRound();
        protected abstract string AskUser(string str);
        protected abstract void CheckUserInput();
        protected abstract bool GetResult();
    }
}
