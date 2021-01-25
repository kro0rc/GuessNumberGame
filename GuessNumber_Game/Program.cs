using GuessNumber_Game.GameProcessor;
using GuessNumber_Game.UserInterface;

namespace GuessNumber_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            GameTemplate game = new GuessNumberGame(new ConsoleIteraction());
            game.Play();
        }

        
    }
}
