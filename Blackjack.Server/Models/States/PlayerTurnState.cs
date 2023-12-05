using Blackjack.Server.Models.Interfaces;
using System;

namespace Blackjack.Server.Models.States
{
    public class PlayerTurnState : IGameState
    {
        public void Deal(BlackjackGame game)
        {
            Console.WriteLine("Cannot deal during player's turn.");
        }

        public void Hit(BlackjackGame game)
        {
            Console.WriteLine("Player hits.");
            game.playerHand.AddCard(game.dealingPack.DrawCard());

            if (game.playerHand.IsBust())
            {
                Console.WriteLine("Player busts. Dealer wins.");
               // game.ChangeState(new BettingPhaseState());
            }
        }

        public void Stand(BlackjackGame game)
        {
            Console.WriteLine("Player stands.");
            game.ChangeState(new DealerTurnState());
        }

        public void ChangeState(BlackjackGame game)
        {
            game.ChangeState(new DealerTurnState());
        }
    }
}
