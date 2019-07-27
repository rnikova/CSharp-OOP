namespace SimpleSnake.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using SimpleSnake.Enums;
    using SimpleSnake.Constants;
    using SimpleSnake.Factories;
    using SimpleSnake.GameObjects;
    using SimpleSnake.GameObjects.Foods;

    public class Engine
    {
        private DrawManager drawManager;
        private Snake snake;
        private Food food;
        private Coordinate borderCoordinate;
        private int gameScore;

        public Engine(DrawManager drawManager, Snake snake, Coordinate borderCoordinate)
        {
            this.drawManager = drawManager;
            this.snake = snake;
            this.borderCoordinate = borderCoordinate;
            this.InitializeFood();
            this.InitializeBorders();
        }

        public void Run()
        {
            while (true)
            {
                this.PlayerInfo();

                if (Console.KeyAvailable)
                {
                    this.SetCorrectDirection(Console.ReadKey());
                }
                drawManager.Draw(food.FoodSymbol, new List<Coordinate> { food.FoodCoordinates });

                this.drawManager.Draw(GameConstants.Snake.SNAKE_SYMBOL, this.snake.Body);
                this.snake.Move();
                this.drawManager.UndoDraw();

                if (HasFoodCollision())
                {
                    this.snake.Eat(this.food);
                    this.gameScore += this.food.FoodPoints;

                    this.InitializeFood();
                }

                if (HasBorderCollision())
                {
                    this.AskPlayerForRestart();
                }

                if (this.snake.Direction == Direction.Up || this.snake.Direction == Direction.Down)
                {
                    Thread.Sleep(200);
                }
                else
                {
                    Thread.Sleep(150);
                }
            }
        }

        private void PlayerInfo()
        {
            int x = GameConstants.Border.DEFAULT_BORDER_WIDTH + GameConstants.Player.PLAYER_SCORE_OFFSET_X;
            int y = GameConstants.Player.PLAYER_SCORE_OFFSET_Y;

            Console.SetCursorPosition(x, y);

            Console.Write($"Game score: {this.gameScore}");
        }

        private void AskPlayerForRestart()
        {
            int x = 45;
            int y = 20;

            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Would you like to continue? y/n");

            var input = Console.ReadKey();

            if (input.Key == ConsoleKey.Y)
            {
                Console.Clear();
                StartUp.Main();
            }
            else if(input.Key == ConsoleKey.N)
            {
                StopGame();
            }
        }

        private void StopGame()
        {
            Console.SetCursorPosition(20, 10);
            Console.Write("Game over!");
            Environment.Exit(0);
        }

        private bool HasBorderCollision()
        {
            int snakeHeadCoordinateX = this.snake.Head.CoordinateX;
            int snakeHeadCoordinateY = this.snake.Head.CoordinateY;

            int borderCoordinateX = this.borderCoordinate.CoordinateX;
            int borderCoordinateY = this.borderCoordinate.CoordinateY;

            return snakeHeadCoordinateX == borderCoordinateX - 1
                || snakeHeadCoordinateX == 0
                || snakeHeadCoordinateY == borderCoordinateY - 1
                || snakeHeadCoordinateY == 0;
        }

        private void InitializeBorders()
        {
            List<Coordinate> allCoodinate = new List<Coordinate>();

            this.InitializeHorizontalBorderCoordinate(0, allCoodinate);
            this.InitializeHorizontalBorderCoordinate(this.borderCoordinate.CoordinateY, allCoodinate);
            this.InitializeVerticalBorderCoordinate(0, allCoodinate);
            this.InitializeVerticalBorderCoordinate(this.borderCoordinate.CoordinateX -1, allCoodinate);

            this.drawManager.Draw(GameConstants.Border.BOARDER_SYMBOL, allCoodinate);
        }

        private void InitializeVerticalBorderCoordinate(int coordinateX, List<Coordinate> allCoodinate)
        {
            for (int coordinateY = 0; coordinateY < this.borderCoordinate.CoordinateY; coordinateY++)
            {
                allCoodinate.Add(new Coordinate(coordinateX, coordinateY));
            }
        }

        private void InitializeHorizontalBorderCoordinate(int coordinateY, List<Coordinate> allCoodinate)
        {
            for (int coordinateX = 0; coordinateX < this.borderCoordinate.CoordinateX; coordinateX++)
            {
                allCoodinate.Add(new Coordinate(coordinateX, coordinateY));
            }
        }

        private void InitializeFood()
        {
            this.food = FoodFactory.GetRandomFood(this.borderCoordinate.CoordinateX, this.borderCoordinate.CoordinateY);
        }

        private bool HasFoodCollision()
        {
            int snakeHeadCoordinateX = this.snake.Head.CoordinateX;
            int snakeHeadCoordinateY = this.snake.Head.CoordinateY;

            int foodCoordinateX = this.food.FoodCoordinates.CoordinateX;
            int foodCoordinateY = this.food.FoodCoordinates.CoordinateY;

            return snakeHeadCoordinateX == foodCoordinateX && snakeHeadCoordinateY == foodCoordinateY;
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
