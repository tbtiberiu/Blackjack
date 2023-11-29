using Blackjack.Server.Models.Interfaces;
using Blackjack.Server.Models.States;

namespace Blackjack.Server.Models
{
    public class BlackjackGame
    {
        private IGameState currentState;

        public BlackjackGame()
        {
            currentState = new BettingPhaseState(); // Start with betting phase
        }

        public void ChangeState(IGameState newState)
        {
            currentState = newState;
        }

        public void Deal()
        {
            currentState.Deal();
        }

        public void Hit()
        {
            currentState.Hit();
        }

        public void Stand()
        {
            currentState.Stand();
            currentState.ChangeState(this);
        }
    }
}
