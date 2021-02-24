using Microsoft.VisualStudio.TestTools.UnitTesting;
using GuessNumber_Game;
using GuessNumber_Game.GameProcessor;
using GuessNumber_Game.UserInterface;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Collections.Generic;
using System;

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
        public void GameTest_GeneralBehaviourTest()
        {
            var testIteraction = new Mock<IGameInteraction>();
            testIteraction.SetupSequence(x => x.GetUserInput())
                .Returns("-1")
                .Returns("q");
            testIteraction.Setup(x => x.ExitRestartDialog()).Returns(false);

            game = new GuessNumberGame(testIteraction.Object, configuration);
            game.Play();

            testIteraction.Verify(x => x.GetUserInput(), Times.Exactly(2));
            testIteraction.Verify(x => x.ExitRestartDialog(), Times.Once());
            testIteraction.Verify(x => x.ShowGameResponse(It.IsAny<string>()), Times.Exactly(7));
              
        }

        [TestMethod]
        public void GameTest_GuesedNumberAndUserNumberShouldMatch()
        {
            var configurationValues = new Dictionary<string, string>()
            {
                {"MinValue", "1"},
                {"MaxValue", "1"}
            };

            IConfiguration LocalConfiguration = new ConfigurationBuilder()
                .AddInMemoryCollection(configurationValues)
                .Build();

            var testIteraction = new Mock<IGameInteraction>();
            testIteraction.SetupSequence(x => x.GetUserInput())
                .Returns("1")
                .Returns("q");
            testIteraction.Setup(x => x.ExitRestartDialog()).Returns(false);

            var game = new GuessNumberGame(testIteraction.Object, LocalConfiguration);
            game.Play();

            testIteraction.Verify(x => x.ShowGameResponse(MessagesTemplates.Greetings), Times.Once);
            testIteraction.Verify(x => x.ShowGameResponse(MessagesTemplates.AskUserNumberMessage), Times.Once);
            testIteraction.Verify(x => x.ShowGameResponse(MessagesTemplates.GuessedNumberMessage), Times.Once);
            testIteraction.Verify(x => x.ShowGameResponse(MessagesTemplates.ExitOrRestart), Times.Once);
            testIteraction.Verify(x => x.ShowGameResponse(MessagesTemplates.ByeBye), Times.Once);
            testIteraction.Verify(x => x.GetUserInput(), Times.Once);
            testIteraction.Verify(x => x.ExitRestartDialog(), Times.Once());

            var minValueFromConfiguration = Int32.TryParse(configurationValues["MinValue"], out int minResult);
            var maxValueFromConfiguration = Int32.TryParse(configurationValues["MinValue"], out int maxResult);

            Assert.AreEqual((minResult, maxResult), (game.MinNumberValue, game.MaxNumberValue));
            Assert.IsFalse(game.NumberIsNotGuessed);
        }

        [TestMethod]
        public void GameTest_GuesedNumberAndUserNumberShouldNotMatch()
        {
            var configurationValues = new Dictionary<string, string>()
            {
                {"MinValue", "1"},
                {"MaxValue", "1"}
            };

            IConfiguration LocalConfiguration = new ConfigurationBuilder()
                .AddInMemoryCollection(configurationValues)
                .Build();

            var testIteraction = new Mock<IGameInteraction>();
            testIteraction.SetupSequence(x => x.GetUserInput())
                .Returns("2")
                .Returns("q");
            testIteraction.Setup(x => x.ExitRestartDialog()).Returns(false);

            var game = new GuessNumberGame(testIteraction.Object, LocalConfiguration);
            game.Play();

            testIteraction.Verify(x => x.ShowGameResponse(MessagesTemplates.Greetings), Times.Once);
            testIteraction.Verify(x => x.ShowGameResponse(MessagesTemplates.AskUserNumberMessage), Times.Exactly(2));
            testIteraction.Verify(x => x.ShowGameResponse(MessagesTemplates.NumberIsBigger), Times.Once);
            testIteraction.Verify(x => x.ShowGameResponse(MessagesTemplates.ExitOrRestart), Times.Once);
            testIteraction.Verify(x => x.ShowGameResponse(MessagesTemplates.ByeBye), Times.Once);
            testIteraction.Verify(x => x.GetUserInput(), Times.Exactly(2));
            testIteraction.Verify(x => x.ExitRestartDialog(), Times.Once());

            var minValueFromConfiguration = Int32.TryParse(configurationValues["MinValue"], out int minResult);
            var maxValueFromConfiguration = Int32.TryParse(configurationValues["MinValue"], out int maxResult);

            Assert.AreEqual((minResult, maxResult), (game.MinNumberValue, game.MaxNumberValue));
            Assert.IsTrue(game.NumberIsNotGuessed);
        }
    }
}
