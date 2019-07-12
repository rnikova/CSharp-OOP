namespace BorderControl.Models
{
    using BorderControl.Contracts;
    using System;
    using System.Globalization;

    public class Citizen : IBuyer
    {
        public Citizen(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.Food = 0;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }

        public int Food { get; protected set; }

        public virtual int BuyFood()
        {
            return this.Food;
        }
    }
}
