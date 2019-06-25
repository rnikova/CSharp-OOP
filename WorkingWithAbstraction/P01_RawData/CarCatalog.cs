﻿namespace P01_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CarCatalog
    {
        private List<Car> cars;

        public CarCatalog()
        {
            this.cars = new List<Car>();
        }

        public void Add(string[] parameters)
        {
            string model = parameters[0];
            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];

            Engine engine = new Engine(engineSpeed, enginePower);
            Cargo cargo = new Cargo(cargoWeight, cargoType);
            Tire[] tires = new Tire[4];

            int tireIndex = 0;

            for (int t = 5; t <= 12; t += 2)
            {
                double tirePressure = double.Parse(parameters[t]);
                int tireAge = int.Parse(parameters[t + 1]);

                Tire tire = new Tire(tirePressure, tireAge);

                tires[tireIndex] = tire;

                tireIndex++;
            }

            Car car = new Car(model, engine, cargo, tires);
            cars.Add(car);
        }

        public List<Car> GetCars()
        {
            return this.cars;
        }
    }
}
