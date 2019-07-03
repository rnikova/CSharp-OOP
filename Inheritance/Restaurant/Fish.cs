namespace Restaurant
{
    public class Fish : Food
    {
        public Fish(string name, decimal price, double grams) 
            : base(name, price, grams)
        {
            this.Grams = 22.0;
        }
    }
}
