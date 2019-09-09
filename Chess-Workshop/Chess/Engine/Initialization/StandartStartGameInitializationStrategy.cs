namespace Chess.Engine.Initialization
{
    using System;
    using System.Collections.Generic;
    using Chess.Board;
    using Chess.Common;
    using Chess.Figures;
    using Chess.Figures.Contracts;
    using Chess.Players;

    public class StandartStartGameInitializationStrategy : IGameInitializationStrategy
    {
        private const int BoardTotalRowsAndCols = 8;

        private IList<Type> figureTypes;

        public StandartStartGameInitializationStrategy()
        {
            this.figureTypes = new List<Type>
            {
                typeof(Rook),
                typeof(Knight),
                typeof(Bishop),
                typeof(Queen),
                typeof(King),
                typeof(Bishop),
                typeof(Knight),
                typeof(Rook)
            };
        }

        public void Initialize(IList<IPlayer> players, IBoard board)
        {
            this.ValidateStrategy(players, board);

            var firstPlayer = players[0];
            var secondPlayer = players[1];

            this.AddArmyToBoardRow(firstPlayer, board, 8);
            this.AddPawnsToBoard(firstPlayer, board, 7);

            this.AddArmyToBoardRow(secondPlayer, board, 1);
            this.AddPawnsToBoard(secondPlayer, board, 2);
        }

        private void ValidateStrategy(IList<IPlayer> players, IBoard board)
        {
            if (players.Count != GlobalConstants.StandartGameNumberOfPlayers)
            {
                throw new InvalidOperationException("Standart Start Game Initialization Strategy needs exactly two players!");
            }

            if (board.TotalRows != BoardTotalRowsAndCols || board.TotalCols != BoardTotalRowsAndCols)
            {
                throw new InvalidOperationException("Standart Start Game Initialization Strategy needs 8x8 board!");
            }
        }

        private void AddPawnsToBoard(IPlayer player, IBoard board, int chessRow)
        {
            for (int i = 0; i < BoardTotalRowsAndCols; i++)
            {
                var pawn = new Pawn(player.Color);
                player.AddFigure(pawn);

                var position = new Position(chessRow, (char)(i + 'a'));
                board.AddFigure(pawn, position);
            }
        }

        private void AddArmyToBoardRow(IPlayer player, IBoard board, int chessRow)
        {
            for (int i = 0; i < BoardTotalRowsAndCols; i++)
            {
                var figureType = figureTypes[i];
                var figureInstance = (IFigure)Activator.CreateInstance(figureType, player.Color);
                var position = new Position(chessRow, (char)(i + 'a'));

                player.AddFigure(figureInstance);
                board.AddFigure(figureInstance, position);
            }
        }
    }
}
