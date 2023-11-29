using Blackjack.Server.Models.Interfaces;

namespace Blackjack.Server.Models.States
{
    public class PlayerTurnState : IGameState
    {
        public void Deal()
        {
            Console.WriteLine("Cannot deal during player's turn.");
        }

        public void Hit()
        {
            Console.WriteLine("Player hits.");
        }

        public void Stand()
        {
            Console.WriteLine("Player stands.");
        }

        public void ChangeState(BlackjackGame game)
        {
            game.ChangeState(new DealerTurnState());
        }
    }
}
