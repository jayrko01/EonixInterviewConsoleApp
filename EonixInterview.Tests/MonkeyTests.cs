using Moq;
using System;
using Xunit;

namespace EonixInterview.Tests
{
    public class MonkeyTests
    {
        public string monkeyName { get; private set; }

        private readonly Monkey monkey;

        public Trick trick { get; private set; }

        public MonkeyTests()
        {
            monkeyName = "Singe1";
            monkey = new Monkey(monkeyName);
            trick = new Trick("Salto", TrickType.Acrobatie);
        }

        [Fact]
        public void LearnTrick_ParametersAreFilled_TrickAdded()
        {
            // Arrange
            

            // Act
            monkey.LearnTrick(trick);

            // Assert
            var createdTricks = monkey.GetAllTricks();
            Assert.Contains(trick, createdTricks);
        }

        [Fact]
        public void AddExistingTrick_ParametersAreFilled_TrickAdded()
        {
            // Arrange

            // Act
            monkey.LearnTrick(trick);
            monkey.LearnTrick(trick);
            var allTrickFromMonkey = monkey.GetAllTricks();

            // Assert
            Assert.Single(allTrickFromMonkey, trick);
        }

        [Fact]
        public void PerformTrick_TestSpectator_SpectatorNotified()
        {
            // Arrange

            var spectatorMock = new Mock<IObserver>();
            monkey.Attach(spectatorMock.Object);

            // Act
            monkey.PerformTrick(trick);

            // Assert
            spectatorMock.Verify(x => x.Update(monkey, trick), Times.Once());
        }

        [Fact]
        public void RemoveObserver_TestSpectator_SpectatorNotNotified()
        {
            //Arrange
            var monkey = new Monkey(monkeyName);
            var spectatorMock = new Mock<IObserver>();

            monkey.Attach(spectatorMock.Object);
            monkey.Detach(spectatorMock.Object);

            //Act
            monkey.PerformTrick(trick);

            //Assert

            spectatorMock.Verify(x => x.Update(monkey, trick), Times.Never);
        }

        [Fact]
        public void SetMonkeyName_ParameterAreFilled_NameAdded()
        {
            //Arrange

            //Act
            var monkey = new Monkey(monkeyName);

            //Assert
            Assert.Equal(monkeyName, monkey.Name);
        }

        [Fact]
        public void Constructor_NameIsNull_ArgumentNullException()
        {
            //Arrange
            monkeyName = null;

            //Act - Assert

            Assert.Throws<ArgumentNullException>("monkeyName", () => new Monkey(monkeyName));

        }
    }
}
