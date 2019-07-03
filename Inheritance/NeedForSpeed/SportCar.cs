namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private double defaultConsumption = 10.0;

        public SportCar(int horsePower, double fuel) 
            : base(horsePower, fuel)
        {
            base.DefaultFuelConsumption = this.FuelConsumption;
        }
        protected override double FuelConsumption { get => defaultConsumption; set => defaultConsumption = value; }
    }
}
