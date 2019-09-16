namespace Chess.Common
{
    using System;

    public struct Position
    {
        public static Position FromArrayCoordinates(int arrRow, int arrCol, int totalRows)
        {
            return new Position(totalRows - arrRow, (char)(arrCol + 'a'));
        }

        public static Position FromChessCoordinates(int chessRow, char chessCol)
        {
            var newPosition = new Position(chessRow, chessCol);
            CheckIfValid(newPosition);

            return newPosition;
        }

        public static void CheckIfValid(Position position)
        {
            if (position.Row < GlobalConstants.MinimumRowValueOnBoard
                 || position.Row > GlobalConstants.MaximumRowValueOnBoard)
            {
                throw new IndexOutOfRangeException(GlobalErrorMessages.OutOfRangeRowPosition);
            }

            if (position.Col < GlobalConstants.MinimumColValueOnBoard
                || position.Col > GlobalConstants.MaximumColValueOnBoard)
            {
                throw new IndexOutOfRangeException(GlobalErrorMessages.OutOfRangeColPosition);
            }

        }
        public Position(int row, char col)
            : this()
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; private set; }

        public char Col { get; private set; }
    }
}
