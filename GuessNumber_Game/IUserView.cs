using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber_Game.User_View
{
    interface IUserView
    {
        void MainDialog();
        void ShowTopScore();
        int GetUserInput(string message);
    }
}
