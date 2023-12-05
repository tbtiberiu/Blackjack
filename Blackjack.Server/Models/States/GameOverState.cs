using Blackjack.Server.Models.Interfaces;
using System;

namespace Blackjack.Server.Models.States
{
    public class GameOverState : IGameState
    {
        public void Deal(BlackjackGame game)
        {
            Console.WriteLine("Cannot deal in game over state.");
        }

        public void Hit(BlackjackGame game)
        {
            Console.WriteLine("Cannot hit in game over state.");
        }

        public void Stand(BlackjackGame game)
        {
            Console.WriteLine("Cannot stand in game over state.");
        }

        public void ChangeState(BlackjackGame game)
        {
            var playerScore = game.playerHand.GetHandValue();
            var dealerScore = game.dealerHand.GetHandValue();

            if (playerScore > dealerScore)
            {
                Console.WriteLine("Player wins.");
                game.playerHand.NewHand();
                game.playerHand.SetBet(game.playerHand.GetBet() * 2);
            }
            else if (dealerScore > playerScore)
            {
                Console.WriteLine("Dealer wins.");
            }
            else
            {
                Console.WriteLine("It's a tie!");
                game.playerHand.SetBet(game.playerHand.GetBet()); // Return the bet in case of a tie
            }

            game.dealerHand.NewHand();
            game.ChangeState(new BettingPhaseState());
        }
    }
}
    