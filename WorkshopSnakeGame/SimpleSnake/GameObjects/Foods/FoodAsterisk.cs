namespace SimpleSnake.GameObjects.Foods
{
    public class FoodAsterisk : Food
    {
        private const string FOOD_SYMBOL = "*";
        private const int FOOD_POINTS = 1;

        public FoodAsterisk(string foodSymbol, int foodPoints, Coordinate foodCoordinates) 
            : base(foodSymbol, foodPoints, foodCoordinates)
        {
        }
    }
}
