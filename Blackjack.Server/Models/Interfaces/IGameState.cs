namespace Blackjack.Server.Models.Interfaces
{
    public interface IGameState
    {
        void Bet(int amount);
        void Deal();
        ICard Hit();
        void Stand();
        string CheckWinner();
    }
}
