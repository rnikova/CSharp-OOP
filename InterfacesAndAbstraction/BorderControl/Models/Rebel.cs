namespace BorderControl.Models
{
    using BorderControl.Contracts;

    public class Rebel : Citizen, IRebel
    {
        public Rebel(string name, int age, string group)
            : base(name, age)
        {
            this.Group = group;
        }

        public string Group { get; private set; }

        public override int BuyFood()
        {
            return base.Food += 5;
        }
    }
}
