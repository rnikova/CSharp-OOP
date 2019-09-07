namespace Chess.Engine.Initialization
{
    using System;
    using System.Collections.Generic;
    using Chess.Board;
    using Chess.Players;

    public class StandartStartGameInitializationStrategy : IGameInitializationStrategy
    {
        private const int NumberOfPlayers = 2;
        private const int BoardTotalRowsAndCols = 8;

        public void Initialize(IList<IPlayer> players, IBoard board)
        {
            this.ValidateStrategy(players, board);
        }

        private void ValidateStrategy(IList<IPlayer> players, IBoard board)
        {
            if (players.Count != NumberOfPlayers)
            {
                throw new InvalidOperationException("Standart Start Game Initialization Strategy needs exactly two players!");
            }

            if (board.TotalRows != BoardTotalRowsAndCols || board.TotalCols != BoardTotalRowsAndCols)
            {
                throw new InvalidOperationException("Standart Start Game Initialization Strategy needs 8x8 board!");
            }
        }
    }
}
