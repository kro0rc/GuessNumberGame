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
    public class ConsoleInteractionTests
    {
        Mock<IGameInteraction> testInteraction;

        [TestCleanup]
        public void TestCleanUp()
        {
            testInteraction = null;
        }

        [TestInitialize]
        public void TestInitialize()
        {
            testInteraction = new Mock<IGameInteraction>();
        }

        [DataTestMethod]
        [DataRow("2341243124%^$&*&^")]
        [DataRow("String")]
        [DataRow("12312fsdfsd32fdfg;;::::;;;:21312")]
        public void GetUserInputTest_PassedAndReturnedValuesShouldMatch(string value)
        {
            testInteraction.Setup(x => x.GetUserInput()).Returns(value);
            var test = testInteraction.Object.GetUserInput();
            Assert.AreEqual(value, test);
        }


        [DataTestMethod]
        [DataRow(MessagesTemplates.Greetings)]
        [DataRow(MessagesTemplates.AskUserNumberMessage)]
        [DataRow(MessagesTemplates.ExitOrRestart)]
        [DataRow(MessagesTemplates.ByeBye)]
        [DataRow(MessagesTemplates.Greetings + "asdas")]
        [DataRow(MessagesTemplates.AskUserNumberMessage + "123123123")]
        [DataRow(MessagesTemplates.ExitOrRestart + " ")]
        [DataRow(MessagesTemplates.ByeBye + MessagesTemplates.ByeBye)]
        public void ShowGameResponseTest_PassedAndReturnedValuesShouldMatch(string value)
        {
            testInteraction.Setup(x => x.ShowGameResponse(It.IsAny<string>()));
            testInteraction.Object.ShowGameResponse(value);
            testInteraction.Verify(x => x.ShowGameResponse((value)), Times.Once());
        }

        [TestMethod]
        public void ExitOrRestartDialogTest()
        {
            testInteraction.Setup(x => x.ExitRestartDialog());
            var res = testInteraction.Object.ExitRestartDialog();
            Assert.IsFalse(res);
        }
    }
}
