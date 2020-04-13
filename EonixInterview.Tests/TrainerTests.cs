using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EonixInterview.Tests
{
    public class TrainerTests
    {
        public string name { get; set; }
        public Monkey monkey { get; }
        public Trainer trainer { get; }

        public TrainerTests()
        {
            var monkeyName = "Singe1";
            monkey = new Monkey(monkeyName);
            trainer = new Trainer("TestTrainer", monkey);

        }

        [Fact]
        public void Constructor_ParametersAreFilled_Created()
        {
            // Arrange
            name = "TestTrainer";

            // Act

            // Assert
            Assert.Equal(name, trainer.Name);
            Assert.Equal(monkey, trainer.Monkey);
        }

        [Fact]
        public void Constructor_NameIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            name = null;

            // Act / Assert
            Assert.Throws<ArgumentNullException>("name", () => new Trainer(name, monkey));
        }

        [Fact]
        public void Constructor_MonkeyIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            string name = "TestTrainer";
            Monkey monkey = null;

            // Act / Assert
            Assert.Throws<ArgumentNullException>("monkey", () => new Trainer(name, monkey));
        }

        [Fact]
        public void AskMonkeyDoTricks_NoParameter_NoReturn()
        {
            //Arrange


            //Act
            //trainer.AskMonkeyDoTricks();

            //Assert
        }
    }
}
