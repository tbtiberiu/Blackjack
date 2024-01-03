using Blackjack.Server.Models;

namespace Blackjack.Server.Tests.Models
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void Player_ConstructedWithValues_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            string expectedName = "John Doe";
            int expectedBalance = 1000;

            // Act
            var player = new Player(expectedName, expectedBalance);

            // Assert
            Assert.AreEqual(expectedName, player.Name);
            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void Player_NameProperty_CanBeUpdated()
        {
            // Arrange
            string originalName = "Alice";
            string updatedName = "Bob";
            var player = new Player(originalName, 500);

            // Act
            player.Name = updatedName;

            // Assert
            Assert.AreEqual(updatedName, player.Name);
        }

        [TestMethod]
        public void Player_BalanceProperty_CanBeUpdated()
        {
            // Arrange
            int originalBalance = 100;
            int updatedBalance = 300;
            var player = new Player("Charlie", originalBalance);

            // Act
            player.Balance = updatedBalance;

            // Assert
            Assert.AreEqual(updatedBalance, player.Balance);
        }
    }
}
