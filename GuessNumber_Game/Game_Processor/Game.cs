using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber_Game.Game_Processor
{
    public class Game : IGame
    {
        public int RandomNumber;
        public Game()
        {
            Random random = new Random();
            this.RandomNumber = random.Next(0, 101);
        }

        public bool AskRestart()
        {
            throw new NotImplementedException();
        }

        public void GetTopSessionScore()
        {
            throw new NotImplementedException();
        }

        public void NewGame()
        {

        }

        public bool QuitApplication()
        {
            throw new NotImplementedException();
        }

        public void Step()
        {
            throw new NotImplementedException();
        }
    }
}
