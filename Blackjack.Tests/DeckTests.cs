using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Blackjack.Server.Models.Enums;
using Blackjack.Server.Models.Interfaces;
using Blackjack.Server.Models;
using Blackjack.Server.Models.Factories;

namespace Blackjack.Server.Tests.Models
{
    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void Deck_Initialization_ShouldCreateCorrectNumberOfCards()
        {
            // Arrange
            var deckFactory = new DeckFactory();
            var deck = deckFactory.CreateDeck();

            // Act
            int expectedCardCount = Enum.GetValues(typeof(Suit)).Length * Enum.GetValues(typeof(Rank)).Length;

            // Assert
            Assert.AreEqual(expectedCardCount, deck.GetCount());
        }

        [TestMethod]
        public void Deck_Shuffle_ShouldChangeOrderOfCards()
        {
            // Arrange
            var deckFactory = new DeckFactory();
            var originalDeck = deckFactory.CreateDeck();
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
            var deckFactory = new DeckFactory();
            var deck = deckFactory.CreateDeck();
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
            var deckFactory = new DeckFactory();
            var deck = deckFactory.CreateDeck();
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
            var deckFactory = new DeckFactory();
            var deck = deckFactory.CreateDeck();

            // Act
            IEnumerator<ICard> enumerator = deck.GetEnumerator();

            // Assert
            Assert.IsNotNull(enumerator);
        }

        [TestMethod]
        public void Deck_GetEnumerator_ShouldReturnEnumeratorWithCorrectCards()
        {
            // Arrange
            var deckFactory = new DeckFactory();
            var deck = deckFactory.CreateDeck();

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
