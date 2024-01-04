using Blackjack.Server.Models.Interfaces;

namespace Blackjack.Server.Models.States
{
    public class GameOverState : IGameState
    {
        public void Bet(int amount)
        {
            Console.WriteLine("Cannot bet in game over state.");
        }

        public void Deal()
        {
            Console.WriteLine("Cannot deal in game over state.");
        }

        public void Hit()
        {
            Console.WriteLine("Cannot hit in game over state.");
        }

        public void Stand()
        {
            Console.WriteLine("Cannot stand in game over state.");
        }

        public string CheckWinner()
        {
            var game = BlackjackGame.Instance;
            var playerScore = game.PlayerHand.GetHandValue();
            var dealerScore = game.DealerHand.GetHandValue();

            if (game.PlayerHand.IsBust())
            {
                Console.WriteLine("Player busts. Dealer wins.");
                game.Player.Balance += game.PlayerHand.BetAmount;
                return "Dealer wins";
            } 
            else if (game.DealerHand.IsBust())
            {
                Console.WriteLine("Dealer busts. Player wins.");
                game.Player.Balance -= game.PlayerHand.BetAmount;
                return "Player wins";
            }
            else if (playerScore > dealerScore)
            {
                Console.WriteLine("Player wins.");
                game.Player.Balance += game.PlayerHand.BetAmount;
                return "Player wins";
;            }
            else if (dealerScore > playerScore)
            {
                Console.WriteLine("Dealer wins.");
                game.Player.Balance -= game.PlayerHand.BetAmount;
                return "Dealer wins";
            }
            else
            {
                Console.WriteLine("It's a tie!");
                return "Tie";
            }
        }
    }
}
    