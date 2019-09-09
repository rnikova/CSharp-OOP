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

    public class StandartTwoPlayerEngine : IChessEngine
    {
        private readonly IEnumerable<IPlayer> players;
        private readonly Irenderer renderer;
        private readonly IInputProvider input;
        private readonly IBoard board;

        public StandartTwoPlayerEngine(Irenderer renderer, IInputProvider inputProvider)
        {
            this.renderer = renderer;
            this.input = inputProvider;
            this.board = new Board();
        }

        public IEnumerable<IPlayer> Players => new List<IPlayer>(this.players);

        public void Initialize(IGameInitializationStrategy gameInitializationStrategy)
        {
            var players = this.input.GetPlayers(GlobalConstants.StandartGameNumberOfPlayers);

            gameInitializationStrategy.Initialize(players, this.board);
            this.renderer.RenderBoard(board);
        }

        public void Start()
        {
            throw new System.NotImplementedException();
        }

        public void WinnigConditions()
        {
            throw new System.NotImplementedException();
        }
    }
}
