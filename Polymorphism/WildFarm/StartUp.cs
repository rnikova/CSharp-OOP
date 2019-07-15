using System;
using System.Collections.Generic;
using WildFarm.Models.Animals;
using WildFarm.Models.Animals.Birds;
using WildFarm.Models.Animals.Mammals;
using WildFarm.Models.Foods;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                try
                {
                    string[] animalArgs = command.Split();

                    Animal animal = AnimalFactory.Create(animalArgs);
                    animals.Add(animal);
                    Console.WriteLine(animal.ProduceSound());

                    string[] foodArgs = Console.ReadLine().Split();
                    Food food = FoodFactory.Create(foodArgs);
                    animal.Eat(food);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }

                command = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
