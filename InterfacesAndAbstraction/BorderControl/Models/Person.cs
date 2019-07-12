using BorderControl.Contracts;
using System;

namespace BorderControl.Models
{
    public class Person : Citizen, IPerson
    {
        public Person(string name, int age, string id, DateTime birthdate) 
            : base(name, age)
        {
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Id { get; private set; }

        public DateTime Birthdate { get; private set; }

        public override int BuyFood()
        {
            return base.Food += 10;
        }
    }
}
