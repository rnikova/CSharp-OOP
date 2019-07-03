namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double defaultConsumption = 3.0;

        public Car( double fuelConsumption, double fuel, int horsePower) 
            : base(fuelConsumption, fuel, horsePower)
        {
            this.DefaultFuelConsumption = defaultConsumption;
        }
    }
}
