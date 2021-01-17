using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber_Game.User_View
{
    public class UserView : IUserView
    {
        public void MainDialog()
        {
            ViewMenu();
            int menuItem = GetUserInput("\nEnter number of chosed item in menu : ");
        }

        public int GetUserInput(string message)
        {
            Console.WriteLine(message);

            if (Int32.TryParse(Console.ReadLine(), out int result))
            {
                return result;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.WriteLine("Incorrect input. Try again");
            Console.ResetColor();

            return GetUserInput(message);
        }

        public void ShowTopScore()
        {

        }

        private void ViewMenu()
        {
            Console.Clear();
            string title = "Guess Number Game";
            int centerX = (Console.WindowWidth / 2) - (title.Length / 2);
            Console.SetCursorPosition(centerX, 0);
            Console.WriteLine(title + "\n");
            Console.WriteLine("1. New game\n" + "2. Show session stats\n" + "3. Exit");
        }
    }
}
