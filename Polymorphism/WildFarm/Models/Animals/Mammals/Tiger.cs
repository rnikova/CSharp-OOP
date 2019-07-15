using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight,string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override List<Type> PrefferedFoods => new List<Type> { typeof(Meat)};

        protected override double WeightMultiplier => 1.0;

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
