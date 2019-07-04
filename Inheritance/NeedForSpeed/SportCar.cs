﻿namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private const double defaultConsumption = 10.0;

        public SportCar(int horsePower, double fuel) 
            : base(horsePower, fuel)
        {
            base.FuelConsumption = defaultConsumption;
        }
    }
}
