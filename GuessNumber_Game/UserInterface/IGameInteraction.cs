using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber_Game.UserInterface
{
    public interface IGameInteraction
    {
        public string GetUserInput();
        public void ShowGameResponse(string str);
        public bool ExitRestartDialog();
    }
}
