using Blackjack.Server.Models.Interfaces;

namespace Blackjack.Server.Models.States
{
    public class BettingPhaseState : IGameState
    {
        public void Deal()
        {
            Console.WriteLine("Dealing cards.");
        }

        public void Hit()
        {
            Console.WriteLine("Cannot hit during betting phase.");
        }

        public void Stand()
        {
            Console.WriteLine("Cannot stand during betting phase.");
        }

        public void ChangeState(BlackjackGame game)
        {
            game.ChangeState(new PlayerTurnState());
        }
    }
}
