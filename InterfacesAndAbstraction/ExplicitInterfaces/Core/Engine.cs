using ExplicitInterfaces.Contracts;
using ExplicitInterfaces.Models;
using System;
using System.Collections.Generic;

namespace ExplicitInterfaces.Core
{
    public class Engine
    {
        public Engine()
        {
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command.Split();
                string name = commandArgs[0];

                IPerson person = new Citizen(name);
                IResident resident = new Citizen(name);

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
                
                command = Console.ReadLine();
            }
        }
    }
}
