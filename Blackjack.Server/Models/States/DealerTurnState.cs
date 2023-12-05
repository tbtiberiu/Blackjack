using Blackjack.Server.Models.Interfaces;
using System;

namespace Blackjack.Server.Models.States
{
    public class DealerTurnState : IGameState
    {
        public void Deal(BlackjackGame game)
        {
            Console.WriteLine("Cannot deal during dealer's turn.");
        }

        public void Hit(BlackjackGame game)
        {
            if (game.dealerHand.ShouldHit())
            {
                var card = game.dealingPack.DrawCard();
                game.dealerHand.AddCard(card);

                if (game.dealerHand.IsBust())
                {
                    Console.WriteLine("Dealer busts. Player wins.");
                    game.playerHand.NewHand();
                    game.playerHand.SetBet(game.playerHand.GetBet() * 2);
                    game.ChangeState(new BettingPhaseState());
                }
            }
            else
            {
                Console.WriteLine("Dealer stands.");
                game.ChangeState(new GameOverState());
            }
        }

        public void Stand(BlackjackGame game)
        {
            Console.WriteLine("Dealer stands.");
        }

        public void ChangeState(BlackjackGame game)
        {
            // This state transitions to GameOverState when the dealer stands
            game.ChangeState(new GameOverState());
        }
    }
}
