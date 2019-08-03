using System;
using System.Text;
using MortalEngines.Common;
using System.Collections.Generic;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities.Models.Mashines
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;

        public BaseMachine(string name, double attackPoints, double defencePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defencePoints;
            this.HealthPoints = healthPoints;

            this.Targets = new List<string>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NullMachineName);
                }

                this.name = value;
            }

        }

        public IPilot Pilot
        {
            get => this.pilot;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.NullPilot);
                }

                this.pilot = value;
            }
        }
        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; private set; }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.NullTarget);
            }

            var pointsToDecrease = Math.Abs(this.AttackPoints - target.DefensePoints);

            if (target.HealthPoints - pointsToDecrease < 0)
            {
                target.HealthPoints = 0;
            }
            else
            {
                target.HealthPoints -= pointsToDecrease;
            }

            this.Targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($" - {this.Name}")
                .AppendLine($" *Type: {this.GetType().Name}")
                .AppendLine($" *Health: {this.HealthPoints:F2}")
                .AppendLine($" *Attack: {this.AttackPoints:f2}")
                .AppendLine($" *Defense: {this.DefensePoints:f2}");

            if (this.Targets.Count == 0)
            {
                result.AppendLine(" *Targets: None");
            }
            else
            {
                result.AppendLine($" * Targets: {string.Join(",", this.Targets)}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
