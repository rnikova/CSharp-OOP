using System;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaParameters = Console.ReadLine().Split();
                string pizzaName = pizzaParameters[1];

                string[] flourParameters = Console.ReadLine().Split();
                string flourType = flourParameters[1];
                string bakingTechnique = flourParameters[2];
                double doughGrams = double.Parse(flourParameters[3]);

                Dough dough = new Dough(flourType, bakingTechnique, doughGrams);
                Pizza pizza = new Pizza(pizzaName, dough);

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] toppingParameters = command.Split();
                    string toppingType = toppingParameters[1];
                    double toppingWeight = double.Parse(toppingParameters[2]);

                    Topping topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);

                    command = Console.ReadLine();
                }

                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
