using Microsoft.VisualStudio.TestTools.UnitTesting;
using GuessNumber_Game;
using GuessNumber_Game.GameProcessor;
using GuessNumber_Game.UserInterface;
using Microsoft.Extensions.Configuration;
using Moq;

namespace GuessNumberGame_Tests
{
    

    [TestClass]
    public class GuessNumberGameTests
    {
        GuessNumberGame game;
        IConfiguration configuration;
        IGameInteraction iteraction;
        

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
        }

        [TestMethod]
        public void CheckPropertiesSettedWithConfiguration()
        {
            game = new GuessNumberGame(new ConsoleInteraction(), configuration);
            int expectedMaxValue = 101;
            int expectedMinValue = 0;

            Assert.AreEqual(expectedMinValue, game.MinNumberValue);
            Assert.AreEqual(expectedMaxValue, game.MaxNumberValue);
        }

        [TestMethod]
        public void GameTest_FakeUserInput_NumberCorrespondsToGuessedNumber_BoolConditionShouldChangeToFalse()
        {
            var testIteraction = new Mock<IGameInteraction>();
            testIteraction.Setup(x => x.GetUserInput()).Returns("13");
            testIteraction.Setup(x => x.GetUserInput()).Returns("14");
            game = new GuessNumberGame(testIteraction.Object, configuration);
            testIteraction.Verify(x => x.ShowGameResponse(It.Is<string>(str => str.Contains(MessagesTemplates.Greetings))));
            game.Play();
            Assert.IsFalse(game.NumberIsNotGuessed);
        }



    }
}
