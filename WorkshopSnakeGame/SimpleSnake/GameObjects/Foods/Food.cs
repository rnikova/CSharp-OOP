namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food
    {
        protected Food(string foodSymbol, int foodPoints, Coordinate foodCoordinates)
        {
            this.FoodSymbol = foodSymbol;
            this.FoodPoints = foodPoints;
            this.FoodCoordinates = foodCoordinates;
        }

        public string FoodSymbol { get; set; }

        public int FoodPoints { get; set; }

        public Coordinate FoodCoordinates { get; set; }
    }
}
