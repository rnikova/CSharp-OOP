namespace Chess.Common.Concole
{
    using Chess.Figures.Contracts;
    using System;
    using System.Collections.Generic;

    public static class ConsoleHelpers
    {
        private static IDictionary<string, bool[,]> patterns = new Dictionary<string, bool[,]>
        {
            {"Pawn", new bool[,]
                {
                    {false, false, false, false, false, false, false, false, false },
                    {false, false, false, false, false, false, false, false, false },
                    {false, false, false, false, true, false, false, false, false },
                    {false, false, false, true, true, true, false, false, false },
                    {false, false, false, true, true, true, false, false, false },
                    {false, false, false, false, true, false, false, false, false },
                    {false, false, false, true, true, true, false, false, false },
                    {false, false, true, true, true, true, true, false, false },
                    {false, false, false, false, false, false, false, false, false }
                } },
            {"Rook", new bool[,]
                {
                    {false, false, false, false, false, false, false, false, false },
                    {false, false, true, false, true, false, true, false, false },
                    {false, false, false, true, true, true, false, false, false  },
                    {false, false, false, true, true, true, false, false, false },
                    {false, false, false, true, true, true, false, false, false },
                    {false, false, false, true, true, true, false, false, false  },
                    {false, false, true, true, true, true, true, false, false  },
                    {false, false, true, true, true, true, true, false, false  },
                    {false, false, false, false, false, false, false, false, false }
                } },
            { "Knight", new bool[,]
                {
                    {false, false, false, false, false, false, false, false, false },
                    {false, false, false, false, true, true, false, false, false },
                    {false, false, false, true, true, true, true, false, false  },
                    {false, false, true, true, true, false, true, false, false },
                    {false, false, true, true, false, true, true, false, false },
                    {false, false, false, false, true, true, true, false, false  },
                    {false, false, false, true, true, true, false, false, false  },
                    {false, false, true, true, true, true, true, false, false  },
                    {false, false, false, false, false, false, false, false, false }
                } },
            {"Bishop", new bool[,]
                {
                    {false, false, false, false, false, false, false, false, false },
                    {false, false, false, false, true, false, false, false, false },
                    {false, false, false, true, true, true, false, false, false },
                    {false, false, true, true, false, true, true, false, false },
                    {false, false, true, false, false, false, true, false, false },
                    {false, false, false, true, false, true, false, false, false },
                    {false, false, false, false, true, false, false, false, false },
                    {false, true, true, true, false, true, true, true, false },
                    {false, false, false, false, false, false, false, false, false }
                } },
            {"King", new bool[,]
                {
                    {false, false, false, false, false, false, false, false, false },
                    {false, false, false, false, true, false, false, false, false },
                    {false, false, false, true, true, true, false, false, false },
                    {false, true, true, false, true, false, true, true, false },
                    {false, true, true, true, false, true, true, true, false },
                    {false, true, true, true, true, true, true, true, false },
                    {false, false, true, true, true, true, true, false, false },
                    {false, false, true, true, true, true, true, false, false },
                    {false, false, false, false, false, false, false, false, false }
                } },
            {"Queen", new bool[,]
                {
                    {false, false, false, false, false, false, false, false, false },
                    {false, false, false, false, true, false, false, false, false },
                    {false, false, true, false, true, false, true, false, false },
                    {false, false, false, true, false, true, false, false, false },
                    {false, true, false, true, true, true, false, true, false },
                    {false, false, true, false, true, false, true, false, false },
                    {false, false, true, true, false, true, true, false, false },
                    {false, false, true, true, true, true, true, false, false },
                    {false, false, false, false, false, false, false, false, false }
                } }
        };

        public static ConsoleColor ToConsoleColor(this ChessColor chessColor)
        {
            switch (chessColor)
            {
                case ChessColor.Black:
                    return ConsoleColor.Black;
                case ChessColor.White:
                    return ConsoleColor.White;
                case ChessColor.Blue:
                    return ConsoleColor.DarkYellow;
                default:
                    throw new InvalidOperationException("Cannot convert chess color!");
            }
        }

        public static void SetCursorAtCenter(int lengthOfMessage)
        {
            int centerRow = Console.WindowHeight / 2;
            int centerCol = Console.WindowWidth / 2 - lengthOfMessage / 2;
            Console.SetCursorPosition(centerCol, centerRow);
        }

        public static void PrintFigure(IFigure figure, ConsoleColor backgroudColor, int top, int left)
        {
            if (figure == null)
            {
                PrintEmtySquare(backgroudColor, top, left);
                return;
            }

            if (!patterns.ContainsKey(figure.GetType().Name))
            {
                return;
            }

            var figurePatern = patterns[figure.GetType().Name];

            for (int i = 0; i < figurePatern.GetLength(0); i++)
            {
                for (int k = 0; k < figurePatern.GetLength(1); k++)
                {
                    Console.SetCursorPosition(left + k, top + i);

                    if (figurePatern[i, k])
                    {
                        Console.BackgroundColor = figure.Color.ToConsoleColor();
                    }
                    else
                    {
                        Console.BackgroundColor = backgroudColor;
                    }

                    Console.Write(" ");
                }
            }
        }

        public static void PrintEmtySquare(ConsoleColor backgroudColor, int top, int left)
        {
            for (int i = 0; i < ConsoleConstants.CharacterPerRowPerFigure; i++)
            {
                for (int k = 0; k < ConsoleConstants.CharacterPerColPerFigure; k++)
                {
                    Console.SetCursorPosition(left + k, top + i);
                    Console.Write(" ");
                }
            }
        }

        public static Move CreateMoveFromCommand(string command)
        {
            var positionAsStringParts = command.Split('-' );

            if (positionAsStringParts.Length != 2)
            {
                throw new InvalidOperationException("Invalid command!");
            }
            var fromAsString = positionAsStringParts[0];
            var toAsString = positionAsStringParts[1];

            var fromPosition = Position.FromChessCoordinates(fromAsString[1] - '0', fromAsString[0]);
            var toPosition = Position.FromChessCoordinates(toAsString[1] - '0', toAsString[0]);

            return new Move(fromPosition, toPosition);
        }

        public static void ClearRow(int row)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, row);
            Console.Write(new string(' ', Console.WindowWidth));
        }
    }
}
