using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private const double CUBIC_CENTIMETERS = 450.0;
        private const int MIN_HORSE_POWER = 70;
        private const int MAX_HORSHE_POWER = 100;

        public PowerMotorcycle(string model, int horsePower) 
            : base(model, horsePower, CUBIC_CENTIMETERS)
        {
        }

        public override int HorsePower
        {
            get => base.HorsePower;
            protected set
            {
                if (value < MIN_HORSE_POWER || value > MAX_HORSHE_POWER)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                base.HorsePower = value;
            }
        }
    }
}
