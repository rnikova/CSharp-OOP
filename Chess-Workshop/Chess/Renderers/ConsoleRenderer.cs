namespace Chess.Renderers
{
    using System;
    using System.Threading;
    using Chess.Board;
    using Chess.Common.Concole;
    using Chess.Renderers.Contracts;

    public class ConsoleRenderer : Irenderer
    {
        private const string Logo = "MY CHESS";
        public void RenderBoard(IBoard board)
        {
            

            
        }

        public void RenderMainMenu()
        {
            ConsoleHelpers.SetCursorAtCenter(Logo.Length);
            Console.WriteLine(Logo);

            Thread.Sleep(1000);
        }
    }
}
