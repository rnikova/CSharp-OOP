namespace Chess.Common.Concole
{
    using Chess.Figures.Contracts;
    using System;

    public static class ConsoleHelpers
    {
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
    }
}
