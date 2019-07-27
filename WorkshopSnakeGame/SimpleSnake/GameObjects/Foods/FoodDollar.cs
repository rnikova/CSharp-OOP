namespace SimpleSnake.GameObjects.Foods
{
    using SimpleSnake.Constants;

    public class FoodDollar : Food
    {
        public FoodDollar(Coordinate foodCoordinates) 
            : base(GameConstants.Food.DOLAR_SYMBOL, GameConstants.Food.DOLAR_POINTS, foodCoordinates)
        {
        }
    }
}
