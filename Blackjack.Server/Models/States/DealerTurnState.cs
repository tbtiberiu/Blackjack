using Blackjack.Server.Models.Interfaces;
using System;

namespace Blackjack.Server.Models.States
{
    public class DealerTurnState : IGameState
    {
        public void Bet(int amount)
        {
            Console.WriteLine("Cannot bet during dealer's turn.");
        }

        public void Deal()
        {
            Console.WriteLine("Cannot deal during dealer's turn.");
        }

        public ICard Hit()
        {
            var game = BlackjackGame.Instance;
            ICard card = game.DrawCard();
            if (game.DealerHand.ShouldHit())
            {
                game.DealerHand.AddCard(card);

                if (game.DealerHand.IsBust())
                {
                    game.ChangeState(new GameOverState());
                }
            }
            else
            {
                Console.WriteLine("Dealer stands.");
                game.ChangeState(new GameOverState());
            }
            return card;
        }

        public void Stand()
        {
            Console.WriteLine("Dealer stands.");
        }

        public string CheckWinner()
        {
            Console.WriteLine("Cannot check winner during dealer's turn.");
            return "Cannot check winner during dealer' phase.";
        }
    }
}
