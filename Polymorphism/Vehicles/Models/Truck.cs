namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double AIR_CONDITION_CONSUMPTION = 1.6;
        private const double WASTED_FUEL = 0.05;

        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity) 
            : base(fuelQuantity, fuelConsumption + AIR_CONDITION_CONSUMPTION, tankCapacity)
        {
        }

        public override void Refuel(double amount)
        {
            base.Refuel(amount);
            this.FuelQuantity -= amount * WASTED_FUEL;
        }
    }
}
