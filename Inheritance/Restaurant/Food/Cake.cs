namespace Restaurant.Food
{
    public class Cake : Dessert
    {
        private const double cakeGrams = 250;

        private const double cakeCalories = 1000;

        private const decimal cakePrice = 5.0m;

        public Cake(string name) 
            : base(name, cakePrice, cakeGrams, cakeCalories)
        {
        }
    }
}
