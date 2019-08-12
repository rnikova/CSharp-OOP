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
            if (this.BulletsPerBarrel - InitialShoots <= 0 && this.TotalBullets > 0)
            {
                this.BulletsPerBarrel--;
                this.BulletsPerBarrel = InitialBulletsPerBarrel;
                this.TotalBullets -= InitialBulletsPerBarrel;
            }

            if (this.CanFire == true)
            {
                this.BulletsPerBarrel--;
            }

            return InitialShoots;
        }
    }
}
