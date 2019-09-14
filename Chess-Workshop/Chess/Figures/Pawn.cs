namespace Chess.Figures
{
    using System.Collections.Generic;
    using Chess.Common;
    using Chess.Figures.Contracts;
    using Chess.Movements;
    using Chess.Movements.Contracts;

    public class Pawn : BaseFigure, IFigure
    {
        public Pawn(ChessColor color)
            : base(color)
        {
        }

        public override ICollection<IMovement> Move(IMovementStrategy movementStrategy)
        {
           return movementStrategy.GetMovements(this.GetType().Name);
        }
    }
}
