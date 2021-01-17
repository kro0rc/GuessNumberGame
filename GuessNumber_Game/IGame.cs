using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber_Game.Game_Processor
{
    interface IGame
    {
        void GetTopSessionScore();
        void NewGame();
        void Step();
        bool AskRestart();
        bool QuitApplication();
    }
}
