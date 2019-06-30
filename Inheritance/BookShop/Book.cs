namespace BookShop
{
    using System;
    using System.Text;

    public class Book
    {
        private string title;

        private string author;

        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public string Title
        {
            get => this.title;
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }

                this.title = value;
            }
        }

        public string Author
        {
            get => this.author;
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (char.IsDigit(value[i]) && char.IsWhiteSpace(value[i - 1]))
                    {
                        throw new ArgumentException("Author not valid!");
                    }
                }

                this.author = value;
            }
        }

        public virtual decimal Price
        {
            get => this.price;
            set
            {
                if (value < 1.0m)
                {
                    throw new ArgumentException("Price not valid!");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            var resultBuilder = new StringBuilder();

            resultBuilder
                .AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Title: {this.Title}")
                .AppendLine($"Author: {this.Author}")
                .AppendLine($"Price: {this.Price:f2}");

            string result = resultBuilder.ToString().TrimEnd();

            return result;
        }
    }
}
