namespace SimpleSnake.GameObjects
{
    using System.Linq;
    using System.Collections.Generic;

    using SimpleSnake.Enums;
    using SimpleSnake.GameObjects.Foods;
    using System;
    using SimpleSnake.Constants;

    public class Snake
    {
        private List<Coordinate> snakeBody;

        public Snake()
        {
            this.snakeBody = new List<Coordinate>();
            this.InitializeBody();
            this.Direction = Direction.Right;
        }

        public IReadOnlyCollection<Coordinate> Body => this.snakeBody.AsReadOnly();

        public Direction Direction { get; set; }

        public Coordinate Head => this.snakeBody.Last();

        public void Move()
        {
            Coordinate newHead = GetNewCoordinate();

            this.snakeBody.Add(newHead);
            this.snakeBody.RemoveAt(0);
        }

        private Coordinate GetNewCoordinate()
        {
            Coordinate newHeadCoordinate = new Coordinate(this.Head.CoordinateX, this.Head.CoordinateY);

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

        public void Eat(Food food)
        {
            for (int i = 0; i < food.FoodPoints; i++)
            {
                Coordinate newHeadCoordinate = this.GetNewCoordinate();
                this.snakeBody.Add(newHeadCoordinate);
            }
        }

        private void InitializeBody()
        {
            int x = GameConstants.Snake.DEFAULT_X;
            int y = GameConstants.Snake.DEFAULT_Y;

            for (int i = 0; i <= GameConstants.Snake.DEFAULT_SNAKE_LENGTH; i++)
            {
                this.snakeBody.Add(new Coordinate(x, y));
                x++;
            }
        }
    }
}
