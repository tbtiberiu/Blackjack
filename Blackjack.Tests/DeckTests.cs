using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Blackjack.Server.Models.Enums;
using Blackjack.Server.Models.Interfaces;
using Blackjack.Server.Models;

namespace Blackjack.Server.Tests.Models
{
    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void Deck_Initialization_ShouldCreateCorrectNumberOfCards()
        {
            // Arrange
            var deck = new Deck();

            // Act
            int expectedCardCount = Enum.GetValues(typeof(Suit)).Length * Enum.GetValues(typeof(Rank)).Length;

            // Assert
            Assert.AreEqual(expectedCardCount, deck.GetCount());
        }

        [TestMethod]
        public void Deck_Shuffle_ShouldChangeOrderOfCards()
        {
            // Arrange
            Deck originalDeck = new Deck();
            Deck shuffledDeck = new Deck(originalDeck.ToList());

            // Act
            shuffledDeck.Shuffle();

            // Assert
            CollectionAssert.AreNotEqual(originalDeck.ToList(), shuffledDeck.ToList());
        }

        [TestMethod]
        public void Deck_AddCard_ShouldIncreaseCardCount()
        {
            // Arrange
            Deck deck = new Deck();
            ICard card = new Card(Suit.Clubs, Rank.Ace);

            // Act
            deck.AddCard(card);

            // Assert
            Assert.AreEqual(52 + 1, deck.GetCount());
        }

        [TestMethod]
        public void Deck_RemoveCard_ShouldDecreaseCardCount()
        {
            // Arrange
            Deck deck = new Deck();
            ICard card = deck.First();

            // Act
            deck.RemoveCard(card);

            // Assert
            Assert.AreEqual(52 - 1, deck.GetCount());
        }

        [TestMethod]
        public void Deck_GetEnumerator_ShouldReturnEnumerator()
        {
            // Arrange
            Deck deck = new Deck();

            // Act
            IEnumerator<ICard> enumerator = deck.GetEnumerator();

            // Assert
            Assert.IsNotNull(enumerator);
        }

        [TestMethod]
        public void Deck_GetEnumerator_ShouldReturnEnumeratorWithCorrectCards()
        {
            // Arrange
            Deck deck = new Deck();

            // Act
            IEnumerator<ICard> enumerator = deck.GetEnumerator();

            // Assert
            Assert.IsNotNull(enumerator);
            int i = 0;
            while (enumerator.MoveNext())
            {
                Assert.AreEqual(deck.ElementAt(i), enumerator.Current);
                i++;
            }
        }
    }
}
