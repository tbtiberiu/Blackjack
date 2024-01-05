using Blackjack.Server.Models.Enums;
using Blackjack.Server.Models.Interfaces;

namespace Blackjack.Server.Models.Factories
{
    public class DeckFactory : IDeckFactory
    {
        private readonly CardFactory _cardFactory = new();

        public Deck CreateDeck()
        {
            var deck = new Deck();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    deck.AddCard(new Card(suit, rank));
                }
            }

            return deck;
        }

        public List<Deck> CreateDecks(int decksCount)
        {
            var deck = CreateDeck();
            var multipleDecks = new List<Deck>();

            for (int i = 0; i < decksCount; i++)
            {
                multipleDecks.Add(deck);
            }

            return multipleDecks;
        }
    }
}
