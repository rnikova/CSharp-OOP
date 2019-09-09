namespace Chess
{
    using Chess.Engine;
    using Chess.Engine.Contracts;
    using Chess.Engine.Initialization;
    using Chess.InputProviders;
    using Chess.InputProviders.Contracts;
    using Chess.Renderers;
    using Chess.Renderers.Contracts;
    using System;

    public class EntryPoints
    {
        public static void Main(string[] args)
        {
            Irenderer renderer = new ConsoleRenderer();
            renderer.RenderMainMenu();

            IInputProvider inputProvider = new ConsoleInputProvider();

            IChessEngine chessEngine = new StandartTwoPlayerEngine(renderer, inputProvider);
            IGameInitializationStrategy gameInitializationStrategy = new StandartStartGameInitializationStrategy();

            chessEngine.Initialize(gameInitializationStrategy);
            chessEngine.Start();

            Console.ReadLine();
        }
    }
}
