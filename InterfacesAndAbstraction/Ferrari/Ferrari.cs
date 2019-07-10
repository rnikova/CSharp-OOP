namespace Ferrari
{
    public class Ferrari : IFerrari
    {
        private const string MODEL = "488-Spider";
        private const string BRAKES = "Brakes!";
        private const string GAS = "Gas!";

        private string name;

        public Ferrari(string name)
        {
            this.Driver = name;
        }

        public string Model => MODEL;

        public string Brakes => BRAKES;

        public string Gas => GAS;

        public string Driver
        {
            get => name;
            private set
            {
                this.name = value;
            }
        }

        public override string ToString()
        {
            return $"488-Spider/Brakes!/Gas!/{this.Driver}";
        }
    }
}
