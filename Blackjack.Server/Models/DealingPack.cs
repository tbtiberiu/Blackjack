using Blackjack.Server.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace Blackjack.Server.Models
{
    public class DealingPack
    {
        private List<ICard> Cards { get; } = [];

        public DealingPack()
        {
            InitializeDecks(7);
            ShuffleCards();
        }

        private void InitializeDecks(int numberOfDecks)
        {
            for (int i = 0; i < numberOfDecks; i++)
            {
                Cards.AddRange(new Deck());
            }
        }

        private void ShuffleCards()
        {
            var rng = new Random();
            int n = Cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (Cards[n], Cards[k]) = (Cards[k], Cards[n]);
            }
        }

        public ICard DrawCard()
        {
            if (Cards.Count == 0)
            {
                throw new InvalidOperationException("No more cards in the dealing pack.");
            }

            ICard card = Cards[0];
            Cards.RemoveAt(0);
            return card;
        }
    }
}
