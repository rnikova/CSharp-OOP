using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Engine
    {
        private List<Person> people;
        private List<Product> products;

        public Engine()
        {
            people = new List<Person>();
            products = new List<Product>();
        }

        public void Run()
        {
            try
            {
                string[] personsParameters = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                string[] productsParameters = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                AddPerson(personsParameters);
                AddProduct(productsParameters);

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                try
                {
                    string[] currentPurchase = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string personName = currentPurchase[0];
                    string productName = currentPurchase[1];

                    Person person = people.FirstOrDefault(x => x.Name == personName);
                    Product product = products.FirstOrDefault(x => x.Name == productName);

                    if (person != null && product != null)
                    {
                        person.BuyProduct(product);
                        Console.WriteLine($"{person.Name} bought {product.Name}");
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, people));
        }

        private void AddPerson(string[] personParameters)
        {
            foreach (var parameter in personParameters)
            {
                string[] currentPerson = parameter.Split("=");
                string currentPersonName = currentPerson[0];
                decimal currentPersonMoney = decimal.Parse(currentPerson[1]);

                Person person = new Person(currentPersonName, currentPersonMoney);
                people.Add(person);
            }
        }

        private void AddProduct(string[] productParameters)
        {
            foreach (var parameter in productParameters)
            {
                string[] currentProduct = parameter.Split("=");
                string currentProductName = currentProduct[0];
                decimal currentProductMoney = decimal.Parse(currentProduct[1]);

                Product product = new Product(currentProductName, currentProductMoney);
                products.Add(product);
            }
        }
    }
}
