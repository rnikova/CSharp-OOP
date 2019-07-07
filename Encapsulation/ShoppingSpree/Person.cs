using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.Bag = new List<string>();
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

        public List<string> Bag { get; set; }

        public string BuyProduct(Product currentProduct)
        {
            if (this.Money >= currentProduct.Price)
            {
                this.Bag.Add(currentProduct.Name);
                this.Money -= currentProduct.Price;

                return $"{this.Name} bought {currentProduct.Name}";
            }

            return $"{this.Name} can't afford {currentProduct.Name}";
        }
    }
}
