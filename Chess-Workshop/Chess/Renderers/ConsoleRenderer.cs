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
            ConsoleHelpers.ClearRow(ConsoleConstants.ConsoleRowForPlayerIO);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(Console.WindowWidth / 2 - errorMessage.Length / 2, ConsoleConstants.ConsoleRowForPlayerIO);
            Console.Write(errorMessage);
            Thread.Sleep(2000);
            ConsoleHelpers.ClearRow(ConsoleConstants.ConsoleRowForPlayerIO);
        }

        public void RenderBoard(IBoard board)
        {
            var startRowPrint = Console.WindowWidth / 2 - (board.TotalRows / 2) * ConsoleConstants.CharacterPerRowPerFigure;
            var startColPrint = Console.WindowHeight / 2 - (board.TotalCols / 2) * ConsoleConstants.CharacterPerColPerFigure;

            var currentRowPrint = startRowPrint;
            var currentColPrint = startColPrint;

            this.PrintBorder(startRowPrint, startColPrint, board.TotalRows, board.TotalCols);

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
        private void PrintBorder(int startRowPrint, int startColPrint, int boardTotalRows, int boardTotalCols)
        {
            var start = startRowPrint + ConsoleConstants.CharacterPerRowPerFigure / 2;

            for (int i = 0; i < boardTotalCols; i++)
            {
                Console.SetCursorPosition(start + i * ConsoleConstants.CharacterPerRowPerFigure, startColPrint - 1);
                Console.Write((char)('A' + i));
                Console.SetCursorPosition(start + i * ConsoleConstants.CharacterPerRowPerFigure, startColPrint + boardTotalRows * ConsoleConstants.CharacterPerRowPerFigure);
                Console.Write((char)('A' + i));
            }

            start = startColPrint + ConsoleConstants.CharacterPerColPerFigure / 2;

            for (int i = 0; i < boardTotalRows; i++)
            {
                Console.SetCursorPosition(startRowPrint - 1, start + i * ConsoleConstants.CharacterPerColPerFigure);
                Console.Write(boardTotalRows - i);
                Console.SetCursorPosition(startRowPrint + boardTotalCols * ConsoleConstants.CharacterPerColPerFigure, start + i * ConsoleConstants.CharacterPerColPerFigure);
                Console.Write(boardTotalRows - i);
            }

            for (int i = startRowPrint - 2; i < startRowPrint + boardTotalRows * ConsoleConstants.CharacterPerRowPerFigure + 2; i++)
            {
                Console.BackgroundColor = DarkSquareConsoleColor;
                Console.SetCursorPosition(i, startColPrint - 2);
                Console.Write(" ");
            }

            for (int i = startRowPrint - 2; i < startRowPrint + boardTotalRows * ConsoleConstants.CharacterPerRowPerFigure + 2; i++)
            {
                Console.BackgroundColor = DarkSquareConsoleColor;
                Console.SetCursorPosition(i, startColPrint + boardTotalRows * ConsoleConstants.CharacterPerRowPerFigure + 1);
                Console.Write(" ");
            }

            for (int i = startColPrint - 2; i < startColPrint + boardTotalCols * ConsoleConstants.CharacterPerColPerFigure + 1; i++)
            {
                Console.BackgroundColor = DarkSquareConsoleColor;
                Console.SetCursorPosition(startRowPrint + boardTotalRows * ConsoleConstants.CharacterPerRowPerFigure + 1, i);
                Console.Write(" ");
            }

            for (int i = startColPrint - 2; i < startColPrint + boardTotalCols * ConsoleConstants.CharacterPerColPerFigure + 1; i++)
            {
                Console.BackgroundColor = DarkSquareConsoleColor;
                Console.SetCursorPosition(startRowPrint - 2, i);
                Console.Write(" ");
            }
        }
    }
}
