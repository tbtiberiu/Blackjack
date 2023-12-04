using Blackjack.Server.Models.Interfaces;
using System.Collections;

namespace Blackjack.Server.Models
{
    public class Deck : IEnumerable<ICard>
    {
        private List<ICard> Cards { get; } = [];

        public Deck() { }

        public Deck(List<ICard> cards)
        {
            Cards = cards;
        }

        public IEnumerator<ICard> GetEnumerator()
        {
            return Cards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddCard(ICard card)
        {
            Cards.Add(card);
        }

        public void RemoveCard(ICard card)
        {
            Cards.Remove(card);
        }
        public void Shuffle()
        {
            Random rng = new Random();
            int n = Cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                ICard value = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = value;
            }
        }
        public ICard Draw()
        {
            ICard card = Cards[0];
            Cards.RemoveAt(0);
            return card;
        }
    }
}
