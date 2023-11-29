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

            Suit[] suits = [Suit.Spades, Suit.Hearts, Suit.Diamonds, Suit.Clubs];
            Rank[] ranks = [ Rank.Two, Rank.Three, Rank.Four, Rank.Five, 
                             Rank.Six, Rank.Seven, Rank.Eight, Rank.Nine, 
                             Rank.Ten, Rank.Ace, Rank.Jack, Rank.Queen, 
                             Rank.King ];
            
            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    ICard card = _cardFactory.CreateCard(suit, rank);
                    deck.AddCard(card);
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
