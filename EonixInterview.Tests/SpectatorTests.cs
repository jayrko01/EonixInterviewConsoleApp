using Moq;
using NSubstitute;
using System;
using Xunit;

namespace EonixInterview.Tests
{
    public class SpectatorTests
    {
        private Trick trick { get; }

        public SpectatorTests()
        {
            var trickName = "Salto";
            var trickType = TrickType.Acrobatie;
            trick = new Trick(trickName, trickType);
        }

        [Fact]
        public void ObserversAreNotifiedWhenStateChanges_TestObserver_ObserverNotified()
        {
            //Arrange
            var spectator = Substitute.For<IObserver>();
            var spectator2 = Substitute.For<IObserver>();

            var monkeyName = "Singe1";
            var monkey = new Monkey(monkeyName);
            var trickName = "Salto";
            var trickType = TrickType.Acrobatie;

            var trick = new Trick(trickName, trickType);

            //Act - Asset
            monkey.Attach(spectator);
            monkey.Attach(spectator2);
            monkey.PerformTrick(trick);

            spectator.Received(1).Update(monkey, trick);
            spectator2.Received(1).Update(monkey, trick);

            monkey.Detach(spectator2);
            spectator2.ClearReceivedCalls();

            monkey.PerformTrick(trick);
            spectator.Received(2).Update(monkey, trick);
            spectator2.DidNotReceive().Update(monkey, trick);

        }

        [Fact]
        public void SpectactorInteractAfterTrick_ParametersAreFilled_String()
        {
            //Arrange
            var monkeyName = "Singe1";
            var monkey = new Monkey(monkeyName);
            
            var spectatorMock = new Mock<IObserver>();

            //Act
            monkey.Attach(spectatorMock.Object);
            monkey.PerformTrick(trick);

            //Asset

            // ? Comment récupérer la phrase du Update ? 
        }

        [Fact]
        public void ConstructorSpectatorName_ParameterAreFilled_NameAdded()
        {
            //Arrange
            string spectatorName = "Spectateur1";
            var spectator = new Spectator(spectatorName);

            //Act - Asset
            Assert.Equal(spectatorName, spectator.spectatorName);
        }

        [Fact]
        public void Constructor_NameIsNull_ArgumentNullException()
        {
            //Arrange
            string spectatorName = null;

            //Act - Asset
            Assert.Throws<ArgumentNullException>("spectatorName", () => new Spectator(spectatorName));
        }

        [Fact]
        public void UpdateAfterTrick_MonkeyIsNull_ArgumentNullException()
        {
            //Arrange
            string spectatorName = "Spectateur1";
            var spectator = new Spectator(spectatorName);
            Monkey monkey = null;

            //Act - Asset
            Assert.Throws<ArgumentNullException>("monkey", () => spectator.Update(monkey, trick));
        }

        [Fact]
        public void UpdateAfterTrick_TrickIsNull_ArgumentNullException()
        {
            //Arrange
            string spectatorName = "Spectateur1";
            var spectator = new Spectator(spectatorName);
            Trick trick1 = null;
            var monkeyName = "Singe1";
            var monkey = new Monkey(monkeyName);

            //Act - Asset
            Assert.Throws<ArgumentNullException>("trick", () => spectator.Update(monkey, trick1));
        }

    }
}
