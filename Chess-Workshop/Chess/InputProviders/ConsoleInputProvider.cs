namespace Chess.InputProviders
{
    using Chess.Common;
    using Chess.Common.Concole;
    using Chess.InputProviders.Contracts;
    using Chess.Players;
    using System;
    using System.Collections.Generic;

    public class ConsoleInputProvider : IInputProvider
    {
        public IList<IPlayer> GetPlayers(int numberOfPlayers)
        {
            var players = new List<IPlayer>();

            for (int i = 1; i <= numberOfPlayers; i++)
            {
                Console.Clear();
                ConsoleHelpers.SetCursorAtCenter(0);
                Console.Write(string.Format("Enter player {0} name:", i));

                string name = Console.ReadLine();

                var player = new Player(name, (ChessColor)(i - 1));
                players.Add(player);
            }

            return players;
        }
    }
}
