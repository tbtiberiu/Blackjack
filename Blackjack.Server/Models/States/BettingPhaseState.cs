using Blackjack.Server.Models.Interfaces;

namespace Blackjack.Server.Models.States
{
    public class BettingPhaseState : IGameState
    {
        public void Deal(BlackjackGame game)
        {
            Console.WriteLine("Dealing cards.");
        }

        public void Hit(BlackjackGame game)
        {
            Console.WriteLine("Cannot hit during betting phase.");
        }

        public void Stand(BlackjackGame game)
        {
            Console.WriteLine("Cannot stand during betting phase.");
        }

        public void ChangeState(BlackjackGame game)
        {
            game.ChangeState(new PlayerTurnState());
        }
    }
}
