using Moq;
using System;
using Xunit;

namespace EonixInterview.Tests
{
    public class SpectatorTests
    {
        private Trick trick;
        private Mock<ILogger> loggerMock;

        public SpectatorTests()
        {
            var trickName = "Salto";
            var trickType = TrickType.Acrobatie;
            trick = new Trick(trickName, trickType);

            loggerMock = new Mock<ILogger>();
        }

        [Fact]
        public void ObserversAreNotifiedWhenStateChanges_TestObserver_ObserverNotified()
        {
            ////Arrange
            //var spectatorMock = Substitute.For<IObserver>();
            //var spectator2Mock = Substitute.For<IObserver>();

            //var monkeyName = "Singe1";
            //var monkey = new Monkey(monkeyName);
            //var trickName = "Salto";
            //var trickType = TrickType.Acrobatie;

            //var trick = new Trick(trickName, trickType);

            //monkey.Attach(spectatorMock);
            //monkey.Attach(spectator2Mock);

            ////Act - Assert
            //monkey.PerformTrick(trick);

            //spectatorMock.Received(1).Update(monkey, trick);
            //spectator2Mock.Received(1).Update(monkey, trick);

            //monkey.Detach(spectator2Mock);
            //spectator2Mock.ClearReceivedCalls();

            //monkey.PerformTrick(trick);
            //spectatorMock.Received(2).Update(monkey, trick);
            //spectator2Mock.DidNotReceive().Update(monkey, trick);

            //Arrange
            var spectatorMock = new Mock<IObserver>();
            var spectator2Mock = new Mock<IObserver>();

            var monkeyName = "Singe1";
            var monkey = new Monkey(monkeyName);
            var trickName = "Salto";
            var trickType = TrickType.Acrobatie;

            var trick = new Trick(trickName, trickType);

            monkey.Attach(spectatorMock.Object);
            monkey.Attach(spectator2Mock.Object);

            //Act - Assert
            monkey.PerformTrick(trick);

            spectatorMock.Verify(x => x.Update(monkey, trick), Times.Once);
            spectator2Mock.Verify(x => x.Update(monkey, trick), Times.Once);

            monkey.Detach(spectator2Mock.Object);
            spectator2Mock.Invocations.Clear();

            monkey.PerformTrick(trick);

            spectatorMock.Verify(x => x.Update(monkey, trick), Times.Exactly(2));
            spectator2Mock.Verify(x => x.Update(monkey, trick), Times.Never);

        }

        [Fact]
        public void SpectactorInteractAfterTrick_ParametersAreFilled_String()
        {
            //Arrange
            var monkeyName = "Singe1";
            var monkey = new Monkey(monkeyName);

            var spectator = new Spectator("Test", loggerMock.Object);

            //Act
            monkey.Attach(spectator);
            monkey.PerformTrick(trick);

            //Assert
            loggerMock.Verify(x => x.LogMessage($"Spectateur applaudit pendant le tour {trick.trickType} '{trick.trickName}' du {monkey.Name}"));
        }

        [Fact]
        public void ConstructorSpectatorName_ParameterAreFilled_NameAdded()
        {
            //Arrange
            string spectatorName = "Spectateur1";
            var spectator = new Spectator(spectatorName, loggerMock.Object);

            //Act - Assert
            Assert.Equal(spectatorName, spectator.spectatorName);
        }

        [Fact]
        public void Constructor_NameIsNull_ArgumentNullException()
        {
            //Arrange
            string spectatorName = null;

            //Act - Assert
            Assert.Throws<ArgumentNullException>("spectatorName", () => new Spectator(spectatorName, loggerMock.Object));
        }

        [Fact]
        public void UpdateAfterTrick_MonkeyIsNull_ArgumentNullException()
        {
            //Arrange
            string spectatorName = "Spectateur1";
            var spectator = new Spectator(spectatorName, loggerMock.Object);
            Monkey monkey = null;

            //Act - Asset
            Assert.Throws<ArgumentNullException>("monkey", () => spectator.Update(monkey, trick));
        }

        [Fact]
        public void UpdateAfterTrick_TrickIsNull_ArgumentNullException()
        {
            //Arrange
            string spectatorName = "Spectateur1";
            var spectator = new Spectator(spectatorName, loggerMock.Object);
            Trick trick1 = null;
            var monkeyName = "Singe1";
            var monkey = new Monkey(monkeyName);

            //Act - Asset
            Assert.Throws<ArgumentNullException>("trick", () => spectator.Update(monkey, trick1));
        }

    }
}
