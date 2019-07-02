namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double defaultConsumption = 8.0;

        public RaceMotorcycle( double fuelConsumption, double fuel, int horsePower) 
            : base(fuelConsumption, fuel, horsePower)
        {
            this.DefaultFuelConsumption = defaultConsumption;
        }
    }
}
