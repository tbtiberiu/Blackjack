namespace Blackjack.Server.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Balance { get; set; }

        public Player(string name, int balance)
        {
            Name = name;
            Balance = balance;
        }
    }
}
