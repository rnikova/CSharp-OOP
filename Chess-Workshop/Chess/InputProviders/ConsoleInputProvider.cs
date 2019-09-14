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
        private const string PlayerNameText = "Enter player {0} name:";

        public IList<IPlayer> GetPlayers(int numberOfPlayers)
        {
            var players = new List<IPlayer>();

            for (int i = 1; i <= numberOfPlayers; i++)
            {
                Console.Clear();
                ConsoleHelpers.SetCursorAtCenter(PlayerNameText.Length);
                Console.Write(string.Format(PlayerNameText, i));

                string name = Console.ReadLine();

                var player = new Player(name, (ChessColor)(i - 1));
                players.Add(player);
            }

            return players;
        }
        public Move GetNextPlayerMove(IPlayer player)
        {
            ConsoleHelpers.ClearRow(ConsoleConstants.ConsoleRowForPlayerIO);
            Console.SetCursorPosition(Console.WindowWidth / 2 - 8, ConsoleConstants.ConsoleRowForPlayerIO);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("{0} is next: ", player.Name);

            var positionAsString = Console.ReadLine().Trim().ToLower();

            return ConsoleHelpers.CreateMoveFromCommand(positionAsString);
        }
    }
}
