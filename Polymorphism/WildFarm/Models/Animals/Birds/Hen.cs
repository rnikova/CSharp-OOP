using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Birds
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        protected override List<Type> PrefferedFoods => new List<Type> { typeof(Fruit), typeof(Vegetable), typeof(Meat), typeof(Seeds) };

        protected override double WeightMultiplier => 0.35;

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
