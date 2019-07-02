namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private const double defaultConsumption = 10.0;

        public SportCar(double fuelConsumption, double fuel, int horsePower) 
            : base(fuelConsumption, fuel, horsePower)
        {
            this.DefaultFuelConsumption = defaultConsumption;
        }
    }
}
