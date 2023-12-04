using Blackjack.Server.Models.Interfaces;
using Blackjack.Server.Models.States;

namespace Blackjack.Server.Models
{
    public class BlackjackGame
    {
        private IGameState currentState;
        private static BlackjackGame instance;
        public PlayerHand playerHand;
        public DealerHand dealerHand;
        public List<ICard> decks;
        private BlackjackGame()
        {
            currentState = new BettingPhaseState(); // Start with betting phase
            playerHand = new PlayerHand();
            dealerHand = new DealerHand();
            decks = new List<ICard>();
        }
        public static BlackjackGame GetInstance()
        {
            if (instance == null)
            {
                instance = new BlackjackGame();
            }
            return instance;
        }
        public void ChangeState(IGameState newState)
        {
            currentState = newState;
        }

        public void Deal(BlackjackGame game)
        {
            currentState.Deal(game);
        }

        public void Hit(BlackjackGame game)
        {
            currentState.Hit(game);
        }

        public void Stand(BlackjackGame game)
        {
            currentState.Stand(game);
            currentState.ChangeState(this);
        }
    }
}
