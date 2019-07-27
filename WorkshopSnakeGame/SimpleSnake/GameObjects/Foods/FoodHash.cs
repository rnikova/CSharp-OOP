namespace SimpleSnake.GameObjects.Foods
{
    using SimpleSnake.Constants;

    public class FoodHash : Food
    {
        public FoodHash(Coordinate foodCoordinates)
            : base(GameConstants.Food.HASH_SYMBOL, GameConstants.Food.HASH_POINTS, foodCoordinates)
        {
        }
    }
}
