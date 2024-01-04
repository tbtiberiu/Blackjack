using Blackjack.Server.Models.Interfaces;
using Blackjack.Server.Models.States;

namespace Blackjack.Server.Models
{
    public sealed class BlackjackGame
    {
        private IGameState _currentState;
        private static BlackjackGame? _instance;
        private DealingPack _dealingPack;

        public PlayerHand PlayerHand { get; private set; }
        public DealerHand DealerHand {  get; private set; }
        public Player Player { get; private set; }

        private BlackjackGame()
        {
            _currentState = new BettingPhaseState(); // Start with betting phase
            _dealingPack = new DealingPack();
            PlayerHand = new PlayerHand();
            DealerHand = new DealerHand();
            Player = new Player("Dragos", 100);
        }

        public static BlackjackGame Instance
        {
            get
            {
                _instance ??= new BlackjackGame();
                return _instance;
            }
        }
        
        public void ChangeState(IGameState newState)
        {
            _currentState = newState;
        }

        public void Bet(int amount)
        {
            _currentState.Bet(amount);
        }

        public void Deal()
        {
            _currentState.Deal();
        }

        public void Hit()
        {
           _currentState.Hit();
        }

        public void HitDealer()
        {
            while(_currentState is DealerTurnState)
            {
                _currentState.Hit();
            }
        }

        public void Stand()
        {
            _currentState.Stand();
        }

        public string CheckWinner()
        {
            return _currentState.CheckWinner();
        }

        public ICard DrawCard()
        {
            return _dealingPack.DrawCard();
        }

        public int GetPlayerBalance()
        {
            return Player != null ? Player.Balance : 0;
        }

        public void StartNewGame()
        {
            _currentState = new BettingPhaseState(); // Start with betting phase
            PlayerHand.NewHand();
            DealerHand.NewHand();
        }
    }
}
