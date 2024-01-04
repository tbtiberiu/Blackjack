using Blackjack.Server.Models.Interfaces;
using System.ComponentModel;

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
            ICard card = game.DrawCard();
            game.PlayerHand.AddCard(card);
            
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
            game.HitDealer();
        }

        public string CheckWinner()
        {
            Console.WriteLine("Cannot check winner during player's turn.");
            return "Cannot check winner during player's turn.";
        }
    }
}
