using Chess.Players;
using System.Collections.Generic;

namespace Chess.Engine.Contracts
{
    public interface IChessEngine
    {
        void Initialize();

        void Start();

        void WinnigConditions();
    }
}
