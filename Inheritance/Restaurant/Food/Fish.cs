namespace Restaurant.Food
{
    public class Fish : MainDish
    {
        private const double fishGrams = 22.0;

        public Fish(string name, decimal price) 
            : base(name, price, fishGrams)
        {
        }
    }
}
