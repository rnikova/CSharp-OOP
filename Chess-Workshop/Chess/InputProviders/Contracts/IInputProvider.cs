namespace Chess.InputProviders.Contracts
{
    using Chess.Common;
    using Chess.Players;
    using System.Collections.Generic;

    public interface IInputProvider
    {
        IList<IPlayer> GetPlayers(int numberOfPlayers);

        Move GetNextPlayerMove(IPlayer player);
    }
}
