namespace Blackjack.Server.Models.Interfaces
{
    public interface IGameState
    {
        void Deal(BlackjackGame game);
        void Hit(BlackjackGame game);
        void Stand(BlackjackGame game);
        void ChangeState(BlackjackGame game);
    }
}
