using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blackjack.Server.Models;
using Blackjack.Server.Models.Interfaces;

namespace Blackjack.Server.Tests.Models
{
    [TestClass]
    public class DealingPackTests
    {
        [TestMethod]
        public void DealingPack_Initialization_ShouldCreateCorrectNumberOfCards()
        {
            // Arrange
            var pack = new DealingPack();

            // Act
            int expectedCardCount = 7 * 52; // 7 decks of cards

            // Assert
            Assert.AreEqual(expectedCardCount, pack.GetCount());
        }

        [TestMethod]
        public void DealingPack_DrawCard_ShouldReturnValidCard()
        {
            // Arrange
            var pack = new DealingPack();

            // Act
            ICard drawnCard = pack.DrawCard();

            // Assert
            Assert.IsNotNull(drawnCard);
        }

        [TestMethod]
        public void DealingPack_DrawCard_ShouldRemoveCardFromPack()
        {
            // Arrange
            var pack = new DealingPack();
            int initialCount = pack.GetCount();

            // Act
            _ = pack.DrawCard();

            // Assert
            Assert.AreEqual(initialCount - 1, pack.GetCount());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DealingPack_DrawCard_EmptyPack_ShouldThrowException()
        {
            // Arrange
            var pack = new DealingPack();

            // Consume all cards
            int totalCards = pack.GetCount();
            for (int i = 0; i < totalCards; i++)
            {
                pack.DrawCard();
            }

            // Act & Assert
            _ = pack.DrawCard(); // Should throw InvalidOperationException
        }
    }
}
