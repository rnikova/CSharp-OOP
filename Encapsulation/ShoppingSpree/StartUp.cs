using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static List<Person> people = new List<Person>();
        static List<Product> products = new List<Product>();

        public static void Main(string[] args)
        {
            try
            {
                string[] personsParameters = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                string[] productsParameters = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                AddPerson(personsParameters);
                AddProduct(productsParameters);

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] currentPurchase = command.Split();
                    string name = currentPurchase[0];
                    string product = currentPurchase[1];

                    BuyProduct(name, product);

                    command = Console.ReadLine();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach (var person in people)
            {
                if (person.Bag.Count > 0)
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.Bag)}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }

        private static void BuyProduct(string name, string product)
        {
            Person currentPerson = people.FirstOrDefault(x => x.Name == name);
            Product currentProduct = products.FirstOrDefault(x => x.Name == product);

            string buyProduct = currentPerson.BuyProduct(currentProduct);

            Console.WriteLine(buyProduct);
        }

        private static void AddPerson(string[] personParameters)
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

        private static void AddProduct(string[] productParameters)
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
