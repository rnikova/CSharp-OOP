using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    { 
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public string Name { get; private set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        protected abstract List<Type> PrefferedFoods { get; }

        protected abstract double WeightMultiplier { get; }

        public abstract string ProduceSound();

        public void Eat(IFood food)
        {
            if (!this.PrefferedFoods.Contains(food.GetType()))
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.InvalidFoodTypeException, 
                        this.GetType().Name,
                        food.GetType().Name));
            }

            this.Weight += food.Quantity * this.WeightMultiplier;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
