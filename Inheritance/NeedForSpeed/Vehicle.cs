namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double defaultConsumption = 1.25;

        public Vehicle(double fuelConsumption, double fuel, int horsePower)
        {
            this.DefaultFuelConsumption = defaultConsumption;
            this.FuelConsumption = fuelConsumption;
            this.Fuel = fuel;
            this.HorsePower = horsePower;
        }

        public double DefaultFuelConsumption { get; set; }

        public virtual double FuelConsumption { get; set; }

        public double Fuel { get; set; }

        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= defaultConsumption * kilometers;
        }
    }
}
