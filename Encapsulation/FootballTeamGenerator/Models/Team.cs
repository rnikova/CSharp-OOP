namespace FootballTeamGenerator.Models
{
    using FootballTeamGenerator.Exeption;
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExeptionMessages.EmptyNameExeption);
                }

                this.name = value;
            }
        }

        public int Rating => (int)Math.Round(this.players.Average(x => x.OverallSkill), 0);

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }
        public void RemovePlayer(string name)
        {
            Player playerToRemove = this.players.FirstOrDefault(x => x.Name == name);

            if (playerToRemove == null)
            {
                throw new ArgumentException(string.Format(ExeptionMessages.MissingPlayerExeption, name, this.Name));
            }

            this.players.Remove(playerToRemove);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
