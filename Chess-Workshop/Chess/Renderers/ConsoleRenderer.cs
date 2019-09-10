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
        private const int CharacterPerRowPerFigure = 9;
        private const int CharacterPerColPerFigure = 9;
        private const ConsoleColor DarkSquareConsoleColor = ConsoleColor.DarkGray;
        private const ConsoleColor LightSquareConsoleColor = ConsoleColor.Gray;

        public void RenderBoard(IBoard board)
        {
            var startRowPrint = Console.WindowHeight / 2 - (board.TotalRows / 2) * CharacterPerRowPerFigure;
            var startColPrint = Console.WindowWidth / 2 - (board.TotalCols / 2) * CharacterPerColPerFigure;

            var currentRowPrint = startRowPrint;
            var currentColPrint = startColPrint;

            Console.BackgroundColor = ConsoleColor.White;

            int counter = 0;

            for (int top = 0; top < board.TotalRows; top++)
            {
                for (int left = 0; left < board.TotalCols; left++)
                {
                    currentRowPrint = startRowPrint + left * CharacterPerColPerFigure;
                    currentColPrint = startColPrint + top * CharacterPerRowPerFigure;

                    if (counter % 2 == 0)
                    {
                        Console.BackgroundColor = DarkSquareConsoleColor;
                    }
                    else
                    {
                        Console.BackgroundColor = LightSquareConsoleColor;
                    }

                    Console.SetCursorPosition(currentColPrint, currentRowPrint);
                    Console.Write(" ");

                    counter++;
                }

                counter++;
            }


            Console.ReadLine();
        }

        public void RenderMainMenu()
        {
            ConsoleHelpers.SetCursorAtCenter(Logo.Length);
            Console.WriteLine(Logo);

            Thread.Sleep(1000);
        }
    }
}
