using Blackjack.Server.Models.Interfaces;

namespace Blackjack.Server.Models.States
{
    public class BettingPhaseState : IGameState
    {
        public void Bet(int amount)
        {
            var game = BlackjackGame.Instance;
            Console.WriteLine($"Betting {amount}.");
            game.PlayerHand.BetAmount = amount;
        }

        public void Deal()
        {
            var game = BlackjackGame.Instance;
            Console.WriteLine("Dealing cards.");
            for (int i = 0; i < 2; i++)
            {
                game.PlayerHand.AddCard(game.DrawCard());
                game.DealerHand.AddCard(game.DrawCard());
            }
            game.ChangeState(new PlayerTurnState());
        }

        public ICard Hit()
        {
            Console.WriteLine("Cannot hit during betting phase.");
            return null;
        }

        public void Stand()
        {
            Console.WriteLine("Cannot stand during betting phase.");
        }

        public string CheckWinner()
        {
            Console.WriteLine("Cannot check winner during betting phase.");
            return "Cannot check winner during betting phase.";
        }
    }
}
