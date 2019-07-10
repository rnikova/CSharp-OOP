namespace Telephony
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        public Engine()
        { 
        }

        public void Run()
        {
            List<string> numbers = Console.ReadLine().Split().ToList();
            List<string> addresses = Console.ReadLine().Split().ToList();

            Smartphone smartphone = new Smartphone(numbers, addresses);

            foreach (var number in numbers)
            {
                if (Validator.ValidateNumber(number))
                {
                    Console.WriteLine("Invalid number!");
                }
                else
                {
                    Console.WriteLine($"Calling... {number}");
                }
            }

            foreach (var address in addresses)
            {
                if (Validator.ValidateAddress(address))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    Console.WriteLine($"Browsing: {address}!");
                }
            }
        }
    }
}