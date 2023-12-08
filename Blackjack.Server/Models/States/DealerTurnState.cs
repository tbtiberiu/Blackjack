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

        public void Hit()
        {
            var game = BlackjackGame.Instance;
            if (game.DealerHand.ShouldHit())
            {
                ICard card = game.DrawCard();
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
        }

        public void Stand()
        {
            Console.WriteLine("Dealer stands.");
        }

        public void CheckWinner()
        {
            Console.WriteLine("Cannot check winner during dealer's turn.");
        }
    }
}
