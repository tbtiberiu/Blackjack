namespace Blackjack.Server.Models.Interfaces
{
    public interface IGameState
    {
        void Deal();
        void Hit();
        void Stand();
        void ChangeState(BlackjackGame game);
    }
}
