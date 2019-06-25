namespace P02_CarsSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class CarSalesman
    {
        private List<Car> cars;
        private List<Engine> engines;

        public CarSalesman()
        {
            this.cars = new List<Car>();
            this.engines = new List<Engine>();
        }

        public void AddEngine(string[] parameters)
        {
            string model = parameters[0];
            int power = int.Parse(parameters[1]);

            int displacement = -1;
            string efficiency = "n/a";

            if (parameters.Length == 3)
            {
                char[] data = parameters[2].ToCharArray();

                if (char.IsDigit(data[0]))
                {
                    displacement = int.Parse(parameters[2]);
                }
                else
                {
                    efficiency = parameters[2];
                }
            }
            else if (parameters.Length == 4)
            {
                displacement = int.Parse(parameters[2]);
                efficiency = parameters[3];
            }

            Engine engine = new Engine(model, power, displacement, efficiency);

            engines.Add(engine);
        }

        public void AddCar(string[] parameters)
        {
            string model = parameters[0];
            string engineModel = parameters[1];
            Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);

            int weight = -1;
            string color = "n/a";

            if (parameters.Length == 3)
            {
                char[] data = parameters[2].ToCharArray();

                if (char.IsDigit(data[0]))
                {
                    weight = int.Parse(parameters[2]);
                }
                else
                {
                    color = parameters[2];
                }
            }
            else if (parameters.Length == 4)
            {
                weight = int.Parse(parameters[2]);
                color = parameters[3];
            }

            Car car = new Car(model, engine, weight, color);
            cars.Add(car);
        }

        public List<Car> GetCars()
        {
            return this.cars;
        }
    }
}
