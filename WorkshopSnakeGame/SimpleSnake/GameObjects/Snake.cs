namespace SimpleSnake.GameObjects
{
    using System.Linq;
    using System.Collections.Generic;

    using SimpleSnake.Enums;

    public class Snake
    {
        private const int DEFAULT_SNAKE_LENGTH = 6;
        private const int DEFAULT_X = 8;
        private const int DEFAULT_Y = 7;

        private List<Coordinate> snakeBody;

        public Snake()
        {
            this.snakeBody = new List<Coordinate>();
            this.InitializeBody();
            this.Direction = Direction.Right;
        }

        public IReadOnlyCollection<Coordinate> Body => this.snakeBody.AsReadOnly();

        public Direction Direction { get; set; }

        public void Move()
        {
            Coordinate newHead = GetNewCoordinate();

            this.snakeBody.Add(newHead);
            this.snakeBody.RemoveAt(0);
        }

        private Coordinate GetNewCoordinate()
        {
            Coordinate snakeHead = this.snakeBody.Last();
            Coordinate newHeadCoordinate = new Coordinate(snakeHead.CoordinateX, snakeHead.CoordinateY);

            switch (this.Direction)
            {
                case Direction.Right:
                    newHeadCoordinate.CoordinateX++;
                    break;
                case Direction.Left:
                    newHeadCoordinate.CoordinateX--;
                    break;
                case Direction.Down:
                    newHeadCoordinate.CoordinateY++;
                    break;
                case Direction.Up:
                    newHeadCoordinate.CoordinateY--;
                    break;
            }

            return newHeadCoordinate;
        }

        private void InitializeBody()
        {
            int x = DEFAULT_X;
            int y = DEFAULT_Y;

            for (int i = 0; i <= DEFAULT_SNAKE_LENGTH; i++)
            {
                this.snakeBody.Add(new Coordinate(x, y));
                x++;
            }
        }
    }
}
