namespace Chess.Engine.Contracts
{
    using Chess.Engine.Initialization;
    using Chess.Players;
    using System.Collections.Generic;

    public interface IChessEngine
    {
        void Initialize(IGameInitializationStrategy gameInitializationStrategy);

        void Start();

        void WinnigConditions();
    }
}
