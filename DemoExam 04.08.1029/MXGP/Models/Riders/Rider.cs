﻿using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Riders.Contracts;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Riders
{
    public class Rider : IRider
    {
        private const int MIN_LENGTH = 5;

        private string name;

        public Rider(string name)
        {
            this.Name = name;
            this.CanParticipate = false;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MIN_LENGTH)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, MIN_LENGTH));
                }

                this.name = value;
            }
        }

        public IMotorcycle Motorcycle { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate { get; private set; }

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle == null)
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.MotorcycleInvalid));
            }

            this.Motorcycle = motorcycle;
            this.CanParticipate = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
