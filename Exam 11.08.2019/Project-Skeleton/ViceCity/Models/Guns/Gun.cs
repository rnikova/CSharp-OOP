using System;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletPerBarrel;
        private int totalBullets;

        protected Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            this.Name = name;
            this.BulletsPerBarrel = bulletsPerBarrel;
            this.TotalBullets = totalBullets;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NullGunName);
                }

                this.name = value;
            }
        }

        public int BulletsPerBarrel
        {
            get => this.bulletPerBarrel;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.BulletsBelowZero);
                }

                this.bulletPerBarrel = value;
            }
        }

        public int TotalBullets
        {
            get => this.totalBullets;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.TotalBulletsBelowZero);
                }

                this.totalBullets = value;
            }
        }
        public bool CanFire => this.TotalBullets > 0;

        public virtual int Fire()
        {
            return 0;
        }
    }
}
