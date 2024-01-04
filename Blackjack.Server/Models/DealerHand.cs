using Blackjack.Server.Models.Enums;
using Blackjack.Server.Models.Interfaces;

namespace Blackjack.Server.Models
{
    public class DealerHand
    {
        public List<ICard> Cards {  get; set; }
        public bool IsHidden { get; set; }

        public DealerHand()
        {
            Cards = [];
            IsHidden = true;
        }

        private DealerHand(List<ICard> cards, bool isHidden)
        {
            Cards = cards;
            IsHidden = isHidden;
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

        public bool HasAce()
        {
            foreach (Card card in Cards)
            {
                if (card.Rank == Rank.Ace)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ShouldHit()
        {
            var handValue = GetHandValue();
            if(handValue < 17)
            {
                return true;
            }
            else if(handValue == 17 && HasAce())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddCard(ICard card)
        {
            Cards.Add(card);
        }

        public void NewHand()
        {
            Cards.Clear();
            IsHidden = true;
        }

    }
}
