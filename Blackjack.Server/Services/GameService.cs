using Blackjack.Server.Models;
using Blackjack.Server.Models.Interfaces;

namespace Blackjack.Server.Services
{
    public class GameService
    {
        readonly BlackjackGame _blackjackGame = BlackjackGame.Instance;

        public GameService() { }

        public void PlaceBet(int amount)
        {
            _blackjackGame.Bet(amount);
        }

        public int PlayerBalance()
        {
            return _blackjackGame.GetPlayerBalance();
        }

        public void StartNewGame()
        {
            _blackjackGame.StartNewGame();
        }

        public BlackjackGame GetGame()
        {
            return _blackjackGame;
        }

        public void DealCards()
        {
            _blackjackGame.Deal();
        }
        
        public void Hit()
        {
           _blackjackGame.Hit();
        }
        
        public void Stand()
        {
            _blackjackGame.Stand();
        }

        public string CheckWinner()
        {
            return (_blackjackGame.CheckWinner());
        }
    }
}
