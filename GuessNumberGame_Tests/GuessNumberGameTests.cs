using Microsoft.VisualStudio.TestTools.UnitTesting;
using GuessNumber_Game.GameProcessor;
using GuessNumber_Game.UserInterface;
using GuessNumber_Game;
using Microsoft.Extensions.Configuration;

namespace GuessNumberGame_Tests
{
    

    [TestClass]
    class GuessNumberGameTests
    {
        GuessNumberGame game;
        IConfiguration configuration;

        [TestCleanup]
        public void TestCleanUp()
        {
            game = null;
            configuration = null;
        }

        [TestInitialize]
        public void TestInitialize()
        {
            configuration = Program.InitConfiguration();
            game = new GuessNumberGame(new ConsoleInteraction(), configuration);
        }

        [TestMethod]
        public void CheckPropertiesSettedWithConfiguration()
        {
            int expectedMaxValue = 101;
            int expectedMinValue = 0;

            Assert.AreEqual(expectedMinValue, game.MinNumberValue);
            Assert.AreEqual(expectedMaxValue, game.MaxNumberValue);
        }

        [TestMethod]
        public void DichTest()
        {
            game.UserNumber = 
        }
    }
}
