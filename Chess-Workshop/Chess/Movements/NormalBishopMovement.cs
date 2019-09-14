namespace Chess.Movements
{
    using Chess.Board;
    using Chess.Common;
    using Chess.Figures.Contracts;
    using Chess.Movements.Contracts;
    using System;

    public class NormalBishopMovement : IMovement
    {
        private const string BishopInvalidMoveErrorMessage = "Bishop cannot move this way!";

        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var rowDistance = Math.Abs(move.From.Row - move.To.Row);
            var colDistance = Math.Abs(move.From.Col - move.To.Col);

            if (rowDistance != colDistance)
            {
                throw new InvalidOperationException(BishopInvalidMoveErrorMessage);
            }

            var from = move.From;
            var to = move.To;

            int rowIndex = from.Row;
            char colIndex = from.Col;

            while (true)
            {
                rowIndex++;
                colIndex++;

                if (to.Row == rowIndex && to.Col == colIndex)
                {
                    var figureAtPosition = board.GetFigureAtPosition(to);

                    if (figureAtPosition != null && figureAtPosition.Color == figure.Color)
                    {
                        throw new NotImplementedException("There is a figure on your way!");
                    }
                    else
                    {
                        return;
                    }
                }

                var position = Position.FromChessCoordinates(rowIndex, colIndex);
                var figurePosition = board.GetFigureAtPosition(position);

                if (figure != null)
                {
                    throw new NotImplementedException("There is a figure on your way!");
                }
            }
        }
    }
}
