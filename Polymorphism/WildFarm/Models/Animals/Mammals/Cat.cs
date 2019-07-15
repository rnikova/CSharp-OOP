using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override List<Type> PrefferedFoods => new List<Type> { typeof(Vegetable), typeof(Meat)};

        protected override double WeightMultiplier => 0.3;

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
