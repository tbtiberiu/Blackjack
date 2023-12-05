using Blackjack.Server.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace Blackjack.Server.Models
{
    public class DealingPack
    {
        private List<Deck> Decks { get; } = new List<Deck>();

        public DealingPack()
        {
            InitializeDecks(7); // Inițializează cele 7 pachete
            ShuffleDecks();    // Amestecă pachetele
        }

        private void InitializeDecks(int numberOfDecks)
        {
            for (int i = 0; i < numberOfDecks; i++)
            {
                Decks.Add(new Deck());
            }
        }

        private void ShuffleDecks()
        {
            foreach (Deck deck in Decks)
            {
                deck.Shuffle();
            }
        }

        public ICard DrawCard()
        {
            if (Decks.Count == 0 || Decks[0].GetCount() == 0)
            {
                throw new InvalidOperationException("No more cards in the dealing pack.");
            }

            return Decks[0].Draw();
        }
    }
}
