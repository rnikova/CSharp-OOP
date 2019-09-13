namespace Chess.Renderers
{
    using System;
    using System.Threading;
    using Chess.Board;
    using Chess.Common;
    using Chess.Common.Concole;
    using Chess.Renderers.Contracts;

    public class ConsoleRenderer : Irenderer
    {
        private const string Logo = "MY CHESS";
        private const ConsoleColor DarkSquareConsoleColor = ConsoleColor.DarkGray;
        private const ConsoleColor LightSquareConsoleColor = ConsoleColor.Gray;

        public ConsoleRenderer()
        {
            if (Console.WindowWidth < 100 || Console.WindowHeight < 80)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Clear();

                Console.WriteLine("Please, set the Console window and buffer size to 100x80.");
                Environment.Exit(0);
            }
        }

        public void PrintErrorMessage(string errorMessage)
        {
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(Console.WindowWidth / 2 - 8, ConsoleConstants.ConsoleRowForPlayerIO);
            Console.Write(errorMessage);
            Thread.Sleep(1500);
            ConsoleHelpers.ClearRow(ConsoleConstants.ConsoleRowForPlayerIO);
        }

        public void RenderBoard(IBoard board)
        {
            var startRowPrint = Console.WindowWidth / 2 - (board.TotalRows / 2) * ConsoleConstants.CharacterPerRowPerFigure;
            var startColPrint = Console.WindowHeight / 2 - (board.TotalCols / 2) * ConsoleConstants.CharacterPerColPerFigure;

            var currentRowPrint = startRowPrint;
            var currentColPrint = startColPrint;

            Console.BackgroundColor = ConsoleColor.White;

            int counter = 1;

            for (int top = 0; top < board.TotalRows; top++)
            {
                for (int left = 0; left < board.TotalCols; left++)
                {
                    currentColPrint = startRowPrint + left * ConsoleConstants.CharacterPerColPerFigure;
                    currentRowPrint = startColPrint + top * ConsoleConstants.CharacterPerRowPerFigure;

                    ConsoleColor backgroudColor;

                    if (counter % 2 == 0)
                    {
                        backgroudColor = DarkSquareConsoleColor;
                        Console.BackgroundColor = DarkSquareConsoleColor;
                    }
                    else
                    {
                        backgroudColor = LightSquareConsoleColor;
                        Console.BackgroundColor = LightSquareConsoleColor;
                    }

                    var position = Position.FromArrayCoordinates(top, left, board.TotalRows);
                    var figure = board.GetFigureAtPosition(position);

                    ConsoleHelpers.PrintFigure(figure, backgroudColor, currentRowPrint, currentColPrint);

                    


                    counter++;
                }

                counter++;
            }
        }

        public void RenderMainMenu()
        {
            ConsoleHelpers.SetCursorAtCenter(Logo.Length);
            Console.WriteLine(Logo);

            Thread.Sleep(1000);
        }
    }
}
