using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber_Game.UserInterface
{
    public interface IGameIteraction
    {
        public string GetUserInput();
        public void ShowGameResponse(string str);
        public bool ExitRestartDialog();
    }
}
