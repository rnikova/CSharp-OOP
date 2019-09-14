namespace Chess.Movements
{
    using Chess.Board;
    using Chess.Common;
    using Chess.Figures.Contracts;
    using Chess.Movements.Contracts;
    using System;

    public class NormalPawnMovement : IMovement
    {
        private const string PawnsBackwardsErrorMessage = "Pawns cannot move backwards!";
        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var color = figure.Color;
            var from = move.From;
            var to = move.To;

            if (color == ChessColor.White && to.Row < from.Row)
            {
                throw new InvalidOperationException(PawnsBackwardsErrorMessage);
            }
            if (color == ChessColor.Black && to.Row > from.Row)
            {
                throw new InvalidOperationException(PawnsBackwardsErrorMessage);
            }

            if (color == ChessColor.White)
            {
                if (from.Row + 1 == to.Row && this.CheckDiagonalMove(from, to))
                {
                    if (this.CheckOtherFigureIfValid(board, to, ChessColor.Black))
                    {
                        return;
                    }
                }
            }
            else if (color == ChessColor.Black)
            {
                if (from.Row - 1 == to.Row && this.CheckDiagonalMove(from, to))
                {
                    if (this.CheckOtherFigureIfValid(board, to, ChessColor.White));
                    {
                        return;
                    }
                }
            }


        }

        private bool CheckOtherFigureIfValid(IBoard board, Position to, ChessColor color)
        {
            var otherFigure = board.GetFigureAtPosition(to);

            if (otherFigure != null && otherFigure.Color == color)
            {
                return true;
            }

            return false;
        }

        private bool CheckDiagonalMove(Position from, Position to)
        {
            return from.Col + 1 == to.Col || from.Col - 1 == to.Col;
        }
    }
}
