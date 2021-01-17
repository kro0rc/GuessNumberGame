using System;
using GuessNumber_Game.User_View;
using GuessNumber_Game.Game_Processor;

namespace GuessNumber_Game
{
    class Program
    {
        IUserView ui = new UserView();
        IScoreKeeper scoreKeeper = new SessionScoreKeeper();

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }

        private void Start()
        {
            ui.MainDialog();
        }

    }
}
