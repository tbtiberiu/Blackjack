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
    }
}
