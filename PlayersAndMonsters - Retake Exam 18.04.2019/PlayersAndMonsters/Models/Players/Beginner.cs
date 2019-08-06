namespace PlayersAndMonsters.Models.Players
{
    using PlayersAndMonsters.Repositories.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;

    public class Beginner : Player, IPlayer
    {
        private const int InitialHealthPoints = 50;

        public Beginner(ICardRepository cardRepository, string username) 
            : base(cardRepository, username, InitialHealthPoints)
        {
        }
    }
}
