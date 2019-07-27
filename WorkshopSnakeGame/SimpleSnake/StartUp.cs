namespace SimpleSnake
{
    using Utilities;
    using SimpleSnake.Core;
    using SimpleSnake.Constants;
    using SimpleSnake.GameObjects;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            DrawManager drawManager = new DrawManager();
            Snake snake = new Snake();
            Coordinate borderCoordinates =
                new Coordinate(GameConstants.Border.DEFAULT_BORDER_WIDTH, GameConstants.Border.DEFAULT_BORDER_HEIGHT);

            Engine engine = new Engine(drawManager, snake, borderCoordinates);
            engine.Run();
        }
    }
}
