namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private double defaultConsumption = 8.0;

        public RaceMotorcycle(int horsePower, double fuel) 
            : base(horsePower, fuel)
        {
            base.DefaultFuelConsumption = this.FuelConsumption;
        }

        protected override double FuelConsumption { get => defaultConsumption; set => defaultConsumption = value; }
    }
}
