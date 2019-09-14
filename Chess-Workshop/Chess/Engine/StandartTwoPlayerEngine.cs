namespace Chess.Engine
{
    using System.Collections.Generic;
    using Chess.Players;
    using Chess.Engine.Contracts;
    using Chess.Engine.Initialization;
    using Chess.Renderers.Contracts;
    using Chess.InputProviders.Contracts;
    using Chess.Common;
    using Chess.Board;
    using System;
    using Chess.Figures.Contracts;

    public class StandartTwoPlayerEngine : IChessEngine
    {
        private IList<IPlayer> players;
        private readonly Irenderer renderer;
        private readonly IInputProvider input;
        private readonly IBoard board;
        private int currentPlayerIndex;

        public StandartTwoPlayerEngine(Irenderer renderer, IInputProvider inputProvider)
        {
            this.renderer = renderer;
            this.input = inputProvider;
            this.board = new Board();
        }

        public IEnumerable<IPlayer> Players => new List<IPlayer>(this.players);

        public void Initialize(IGameInitializationStrategy gameInitializationStrategy)
        {
            this.players = new List<IPlayer>
            {new Player("Pesho", ChessColor.Black),
            new Player("Gosho", ChessColor.White)
            };
            //this.input.GetPlayers(GlobalConstants.StandartGameNumberOfPlayers);

            this.SetFirstPlayerIndex();
            gameInitializationStrategy.Initialize(this.players, this.board);
            this.renderer.RenderBoard(board);
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var player = this.GetNextPlayer();
                    var move = this.input.GetNextPlayerMove(player);
                    var from = move.From;
                    var to = move.To;
                    var figure = this.board.GetFigureAtPosition(from);

                    this.CheckIfPlayerOwnsFigure(player, figure, from);
                    this.CheckIfToPositionIsEmpty(figure, to);

                    var availableMovements = figure.Move();

                    foreach (var movement in availableMovements)
                    {
                        movement.ValidateMove(figure, board, move);
                    }
                }
                catch (Exception ex)
                {
                    this.currentPlayerIndex--;
                    this.renderer.PrintErrorMessage(ex.Message);
                }

            }

        }

        private void CheckIfToPositionIsEmpty(IFigure figure, Position to)
        {
            var figureAtPosition = this.board.GetFigureAtPosition(to);

            if (figureAtPosition != null && figureAtPosition.Color == figure.Color)
            {
                throw new InvalidOperationException(string.Format("You already have a figure at {0}{1}!", to.Col, to.Row));
            }
        }

        private void CheckIfPlayerOwnsFigure(IPlayer player, IFigure figure, Position from)
        {
            if (figure == null)
            {
                throw new InvalidOperationException(string.Format("Position {0}{1} is empty!", from.Col, from.Row));
            }

            if (figure.Color != player.Color)
            {
                throw new InvalidOperationException(string.Format("Figure at {0}{1} is not yours!", from.Col, from.Row));
            }
        }

        private void SetFirstPlayerIndex()
        {
            for (int i = 0; i < this.players.Count; i++)
            {
                if (this.players[i].Color == ChessColor.White)
                {
                    this.currentPlayerIndex = i - 1;
                    return;
                }
            }
        }

        private IPlayer GetNextPlayer()
        {
            this.currentPlayerIndex++;

            if (this.currentPlayerIndex >= this.players.Count)
            {
                this.currentPlayerIndex = 0;
            }

            return this.players[currentPlayerIndex];
        }

        public void WinnigConditions()
        {
            throw new System.NotImplementedException();
        }
    }
}
