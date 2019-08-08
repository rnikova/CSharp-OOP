namespace PlayersAndMonsters.Models.Cards
{
    using System;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Cards.Contracts;

    public abstract class Card : ICard
    {
        private string name;
        private int damagePoints;
        private int healthPoints;

        protected Card(string name, int damagePoints, int healthPoints)
        {
            this.Name = name;
            this.DamagePoints = damagePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get=> this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.NullOrEmtpyCardName);
                }

                this.name = value;
            }
        }

        public int DamagePoints
        {
            get => this.damagePoints;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CardsDamagePointsLessThanZero);
                }

                this.damagePoints = value;
            }
        }

        public int HealthPoints
        {
            get => this.healthPoints;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.HealthPointsLessThanZero);
                }

                this.healthPoints = value;
            }
        }

        public override string ToString()
        {
            return $"Card: {this.Name} - Damage: {this.DamagePoints}";
        }
    }
}
