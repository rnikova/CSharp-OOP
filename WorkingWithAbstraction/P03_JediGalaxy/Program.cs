namespace P03_JediGalaxy
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] dimestions = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int row = dimestions[0];
            int col = dimestions[1];

            int[,] matrix = new int[row, col];

            FillTheMatrix(matrix, row, col);

            string command = Console.ReadLine();
            long collectedStarsValue = 0;

            while (command != "Let the Force be with you")
            {
                int[] ivoCoordinates = command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] evilCoordinates = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                MoveThroughTheStarsEvil(evilCoordinates, matrix);

                collectedStarsValue = MoveThroughTheStarsIvo(ivoCoordinates, matrix, collectedStarsValue);                              

                command = Console.ReadLine();
            }

            Console.WriteLine(collectedStarsValue);

        }

        private static long MoveThroughTheStarsIvo(int[] ivoCoordinates, int[,] matrix, long collectedStarsValue)
        {
            int ivoRow = ivoCoordinates[0];
            int ivoCol = ivoCoordinates[1];

            while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
            {
                if (ivoRow < matrix.GetLength(0) && ivoCol >= 0)
                {
                    collectedStarsValue += matrix[ivoRow, ivoCol];
                }

                ivoCol++;
                ivoRow--;
            }

            return collectedStarsValue;
        }

        private static int[,] MoveThroughTheStarsEvil(int[] evilCoordinates, int[,] matrix)
        {
            int evilRow = evilCoordinates[0];
            int evilsCol = evilCoordinates[1];

            while (evilRow >= 0 && evilsCol >= 0)
            {
                if (evilRow < matrix.GetLength(0) && evilsCol < matrix.GetLength(1))
                {
                    matrix[evilRow, evilsCol] = 0;
                }
                evilRow--;
                evilsCol--;
            }

            return matrix;
        }

        private static void FillTheMatrix(int[,] matrix, int row, int col)
        {
            int curentNumber = 0;

            for (int rows = 0; rows < row; rows++)
            {
                for (int cols = 0; cols < col; cols++)
                {
                    matrix[rows, cols] = curentNumber++;
                }
            }
        }
    }
}
