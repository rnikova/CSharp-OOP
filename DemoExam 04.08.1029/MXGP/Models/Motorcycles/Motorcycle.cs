using MXGP.Models.Motorcycles.Contracts;
using MXGP.Utilities.Messages;
using System;

namespace MXGP.Models.Motorcycles
{
    public abstract class Motorcycle : IMotorcycle
    {
        private const int MIN_LENGTH = 4;

        private string model;

        protected Motorcycle(string model, int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MIN_LENGTH)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, MIN_LENGTH));
                }

                this.model = value;
            }
        }

        public virtual int HorsePower { get; protected set; }

        public  double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            double result = this.CubicCentimeters / this.HorsePower * laps;
            return result;
        }
    }
}
