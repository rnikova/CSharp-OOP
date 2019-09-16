namespace Chess
{
    using System;
    using Chess.Engine;
    using Chess.Renderers;
    using Chess.InputProviders;
    using Chess.Engine.Contracts;
    using Chess.Renderers.Contracts;
    using Chess.Engine.Initialization;
    using Chess.InputProviders.Contracts;

    public static class ChessFacade
    {
        public static void Start()
        {
            Irenderer renderer = new ConsoleRenderer();
            //renderer.RenderMainMenu();

            IInputProvider inputProvider = new ConsoleInputProvider();

            IChessEngine chessEngine = new StandartTwoPlayerEngine(renderer, inputProvider);
            IGameInitializationStrategy gameInitializationStrategy = new StandartStartGameInitializationStrategy();

            chessEngine.Initialize(gameInitializationStrategy);
            chessEngine.Start();

            Console.ReadLine();
        }
    }
}
