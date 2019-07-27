namespace SimpleSnake.GameObjects.Foods
{
    using SimpleSnake.Constants;

    public class FoodAsterisk : Food
    {
        public FoodAsterisk(Coordinate foodCoordinates) 
            : base(GameConstants.Food.ASTERICS_SYMBOL, GameConstants.Food.ASTERICS_POINTS, foodCoordinates)
        {
        }
    }
}