namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double AIR_CONDITION_CONSUMPTION = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity) 
            : base(fuelQuantity, fuelConsumption + AIR_CONDITION_CONSUMPTION, tankCapacity)
        {
        }

        public string DriveEmpty(double distance)
        {
            this.FuelConsumption -= AIR_CONDITION_CONSUMPTION;
            return base.Drive(distance);
        }
    }
}
