namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double defaultConsumption = 3.0;

        public Car(int horsePower, double fuel) 
            : base(horsePower, fuel)
        {
            base.FuelConsumption = defaultConsumption;
        }
    }
}
