using Blackjack.Server.Models;
using Blackjack.Server.Models.Enums;
using Blackjack.Server.Models.Interfaces;

namespace Blackjack.Server.Tests.Models
{
    [TestClass]
    public class DealerHandTests
    {
        [TestMethod]
        public void DealerHand_NewHand_ShouldClearCardsAndSetHiddenToTrue()
        {
            // Arrange
            var dealerHand = new DealerHand();
            dealerHand.AddCard(new Card(Suit.Hearts, Rank.Ace));
            dealerHand.AddCard(new Card(Suit.Clubs, Rank.King));

            // Act
            dealerHand.NewHand();

            // Assert
            Assert.AreEqual(0, dealerHand.Cards.Count);
            Assert.IsTrue(dealerHand.IsHidden);
        }

        [TestMethod]
        public void DealerHand_AddCard_ShouldIncreaseCardCount()
        {
            // Arrange
            var dealerHand = new DealerHand();
            ICard card = new Card(Suit.Spades, Rank.Two);

            // Act
            dealerHand.AddCard(card);

            // Assert
            Assert.AreEqual(1, dealerHand.Cards.Count);
        }

        [TestMethod]
        public void DealerHand_GetHandValue_ShouldReturnCorrectValue()
        {
            // Arrange
            var dealerHand = new DealerHand();
            dealerHand.AddCard(new Card(Suit.Hearts, Rank.Ace));
            dealerHand.AddCard(new Card(Suit.Diamonds, Rank.Seven));

            // Act
            int handValue = dealerHand.GetHandValue();

            // Assert
            Assert.AreEqual(18, handValue);
        }

        [TestMethod]
        public void DealerHand_IsBust_ShouldReturnCorrectValue()
        {
            // Arrange
            var dealerHand = new DealerHand();
            dealerHand.AddCard(new Card(Suit.Hearts, Rank.Jack));
            dealerHand.AddCard(new Card(Suit.Diamonds, Rank.King));
            dealerHand.AddCard(new Card(Suit.Clubs, Rank.Seven));

            // Act
            bool isBust = dealerHand.IsBust();

            // Assert
            Assert.IsTrue(isBust);
        }

        [TestMethod]
        public void DealerHand_HasAce_ShouldReturnTrueIfAcePresent()
        {
            // Arrange
            var dealerHand = new DealerHand();
            dealerHand.AddCard(new Card(Suit.Hearts, Rank.Ace));
            dealerHand.AddCard(new Card(Suit.Diamonds, Rank.Seven));

            // Act
            bool hasAce = dealerHand.HasAce();

            // Assert
            Assert.IsTrue(hasAce);
        }

        [TestMethod]
        public void DealerHand_HasAce_ShouldReturnFalseIfNoAcePresent()
        {
            // Arrange
            var dealerHand = new DealerHand();
            dealerHand.AddCard(new Card(Suit.Spades, Rank.Seven));
            dealerHand.AddCard(new Card(Suit.Clubs, Rank.Jack));

            // Act
            bool hasAce = dealerHand.HasAce();

            // Assert
            Assert.IsFalse(hasAce);
        }

        [TestMethod]
        public void DealerHand_ShouldHit_ShouldReturnTrueIfHandValueLessThan17()
        {
            // Arrange
            var dealerHand = new DealerHand();
            dealerHand.AddCard(new Card(Suit.Hearts, Rank.Ten));
            dealerHand.AddCard(new Card(Suit.Diamonds, Rank.Six));

            // Act
            bool shouldHit = dealerHand.ShouldHit();

            // Assert
            Assert.IsTrue(shouldHit);
        }

        [TestMethod]
        public void DealerHand_ShouldHit_ShouldReturnTrueIfHandValueIsExactly17AndHasAce()
        {
            // Arrange
            var dealerHand = new DealerHand();
            dealerHand.AddCard(new Card(Suit.Spades, Rank.Ace));
            dealerHand.AddCard(new Card(Suit.Clubs, Rank.Six)); // Ace is counted as 11 here

            // Act
            bool shouldHit = dealerHand.ShouldHit();

            // Assert
            Assert.IsTrue(shouldHit);
        }

        [TestMethod]
        public void DealerHand_ShouldHit_ShouldReturnFalseIfHandValueIs17OrGreaterWithoutAce()
        {
            // Arrange
            var dealerHand = new DealerHand();
            dealerHand.AddCard(new Card(Suit.Hearts, Rank.Eight));
            dealerHand.AddCard(new Card(Suit.Diamonds, Rank.Nine));

            // Act
            bool shouldHit = dealerHand.ShouldHit();

            // Assert
            Assert.IsFalse(shouldHit);
        }
    }
}
