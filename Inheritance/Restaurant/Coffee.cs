namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public Coffee(string name, decimal price, double milliliters, double caffeine) 
            : base(name, price, milliliters)
        {
            this.CoffeeMilliliters = 50.0;
            this.CoffeePrice = 3.5m;
            this.Caffeine = caffeine;
        }

        public double CoffeeMilliliters { get; set; }

        public decimal CoffeePrice { get; set; }

        public double Caffeine { get; set; }
    }
}
