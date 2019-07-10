namespace BorderControl
{
    using System;
    using System.Collections.Generic;

    public class Citizen : IPerson, IRobot
    {
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public Citizen(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }

        public string Name { get; private set; }

        public string Id { get; private set; }

        public int Age { get; private set; }

        public override string ToString()
        {
            return $"{this.Id}";
        }
    }
}
