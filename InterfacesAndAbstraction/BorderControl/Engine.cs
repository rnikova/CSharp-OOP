namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        public Engine()
        {
        }

        public object Enviroment { get; private set; }

        public void Run()
        {
            List<Citizen> citizens = new List<Citizen>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] citizenArguments = command.Split(" ");
                string name = citizenArguments[0];

                if (citizenArguments.Length == 3)
                {
                    int age = int.Parse(citizenArguments[1]);
                    string id = citizenArguments[2];

                    Citizen citizen = new Citizen(name, age, id);
                    citizens.Add(citizen);
                }
                else if (citizenArguments.Length == 2)
                {
                    string id = citizenArguments[1];

                    Citizen citizen = new Citizen(name, id);
                    citizens.Add(citizen);
                }

                command = Console.ReadLine();
            }

            string fakeId = Console.ReadLine();

            Console.WriteLine(string.Join(Environment.NewLine, citizens.Where(x => x.Id.EndsWith(fakeId))));
        }
    }
}
