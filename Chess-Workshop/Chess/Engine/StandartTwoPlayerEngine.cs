namespace Chess.Engine
{
    using System.Collections.Generic;
    using Chess.Players;
    using Chess.Engine.Contracts;

    public class StandartTwoPlayerEngine : IChessEngine
    {
        private readonly IEnumerable<IPlayer> players;
        public IEnumerable<IPlayer> Players => new List<IPlayer>(this.players);

        public void Initialize()
        {
            throw new System.NotImplementedException();
        }

        public void Start()
        {
            throw new System.NotImplementedException();
        }

        public void WinnigConditions()
        {
            throw new System.NotImplementedException();
        }
    }
}
