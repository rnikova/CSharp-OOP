namespace Chess.Board
{
    using Chess.Common;
    using Chess.Figures.Contracts;
    using System;

    public class Board : IBoard
    {
        private readonly IFigure[,] board;

        public Board(int rows = GlobalConstants.StandartGameBoardRows, int cols = GlobalConstants.StandartGameBoardCols)
        {
            this.TotalRows = rows;
            this.TotalCols = cols;

            this.board = new IFigure[rows, cols];
        }

        public int TotalRows { get; private set; }

        public int TotalCols { get; private set; }

        public void AddFigure(IFigure figure, Position position)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigure);

            Position.CheckIfValid(position);

            int arrRow = GetArrayRow(position.Row);
            int arrCol = GetArrayCol(position.Col);

            this.board[arrRow, arrCol] = figure;
        }

        public void RemoveFigure(Position position)
        {
            Position.CheckIfValid(position);

            int arrRow = GetArrayRow(position.Row);
            int arrCol = GetArrayCol(position.Col);

            this.board[arrRow, arrCol] = null;
        }
        public IFigure GetFigureAtPosition(Position position)
        {
            int arrRow = GetArrayRow(position.Row);
            int arrCol = GetArrayCol(position.Col);

            return this.board[arrRow, arrCol];
        }

        private int GetArrayRow(int chessRow)
        {
            return this.TotalRows - chessRow;
        }

        private int GetArrayCol(char chessCol)
        {
            return chessCol - 'a';
        }
    }
}
