﻿namespace Chess.Players
{
    using Chess.Common;
    using Chess.Figures;
    using System;
    using System.Collections.Generic;

    public class Player
    {
        private readonly ICollection<IFigure> figures;

        public ChessColor Color { get; private set; }

        public Player(ChessColor color)
        {
            this.figures = new List<IFigure>();
            this.Color = color;
        }

        public void AddFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigure);
            CheckIfFigureExist(figure);

            this.figures.Add(figure);
        }

        public void RemoveFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigure);
            CheckIfFigureDoesNotExist(figure);

            this.figures.Remove(figure);
        }

        private void CheckIfFigureExist(IFigure figure)
        {
            if (this.figures.Contains(figure))
            {
                throw new InvalidOperationException("This player already owns this figure!");
            }
        }

        private void CheckIfFigureDoesNotExist(IFigure figure)
        {
            if (!this.figures.Contains(figure))
            {
                throw new InvalidOperationException("This player does not owns this figure!");
            }
        }
    }
}
