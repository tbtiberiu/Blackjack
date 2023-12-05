using Blackjack.Server.Models.Interfaces;
using System;

namespace Blackjack.Server.Models.States
{
    public class BettingPhaseState : IGameState
    {
        public void Deal(BlackjackGame game)
        {
            Console.WriteLine("Dealing cards.");
            for (int i = 0; i < 2; i++)
            {
                game.playerHand.AddCard(game.dealingPack.DrawCard());
                game.dealerHand.AddCard(game.dealingPack.DrawCard());
            }
        }

        public void Hit(BlackjackGame game)
        {
            Console.WriteLine("Cannot hit during betting phase.");
        }

        public void Stand(BlackjackGame game)
        {
            Console.WriteLine("Cannot stand during betting phase.");
        }

        public void ChangeState(BlackjackGame game)
        {
            game.ChangeState(new PlayerTurnState());
        }
    }
}
