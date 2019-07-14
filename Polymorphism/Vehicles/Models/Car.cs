namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double AIR_CONDITION_CONSUMPTION = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, int tankCapacity) 
            : base(fuelQuantity, fuelConsumption + AIR_CONDITION_CONSUMPTION, tankCapacity)
        {
        }
    }
}
