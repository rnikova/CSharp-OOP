using System;

namespace P02_CarsSalesman
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarSalesman carSalesman = new CarSalesman();

            int enginesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < enginesCount; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                carSalesman.AddEngine(parameters);
            }

            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                carSalesman.AddCar(parameters);
            }

            foreach (var car in carSalesman.GetCars())
            {
                Console.WriteLine(car);
            }
        }
    }

}
