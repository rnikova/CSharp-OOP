using MortalEngines.Entities.Contracts;
using System;
using System.Text;

namespace MortalEngines.Entities.Models.Mashines
{
    public class Fighter : BaseMachine, IFighter
    {

        private const double InitialHealthPoints = 200.0;
        private const double InitialAttackPoints = 50.0;
        private const double InitialDefensePoints = 25.0;

        public Fighter(string name, double attackPoints, double defencePoints) 
            : base(name, attackPoints + InitialAttackPoints, defencePoints - InitialDefensePoints, InitialHealthPoints)
        {
            this.AggressiveMode = true;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode)
            {
                this.AggressiveMode = false;
                this.AttackPoints -= InitialAttackPoints;
                this.DefensePoints += InitialDefensePoints;
            }
            else
            {
                this.AggressiveMode = true;
                this.AttackPoints += InitialAttackPoints;
                this.DefensePoints -= InitialDefensePoints;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Aggressive: {(this.AggressiveMode == true ? "ON" : "OFF")}");

            return sb.ToString().TrimEnd();
        }
    }
}
