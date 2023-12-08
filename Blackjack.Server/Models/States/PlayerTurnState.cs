using Blackjack.Server.Models.Interfaces;

namespace Blackjack.Server.Models.States
{
    public class PlayerTurnState : IGameState
    {
        public void Bet(int amount)
        {
            Console.WriteLine("Cannot bet during player's turn.");
        }

        public void Deal()
        {
            Console.WriteLine("Cannot deal during player's turn.");
        }

        public void Hit()
        {
            var game = BlackjackGame.Instance;
            Console.WriteLine("Player hits.");
            game.PlayerHand.AddCard(game.DrawCard());

            if (game.PlayerHand.IsBust())
            {
                game.ChangeState(new GameOverState());
            }
        }

        public void Stand()
        {
            var game = BlackjackGame.Instance;
            Console.WriteLine("Player stands.");
            game.ChangeState(new DealerTurnState());
        }

        public void CheckWinner()
        {
            Console.WriteLine("Cannot check winner during player's turn.");
        }
    }
}
