namespace Blackjack.Server.Models.Interfaces
{
    public interface IDeckFactory
    {
        Deck CreateDeck();
        List<Deck> CreateDecks(int decksCount);
    }
}
