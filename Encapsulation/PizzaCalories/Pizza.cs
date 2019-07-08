using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => name;
            set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public int ToppingCount => this.toppings.Count;

        public void AddTopping(Topping topping)
        {
            if (this.ToppingCount == 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }

        public double GetTotalCalories()
        {
            return dough.GetTotalCalories() + this.toppings.Select(x => x.GetTotalCalories()).Sum();
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.GetTotalCalories():F2} Calories.";
        }
    }
}
