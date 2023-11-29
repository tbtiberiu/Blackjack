using Blackjack.Server.Models.Interfaces;

namespace Blackjack.Server.Models.States
{
    public class DealerTurnState : IGameState
    {
        public void Deal()
        {
            Console.WriteLine("Cannot deal during dealer's turn.");
        }

        public void Hit()
        {
            Console.WriteLine("Dealer hits.");
        }

        public void Stand()
        {
            Console.WriteLine("Dealer stands.");
        }

        public void ChangeState(BlackjackGame game)
        {
            game.ChangeState(new GameOverState());
        }
    }

}
