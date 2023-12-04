using Blackjack.Server.Models.Interfaces;

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
            //check the winner and change the state to the appropriate state
            var playerScore = game.playerHand.GetHandValue();
            var dealerScore = game.dealerHand.GetHandValue();
            if(playerScore > 21)
            {
                Console.WriteLine("Player busts. Dealer wins.");
            }
            else if(dealerScore > 21)
            {
                game.playerHand.NewHand();
                game.playerHand.SetBet(game.playerHand.GetBet() * 2);
                Console.WriteLine("Dealer busts. Player wins.");
            }
            else if(playerScore > dealerScore)
            {
                game.playerHand.NewHand();
                game.playerHand.SetBet(game.playerHand.GetBet() * 2);
                Console.WriteLine("Player wins.");
            }
            else if(dealerScore > playerScore)
            {
                Console.WriteLine("Dealer wins.");
            }
            game.dealerHand.NewHand();
            game.ChangeState(new BettingPhaseState());
        }
    }
}
