namespace FootballTeamGenerator.Models
{
    using FootballTeamGenerator.Exeption;
    using System;

    public class Player
    {
        private string name;

        public Player(string name, Stat stat)
        {
            this.Name = name;
            this.Stat = stat;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExeptionMessages.EmptyNameExeption);
                }

                this.name = value;
            }
        }

        public Stat Stat { get; private set; }

        public double OverallSkill => this.Stat.OverallStat;
    }
}
