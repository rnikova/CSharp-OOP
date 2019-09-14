namespace Chess.Movements.Contracts
{
    using Chess.Board;
    using Chess.Common;
    using Chess.Figures.Contracts;

    public interface IMovement
    {
        void ValidateMove(IFigure figure, IBoard board, Move move);
    }
}
