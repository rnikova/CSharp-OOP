using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int InitialBulletsPerBarrel = 10;
        private const int InitialTotalBullets = 100;
        private const int InitialShoots = 1;

        public Pistol(string name) 
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
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
