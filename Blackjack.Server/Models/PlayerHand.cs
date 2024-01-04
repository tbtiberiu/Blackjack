using Blackjack.Server.Models.Enums;
using Blackjack.Server.Models.Interfaces;

namespace Blackjack.Server.Models
{
    public class PlayerHand
    {
        public List<ICard> Cards { get; set; }
        public int BetAmount {  get; set; }
        
        public PlayerHand()
        {
            Cards = [];
            BetAmount = 0;
        }
        public PlayerHand(int betAmount)
        {
            Cards = [];
            BetAmount = betAmount;
        }

        public PlayerHand(List<ICard> cards, int betAmount)
        {
            Cards = cards;
            BetAmount = betAmount;
        }

        public void AddCard(ICard card)
        {
            Cards.Add(card);
        }

        public void NewHand()
        {
            Cards.Clear();
            BetAmount = 0;
        }

        public int GetHandValue()
        {
            int handValue = 0;
            int aceCount = 0;

            foreach (ICard card in Cards)
            {
                if (card.Rank == Rank.Ace)
                {
                    aceCount++;
                }
                else
                {
                    handValue += card.GetValue();
                }
            }

            for (var i = 0; i < aceCount; i++)
            {
                if (handValue + 11 <= 21)
                    handValue += 11;
                else
                    handValue += 1;
            }

            return handValue;
        }

        public bool IsBust()
        {
            return GetHandValue() > 21;
        }

    }
}
