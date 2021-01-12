﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber_Game
{
    public class GameProcess
    {
        UserChecker userChecker = new UserChecker();
        
        public void NewGame(int generatedNumber)
        {
            bool process = true;
            Console.WriteLine("Type \"q\" to exit.");

            while (process && userChecker.Result != true)
            {
                Console.WriteLine("Enter your number : ");
                string input = Console.ReadLine();

                if (input == "q")
                {
                    Console.WriteLine("You exited this round!");
                    process = false;
                }
            
                if (Int32.TryParse(input, out int result))
                {
                    userChecker.CheckUserAnswer(generatedNumber, result);
                }
            }
        }


    }
}
