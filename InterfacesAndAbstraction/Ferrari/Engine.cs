namespace Ferrari
{
    using System;

    public class Engine
    {
        public Engine()
        {
        }

        public void Run()
        {
            string name = Console.ReadLine();

            var car = new Ferrari(name);

            Console.WriteLine(car);
        }
    }
}
