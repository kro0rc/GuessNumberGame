using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber_Game
{
    class Randomizer
    {
        public int GetRandomNumber()
        {
            Random random = new Random();
            int randomNum = random.Next(0, 100);
            return randomNum;
        }
    }
}
