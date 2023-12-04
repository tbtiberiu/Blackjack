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
        public int GetValue()
        {
            if (Rank == Rank.Ace)
            {
                return 11;
            }
            else if (Rank == Rank.Jack || Rank == Rank.Queen || Rank == Rank.King)
            {
                return 10;
            }
            else
            {
                return (int)Rank;
            }
        }
    }
}
