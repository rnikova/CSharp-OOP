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
    using System.Linq;

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
                }
                catch (Exception ex)
                {
                    this.currentPlayerIndex--;
                    this.renderer.PrintErrorMessage(ex.Message);
                }

            }

        }

        private void SetFirstPlayerIndex()
        {
            for (int i = 0; i < this.players.Count; i++)
            {
                if (this.players[i].Color == ChessColor.White)
                {
                    this.currentPlayerIndex = i;
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
