namespace Blackjack.Server.Models.Interfaces
{
    public interface IGameState
    {
        void Bet(int amount);
        void Deal();
        void Hit();
        void Stand();
        void CheckWinner();
    }
}
