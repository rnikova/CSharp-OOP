namespace Chess.Engine.Initialization
{
    using System.Collections.Generic;
    using Chess.Board;
    using Chess.Players;

    public interface IGameInitializationStrategy
    {
        void Initialize(IList<IPlayer> players, IBoard board);
    }
}
