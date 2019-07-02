namespace Restaurant
{
    public class Fish : Food
    {
        public Fish(string name, decimal price, double grams, decimal fishGrams) 
            : base(name, price, grams)
        {
            this.FishGrams = 22.0m;
        }

        public decimal FishGrams { get; set; }
    }
}
