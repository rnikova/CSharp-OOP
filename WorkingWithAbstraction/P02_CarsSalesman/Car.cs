namespace P02_CarsSalesman
{
    using System.Text;

    public class Car
    {
        public string model;
        public Engine engine;
        public int weight;
        public string color;

        public Car(string model, Engine engine) : this(model, engine, -1, "n/a")
        {
        }

        public Car(string model, Engine engine, int weight) : this(model, engine, weight, "n/a")
        {
        }

        public Car(string model, Engine engine, string color) : this(model, engine, -1, color)
        {
        }

        public Car(string model, Engine engine, int weight, string color)
        {
            this.model = model;
            this.engine = engine;
            this.weight = weight;
            this.color = color;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.model}:");
            sb.AppendLine($" {this.engine}");

            if (this.weight == -1)
            {
                sb.AppendLine($"  Weight: n/a");
            }
            else
            {
                sb.AppendLine($"  Weight: {this.weight}");
            }
            
            sb.AppendLine($"  Color: {this.color}");

            return sb.ToString().TrimEnd();
        }
    }
}
