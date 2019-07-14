using System;
using System.Collections.Generic;
using System.Linq;
using Vehicles.Models;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            List<Vehicle> vehicles = new List<Vehicle>();

            for (int i = 1; i <= 3; i++)
            {
                string[] vehicleArgs = Console.ReadLine().Split();

                double fuelQuantity = double.Parse(vehicleArgs[1]);
                double fuelConsumtion = double.Parse(vehicleArgs[2]);
                int tanckCapacity = int.Parse(vehicleArgs[3]);

                Vehicle vehicle = null;

                if (i == 1)
                {
                    vehicle = new Car(fuelQuantity, fuelConsumtion, tanckCapacity);
                }
                else if (i == 2)
                {
                    vehicle = new Truck(fuelQuantity, fuelConsumtion, tanckCapacity);
                }
                else if (i == 3)
                {
                    vehicle = new Bus(fuelQuantity, fuelConsumtion, tanckCapacity);
                }

                vehicles.Add(vehicle);
            }

            int commandCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandCount; i++)
            {
                string[] commandArgs = Console.ReadLine().Split();

                string command = commandArgs[0];
                string type = commandArgs[1];

                if (command == "Drive")
                {
                    double distance = double.Parse(commandArgs[2]);

                    Vehicle vehicle = vehicles.FirstOrDefault(x => x.GetType().Name == type);

                    Console.WriteLine(vehicle.Drive(distance));
                }
                else if (command == "Refuel")
                {
                    double fuelAmount = double.Parse(commandArgs[2]);
                    Vehicle vehicle = vehicles.FirstOrDefault(x => x.GetType().Name == type);

                    try
                    {
                        vehicle.Refuel(fuelAmount);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    double distance = double.Parse(commandArgs[2]);

                    Bus vehicle = (Bus)vehicles.FirstOrDefault(x => x.GetType().Name == type);

                    Console.WriteLine(vehicle.DriveEmpty(distance));
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, vehicles));
        }
    }
}
