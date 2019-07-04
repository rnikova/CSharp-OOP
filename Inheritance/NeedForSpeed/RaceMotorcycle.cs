namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double defaultConsumption = 8.0;

        public RaceMotorcycle(int horsePower, double fuel) 
            : base(horsePower, fuel)
        {
            base.FuelConsumption = defaultConsumption;
        }
    }
}
