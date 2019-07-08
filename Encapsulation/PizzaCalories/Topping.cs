using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const double toppingCalories = 2.0;
        private Dictionary<string, double> toppings;
        private double weight;
        private string type;

        public Topping(string type, double weight)
        {
            this.toppings = new Dictionary<string, double>();
            AddModifiers();
            this.Type = type;
            this.Weight = weight;
        }

        public double Weight
        {
            get => this.weight;
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new Exception($"{this.Type} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public string Type
        {
            get => this.type;
            set
            {
                if (!toppings.ContainsKey(value.ToLower()))
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }

        private void AddModifiers()
        {
            this.toppings.Add("meat", 1.2);
            this.toppings.Add("veggies", 0.8);
            this.toppings.Add("cheese", 1.1);
            this.toppings.Add("sauce", 0.9);
        }

        public double GetTotalCalories()
        {
            return toppingCalories * this.Weight * this.toppings[this.type.ToLower()];
        }
    }
}
