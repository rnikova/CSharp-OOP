namespace SimpleSnake.Core
{
    using System;
    using System.Threading;

    using SimpleSnake.Enums;
    using SimpleSnake.GameObjects;

    public class Engine
    {
        private const string SNAKE_SYMBOL = "\u25CF";

        private DrawManager drawManager;
        private Snake snake;

        public Engine(DrawManager drawManager, Snake snake)
        {
            this.drawManager = drawManager;
            this.snake = snake;
        }

        public void Run()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    this.SetCorrectDirection(Console.ReadKey());
                }

                this.drawManager.Draw(SNAKE_SYMBOL, this.snake.Body);
                this.snake.Move();
                this.drawManager.UndoDraw();

                Thread.Sleep(100);
            }
        }

        private void SetCorrectDirection(ConsoleKeyInfo consoleKeyInfo)
        {
            Direction currentSnakeDirection = this.snake.Direction;

            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.DownArrow:
                    if (currentSnakeDirection != Direction.Up)
                    {
                        currentSnakeDirection = Direction.Down;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (currentSnakeDirection != Direction.Right)
                    {
                        currentSnakeDirection = Direction.Left;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (currentSnakeDirection != Direction.Left)
                    {
                        currentSnakeDirection = Direction.Right;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (currentSnakeDirection != Direction.Down)
                    {
                        currentSnakeDirection = Direction.Up;
                    }
                    break;
            }

            this.snake.Direction = currentSnakeDirection;
        }
    }
}
