namespace P02_CarsSalesman
{
    using System.Text;

    public class Engine
    {
        public Engine(string model, int power, string efficiency) : this(model, power, -1, efficiency)
        {
        }

        public Engine(string model, int power) : this(model, power, -1, "n/a")
        {
        }
        public Engine(string model, int power, int displacement) : this(model, power, displacement, "n/a")
        {
        }

        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public string Model { get; set; }

        public int Power { get; set; }

        public int Displacement { get; set; }

        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($" {this.Model}:");
            sb.AppendLine($"    Power: {this.Power}");

            if (this.Displacement == -1)
            {
                sb.AppendLine($"    Displacement: n/a");
            }
            else
            {
                sb.AppendLine($"    Displacement: {this.Displacement}");
            }

            sb.AppendLine($"    Efficiency: {this.Efficiency}");

            return sb.ToString().TrimEnd();
        }
    }
}
