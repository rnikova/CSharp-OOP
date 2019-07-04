namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double defaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            this.FuelConsumption = defaultFuelConsumption;
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        protected virtual double FuelConsumption { get; set; }

        public double Fuel { get; set; }

        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            var consumption = this.FuelConsumption * kilometers;

            if (consumption <= this.Fuel)
            {
                this.Fuel -= consumption;
            }
        }
    }
}
