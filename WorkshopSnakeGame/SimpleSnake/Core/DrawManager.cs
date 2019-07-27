namespace SimpleSnake.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using SimpleSnake.Constants;
    using SimpleSnake.GameObjects;

    public class DrawManager
    {
        private List<Coordinate> snakeBodyElements;

        public DrawManager()
        {
            this.snakeBodyElements = new List<Coordinate>();
        }

        public void Draw(string symbol, IEnumerable<Coordinate> coordinates)
        {
            foreach (var coordinate in coordinates)
            {
                if (symbol == GameConstants.Snake.SNAKE_SYMBOL)
                {
                    snakeBodyElements.Add(coordinate);
                }

                Console.SetCursorPosition(coordinate.CoordinateX, coordinate.CoordinateY);
                Console.Write(symbol);
            }
        }

        public void UndoDraw()
        {
            Coordinate lastElement = snakeBodyElements.First();

            Console.SetCursorPosition(lastElement.CoordinateX, lastElement.CoordinateY);
            Console.Write(" ");

            this.snakeBodyElements.Clear();
        }
    }
}