using MortalEngines.Entities.Contracts;
using System;
using System.Text;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double InitialHealthPoints = 200.0;

        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints + 50, defensePoints - 25, InitialHealthPoints)
        {
            this.AggressiveMode = true;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode)
            {
                this.AggressiveMode = false;
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }
            else
            {
                this.AggressiveMode = true;
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());

            if (this.AggressiveMode)
            {
                result.AppendLine(" *Aggressive: ON");
            }
            else
            {
                result.AppendLine(" *Aggressive: OFF");
            }
            return result.ToString().TrimEnd();
        }
    }
}
