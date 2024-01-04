using Blackjack.Server.Models;
using Blackjack.Server.Models.Enums;
using Blackjack.Server.Models.Interfaces;

namespace Blackjack.Server.Tests.Models
{
    [TestClass]
    public class PlayerHandTests
    {
        [TestMethod]
        public void PlayerHand_NewHand_ShouldClearCardsAndResetBetAmount()
        {
            // Arrange
            var playerHand = new PlayerHand();
            playerHand.AddCard(new Card(Suit.Hearts, Rank.Ace));
            playerHand.AddCard(new Card(Suit.Clubs, Rank.King));
            playerHand.BetAmount = 100;

            // Act
            playerHand.NewHand();

            // Assert
            Assert.AreEqual(0, playerHand.Cards.Count);
            Assert.AreEqual(0, playerHand.BetAmount);
        }

        [TestMethod]
        public void PlayerHand_AddCard_ShouldIncreaseCardCount()
        {
            // Arrange
            var playerHand = new PlayerHand();
            ICard card = new Card(Suit.Spades, Rank.Two);

            // Act
            playerHand.AddCard(card);

            // Assert
            Assert.AreEqual(1, playerHand.Cards.Count);
        }

        [TestMethod]
        public void PlayerHand_GetHandValue_ShouldReturnCorrectValue()
        {
            // Arrange
            var playerHand = new PlayerHand();
            playerHand.AddCard(new Card(Suit.Hearts, Rank.Ace));
            playerHand.AddCard(new Card(Suit.Diamonds, Rank.Seven));

            // Act
            int handValue = playerHand.GetHandValue();

            // Assert
            Assert.AreEqual(18, handValue);
        }

        [TestMethod]
        public void PlayerHand_IsBust_ShouldReturnCorrectValue()
        {
            // Arrange
            var playerHand = new PlayerHand();
            playerHand.AddCard(new Card(Suit.Hearts, Rank.Jack));
            playerHand.AddCard(new Card(Suit.Diamonds, Rank.King));
            playerHand.AddCard(new Card(Suit.Clubs, Rank.Seven));

            // Act
            bool isBust = playerHand.IsBust();

            // Assert
            Assert.IsTrue(isBust);
        }

        [TestMethod]
        public void PlayerHand_IsBust_ShouldReturnCorrectValue2()
        {
            // Arrange
            var playerHand = new PlayerHand();
            playerHand.AddCard(new Card(Suit.Hearts, Rank.Jack));
            playerHand.AddCard(new Card(Suit.Diamonds, Rank.King));
            playerHand.AddCard(new Card(Suit.Clubs, Rank.Ace));

            // Act
            bool isBust = playerHand.IsBust();

            // Assert
            Assert.IsFalse(isBust);
        }
    }
}
