using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int InitialBulletsPerBarrel = 50;
        private const int InitialTotalBullets = 500;
        private const int InitialShoots = 5;

        public Rifle(string name)
            : base(name, InitialTotalBullets, InitialTotalBullets)
        {
        }

        public override int Fire()
        {
            this.BulletsPerBarrel -= InitialShoots;

            if (this.BulletsPerBarrel <= 0)
            {
                if (this.TotalBullets - InitialBulletsPerBarrel > 0)
                {
                    this.TotalBullets -= InitialBulletsPerBarrel;
                    this.BulletsPerBarrel = InitialBulletsPerBarrel;
                }
            }

            return InitialShoots;
        }
    }
}
