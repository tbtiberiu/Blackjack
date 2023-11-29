using Blackjack.Server.Models.Enums;
using Blackjack.Server.Models.Interfaces;

namespace Blackjack.Server.Models
{
    public class Card : ICard
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }
        
        public void Display()
        {
            Console.WriteLine($"{Rank} of {Suit}");
        }
    }
}
