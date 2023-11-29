using Blackjack.Server.Models.Interfaces;

namespace Blackjack.Server.Models.States
{
    public class GameOverState : IGameState
    {
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

        public void ChangeState(BlackjackGame game)
        {
            Console.WriteLine("Game over.");
        }
    }
}
