namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private double defaultConsumption = 3.0;

        public Car(int horsePower, double fuel) 
            : base(horsePower, fuel)
        {
            base.DefaultFuelConsumption = this.FuelConsumption;
        }

        protected override double FuelConsumption { get => defaultConsumption; set => defaultConsumption = value; }
    }
}
