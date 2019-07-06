using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] personsParameters = command.Split(";");
                    string[] productsParameters = Console.ReadLine().Split(";");

                    foreach (var parameter in personsParameters)
                    {
                        string[] currentPerson = parameter.Split("=");
                        string currentPersonName = currentPerson[0];
                        decimal currnetPersonMoney = decimal.Parse(currentPerson[1]);

                        Person person = new Person(currentPersonName, currnetPersonMoney);
                    }

                    command = Console.ReadLine();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
