using System;
using GuessNumber_Game.GameProcessor;
using GuessNumber_Game.UserInterface;

namespace GuessNumber_Game
{
    class Program
    {
        Game game = new Game();

        static void Main(string[] args)
        {
            Program program = new Program();
            program.LaunchGame();
        }

        public void LaunchGame()
        {
            game.Play();
        }
        
        
    }
}
