using MortalEngines.Entities.Contracts;
using System;
using System.Text;

namespace MortalEngines.Entities.Models.Mashines
{
    public class Tank : BaseMachine, ITank
    {
        private const double InitialHealthPoints = 100.0;
        private const double InitialAttackPoints = 40.0;
        private const double InitialDefensePoints = 30.0;

        public Tank(string name, double attackPoints, double defencePoints) 
            : base(name, attackPoints - InitialAttackPoints, defencePoints + InitialDefensePoints, InitialHealthPoints)
        {
            this.DefenseMode = true;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.DefenseMode = false;
                this.AttackPoints += InitialAttackPoints;
                this.DefensePoints -= InitialDefensePoints;
            }
            else
            {
                this.DefenseMode = true;
                this.AttackPoints -= InitialAttackPoints;
                this.DefensePoints += InitialDefensePoints;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Aggressive: {(this.DefenseMode == true ? "ON" : "OFF")}");

            return sb.ToString().TrimEnd();
        }
    }
}
