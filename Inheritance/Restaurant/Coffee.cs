namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public Coffee(string name, decimal price, double milliliters, double caffeine) 
            : base(name, price, milliliters)
        {
            this.Milliliters = 50.0;
            this.Price = 3.50m;
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
