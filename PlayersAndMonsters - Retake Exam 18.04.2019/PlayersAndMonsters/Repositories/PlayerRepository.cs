namespace PlayersAndMonsters.Repositories
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Repositories.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;


    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        public int Count { get; private set; }

        public IReadOnlyCollection<IPlayer> Players => this.players.AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.NullPlayer);
            }

            if (this.Players.Any(x=>x.Username == player.Username))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistPlayer, player.Username));
            }

            this.players.Add(player);
        }

        public IPlayer Find(string username)
        {
            IPlayer findedPlayer = this.players.FirstOrDefault(p => p.Username == username);

            return findedPlayer;
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.NullPlayer);
            }

            return this.players.Remove(player);   
        }
    }
}
