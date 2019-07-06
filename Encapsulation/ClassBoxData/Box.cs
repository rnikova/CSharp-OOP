using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;
            private set
            {
                ValidateParameters(value, "Length");

                this.length = value;
            }
        }

        public double Width
        {
            get => this.width;
            private set
            {
                ValidateParameters(value, "Width");

                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;
            private set
            {
                ValidateParameters(value, "Height");

                this.height = value;
            }
        }

        private void ValidateParameters(double parameter, string parameterName)
        {
            if (parameter <= 0)
            {
                throw new Exception($"{parameterName} cannot be zero or negative.");
            }
        }

        private double SurfaceArea()
        {
            double surfaceArea = 
                2 * (this.Length * this.Width) 
                + LateralSurfaceArea();

            return surfaceArea;
        }

        private double LateralSurfaceArea()
        {
            double lateralSurfaceArea = 
                2 * (this.Length * this.Height)
                + 2 * (this.Width * this.Height);

            return lateralSurfaceArea;
        }

        private double Volume()
        {
            double volume = this.Length * this.Width * this.Height;

            return volume;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Surface Area - {SurfaceArea():F2}");
            result.AppendLine($"Lateral Surface Area - {LateralSurfaceArea():f2}");
            result.AppendLine($"Volume - {Volume():f2}");

            return result.ToString().TrimEnd();
        }
    }
}
