using Blackjack.Server.Models.Enums;

namespace Blackjack.Server.Models.Interfaces
{
    public interface ICard
    {
        Suit Suit { get; set; }
        Rank Rank { get; set; }

        void Display();
        int GetValue();
    }
}
