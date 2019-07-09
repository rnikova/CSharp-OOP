using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
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

        public void BuyProduct(Product currentProduct)
        {
            decimal currentMoney = this.Money - currentProduct.Price;

            if (currentMoney < 0)
            {
                throw new InvalidOperationException($"{this.Name} can't afford {currentProduct.Name}");
            }

            this.Money = currentMoney;
            this.bag.Add(currentProduct);
        }

        public override string ToString()
        {
            if (this.bag.Count > 0)
            {
                return $"{this.Name} - {string.Join(", ", this.bag.Select(x=>x.Name))}";
            }

            return $"{this.Name} - Nothing bought";
        }
    }
}
