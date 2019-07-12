namespace BorderControl
{
    using BorderControl.Models;
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
            List<Citizen> citizens = new List<Citizen>();

            int peopeCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopeCount; i++)
            {
                string[] citizenArguments = Console.ReadLine().Split(" ");
                string name = citizenArguments[0];
                int age = int.Parse(citizenArguments[1]);

                if (citizenArguments.Length == 4)
                {
                    string id = citizenArguments[2];
                    DateTime birthdate = DateTime.ParseExact(citizenArguments[3], "dd/MM/yyyy", null);

                    Person person = new Person(name, age, id, birthdate);

                    citizens.Add(person);
                }
                else if (citizenArguments.Length == 3)
                {
                    string group = citizenArguments[2];

                    Rebel rebel = new Rebel(name, age, group);

                    citizens.Add(rebel);
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                Citizen currentCitizen = citizens.FirstOrDefault(x => x.Name == command);

                if (currentCitizen != null)
                {
                    currentCitizen.BuyFood();
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(citizens.Sum(x=>x.Food));
        }
    }
}
