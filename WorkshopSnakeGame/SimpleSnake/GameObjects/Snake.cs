namespace SimpleSnake.GameObjects
{
    using System.Collections.Generic;

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
        }

        private void InitializeBody()
        {
            int x = DEFAULT_X;
            int y = DEFAULT_Y;

            for (int i = 0; i < 6; i++)
            {
                this.snakeBody.Add(new Coordinate(x, y));
                x++;
            }
        }
    }
}
