using Blackjack.Server.Models.Enums;

namespace Blackjack.Server.Models.Interfaces
{
    public interface ICardFactory
    {
        ICard CreateCard(Suit suit, Rank rank);
    }
}
