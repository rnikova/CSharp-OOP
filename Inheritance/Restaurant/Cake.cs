namespace Restaurant
{
    public class Cake : Dessert
    {
        public Cake(string name, decimal price, double grams, double calories) 
            : base(name, price, grams, calories)
        {
            this.CakeGrams = 250.0;
            this.CakeCalories = 1000.0;
            this.CakePrice = 5.0m;
        }

        public double CakeGrams { get; set; }

        public double CakeCalories { get; set; }

        public decimal CakePrice { get; set; }
    }
}
