using Blackjack.Server.Models.Enums;
using Blackjack.Server.Models.Interfaces;

namespace Blackjack.Server.Models
{
    public class PlayerHand
    {
        private List<ICard> _cards { get; set; }
        private int _bet { get; set; }
        public PlayerHand()
        {
            _cards = new List<ICard>();
            _bet = 0;
        }
        public PlayerHand(int bet)
        {
            _bet = bet;
            _cards = new List<ICard>();
        }
        public PlayerHand(List<ICard> cards, int bet)
        {
            _cards = cards;
            _bet = bet;
        }
        public int GetBet()
        {
            return _bet;
        }
        public void SetBet(int bet)
        {
            _bet = bet;
        }
        public void AddCard(ICard card)
        {
            _cards.Add(card);
        }
        public void NewHand()
        {
            _cards.Clear();
            _bet = 0;
        }
        public int GetHandValue()
        {
            int handValue = 0;
            int aceCount = 0;
            foreach (Card card in _cards)
            {
                if (card.Rank ==Rank.Ace)
                {
                    aceCount++;
                }
                else
                {
                    handValue += card.GetValue();
                }
                for (var i = 0; i < aceCount; i++)
                {
                    if (handValue + 11 <= 21)
                        handValue += 11;
                    else
                        handValue += 1;
                }
            }
            return handValue;
        }
        public bool IsBust()
        {
            return GetHandValue() > 21;
        }

    }
}
