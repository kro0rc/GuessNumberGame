using System;
using System.Collections.Generic;
using System.Text;
using GuessNumber_Game.Game_Processor;

namespace GuessNumber_Game.Game_Processor
{
    class SessionScoreKeeper : IScoreKeeper
    {
        public int TotalGameAttempts;
        public int BestScore;
        public int WorstScore;
        public int CanceledRounds;

        public void GetSessionScore()
        {
            throw new NotImplementedException();
        }
    }
}
