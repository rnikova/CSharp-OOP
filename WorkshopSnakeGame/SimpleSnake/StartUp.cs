namespace SimpleSnake
{
    using Utilities;
    using SimpleSnake.Core;
    using SimpleSnake.GameObjects;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            DrawManager drawManager = new DrawManager();
            Snake snake = new Snake();

            Engine engine = new Engine(drawManager, snake);
            engine.Run();
        }
    }
}
