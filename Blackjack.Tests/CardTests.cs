using Blackjack.Server.Models.Enums;
using Blackjack.Server.Models;

namespace Blackjack.Server.Tests.Models
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void Card_GetValue_ShouldReturnCorrectValueForAce()
        {
            // Arrange
            Suit suit = Suit.Clubs;
            Rank rank = Rank.Ace;
            var card = new Card(suit, rank);

            // Act
            int value = card.GetValue();

            // Assert
            Assert.AreEqual(11, value);
        }

        [TestMethod]
        public void Card_GetValue_ShouldReturnCorrectValueForFaceCards()
        {
            // Arrange
            Suit suit = Suit.Diamonds;
            Rank[] faceCards = [Rank.Jack, Rank.Queen, Rank.King];

            foreach (var rank in faceCards)
            {
                // Act
                var card = new Card(suit, rank);
                int value = card.GetValue();

                // Assert
                Assert.AreEqual(10, value);
            }
        }

        [TestMethod]
        public void Card_GetValue_ShouldReturnCorrectValueForNumberCards()
        {
            // Arrange
            Suit suit = Suit.Spades;

            for (int i = 2; i <= 10; i++)
            {
                Rank rank = (Rank)i;

                // Act
                var card = new Card(suit, rank);
                int value = card.GetValue();

                // Assert
                Assert.AreEqual(i, value);
            }
        }
    }
}
