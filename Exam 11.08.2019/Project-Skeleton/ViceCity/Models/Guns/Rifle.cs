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
