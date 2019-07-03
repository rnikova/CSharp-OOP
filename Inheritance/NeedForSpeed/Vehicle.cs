namespace NeedForSpeed
{
    public class Vehicle
    {
        private double defaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            this.DefaultFuelConsumption = FuelConsumption;
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        protected double DefaultFuelConsumption
        {
            get => defaultFuelConsumption;
            set
            {
                defaultFuelConsumption = value;
            }
        }

        protected virtual double FuelConsumption { get; set; }

        public double Fuel { get; set; }

        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= this.FuelConsumption * kilometers;
        }
    }
}
