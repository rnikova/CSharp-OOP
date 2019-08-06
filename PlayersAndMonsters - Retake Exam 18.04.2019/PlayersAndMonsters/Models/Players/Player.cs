namespace PlayersAndMonsters.Models.Players
{
    using System;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Repositories.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;

    public abstract class Player : IPlayer
    {
        private string username;
        private int health;

        protected Player(ICardRepository cardRepository, string username, int health)
        {
            this.Username = username;
            this.Health = health;
            this.CardRepository = cardRepository;
        }

        public string Username
        {
            get => this.username;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.NullOrEmtpyPlayerName);
                }

                this.username = value;
            }          
        }

        public int Health
        {
            get =>this.health;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.HealthLessThanZero);
                }

                this.health = value;
            }
        }
        public ICardRepository CardRepository { get; private set; }

        public bool IsDead { get; private set; }

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints <= 0)
            {
                throw new ArgumentException(ExceptionMessages.DamagePointsLessThanZero);
            }

            if (this.Health - damagePoints < 0)
            {
                this.Health = 0;
                this.IsDead = true;
            }
            else
            {
                this.Health -= damagePoints;
            }            
        }
    }
}
