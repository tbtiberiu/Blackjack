using Blackjack.Server.Models.Interfaces;

namespace Blackjack.Server.Models.States
{
    public class DealerTurnState : IGameState
    {
        public void Deal(BlackjackGame game)
        {
            Console.WriteLine("Cannot deal during dealer's turn.");
        }

        public void Hit(BlackjackGame game)
        {
            if(game.dealerHand.ShouldHit())
            {
                //last deck
                var card = game.decks[0];
                game.dealerHand.AddCard((Card)card);

            }
            else
            {
          
            }
        }

        public void Stand(BlackjackGame game)
        {
            Console.WriteLine("Dealer stands.");
        }

        public void ChangeState(BlackjackGame game)
        {
            game.ChangeState(new GameOverState());
        }
    }

}
