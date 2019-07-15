using System;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            string foodType = food.GetType().Name;

            if (foodType == "Meat" || foodType == "Vegetable")
            {
                this.Weight += food.Quantity * 0.3;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {foodType}!");
            }
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
