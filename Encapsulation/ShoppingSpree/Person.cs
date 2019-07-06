using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Person> people;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.Bag = new List<Product>();
            this.people = new List<Person>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ValidateName(value);

                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;
            private set
            {
                Validator.ValidateMoney(value);

                this.money = value;
            }
        }

        private List<Product> Bag { get; set; }
    }
}
