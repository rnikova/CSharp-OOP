namespace Chess.Figures.Contracts
{
    using Chess.Common;
    using Chess.Movements.Contracts;
    using System.Collections.Generic;

    public interface IFigure
    {
        ChessColor Color { get; }

        ICollection<IMovement> Move();
    }
}
