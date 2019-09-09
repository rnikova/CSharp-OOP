namespace Chess.InputProviders.Contracts
{
    using Chess.Players;
    using System.Collections.Generic;

    public interface IInputProvider
    {
        IList<IPlayer> GetPlayers(int numberOfPlayers);
    }
}
