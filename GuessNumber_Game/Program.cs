using System;

namespace GuessNumber_Game
{
    class Program
    {
        Randomizer randomizer = new Randomizer();
        
        static void Main(string[] args)
        {
            Program program = new Program();
            program.StartGame();
        }

        public void StartGame()
        {
            Console.WriteLine("Try guess the number :)\nNumber is in range from 0 to 100.");
            int generatedNumber = randomizer.GetRandomNumber();
            GameProcess game = new GameProcess();
            game.NewGame(generatedNumber);
            ExitDialog(UserInput("Choose optinos below : \n1. Try again\n2. Exit game"));
        }

        public int UserInput(string message)
        {
            Console.WriteLine(message);
            
            if ((Int32.TryParse(Console.ReadLine(), out int result)) && result> 0 && result < 3)
            {
                return result;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.WriteLine("Wrong input!");
            Console.ResetColor();

            return UserInput(message);
        }

        public void ExitDialog(int decision)
        {
            if (decision == 1)
            {
                StartGame();
            }

            if (decision == 2)
            {
                Console.WriteLine("Good Bye!");
            }
        }
    }
}
