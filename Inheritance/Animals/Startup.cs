namespace Animals
{
    using global::Animals.Animals;
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        static List<Animal> animals = new List<Animal>();

        public static void Main(string[] args)
        {
            string input = Console.ReadLine();


            while (input != "Beast!")
            {
                try
                {
                    string type = input;
                    string[] data = Console.ReadLine().Split();

                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string gender = data[2];

                    switch (type)
                    {
                        case "Dog":
                            animals.Add(new Dog(name, age, gender));
                            break;
                        case "Cat":
                            animals.Add(new Cat(name, age, gender));
                            break;
                        case "Frog":
                            animals.Add(new Frog(name, age, gender));
                            break;
                        case "Tomcat":
                            animals.Add(new Tomcat(name, age));
                            break;
                        case "Kitten":
                            animals.Add(new Kitten(name, age));
                            break;
                        default:
                            throw new Exception("Invalid input!");
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }

            Print();
        }

        private static void Print()
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine(animal);
                animal.ProduceSound();
            }
        }
    }
}