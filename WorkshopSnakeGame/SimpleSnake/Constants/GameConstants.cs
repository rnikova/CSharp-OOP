namespace SimpleSnake.Constants
{
    public static class GameConstants
    {
        public static class Snake
        {
            public static readonly string SNAKE_SYMBOL = "\u25CF";

            public static readonly int DEFAULT_SNAKE_LENGTH = 6;
            public static readonly int DEFAULT_X = 8;
            public static readonly int DEFAULT_Y = 7;
        }

        public static class Food
        {
            public static readonly string ASTERICS_SYMBOL = "*";
            public static readonly int ASTERICS_POINTS = 1;
            public static readonly string DOLAR_SYMBOL = "$";
            public static readonly int DOLAR_POINTS = 2;
            public static readonly string HASH_SYMBOL = "#";
            public static readonly int HASH_POINTS = 3;
        }

        public static class Border
        {
            public static readonly string BOARDER_SYMBOL = "\u2588";
            public static readonly int DEFAULT_BORDER_WIDTH = 120;
            public static readonly int DEFAULT_BORDER_HEIGHT = 40;

        }

        public static class Player
        {
            public static readonly int PLAYER_SCORE_OFFSET_X = 10;
            public static readonly int PLAYER_SCORE_OFFSET_Y = 10;
        }
    }
}
