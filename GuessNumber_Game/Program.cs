using GuessNumber_Game.GameProcessor;
using GuessNumber_Game.UserInterface;
using Microsoft.Extensions.Configuration;

namespace GuessNumber_Game
{
    public class Program
    {
        static void Main(string[] args)
        {
            var configuration = InitConfiguration();
            GameTemplate game = new GuessNumberGame(new ConsoleInteraction(), configuration);
            game.Play();
        }

        public static IConfiguration InitConfiguration()
        {
            IConfiguration configuration = new ConfigurationBuilder()
               .AddJsonFile("appSettings.json", false, true)
               .Build();

            var cfg = configuration.GetSection("RandomizerSettings");
            return cfg;
        }
    }
}
