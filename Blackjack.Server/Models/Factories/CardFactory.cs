using Blackjack.Server.Models.Enums;
using Blackjack.Server.Models.Interfaces;

namespace Blackjack.Server.Models.Factories
{
    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(Suit suit, Rank rank)
        {
            return new Card(suit, rank);
        }
    }
}
