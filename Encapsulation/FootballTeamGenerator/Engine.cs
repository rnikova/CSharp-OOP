namespace FootballTeamGenerator
{
    using FootballTeamGenerator.Exeption;
    using FootballTeamGenerator.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private List<Team> teams;

        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                try
                {
                    string[] commandTokens = command.Split(";");

                    string commandType = commandTokens[0];
                    string teamName = commandTokens[1];

                    if (commandType == "Team")
                    {
                        Team team = new Team(teamName);
                        this.teams.Add(team);
                    }
                    else if (commandType == "Add")
                    {
                        string playerName = commandTokens[2];
                        int endurance = int.Parse(commandTokens[3]);
                        int sprint = int.Parse(commandTokens[4]);
                        int dribble = int.Parse(commandTokens[5]);
                        int passing = int.Parse(commandTokens[6]);
                        int shooting = int.Parse(commandTokens[7]);

                        ValidateTeamName(teamName);

                        Stat stat = new Stat(endurance, sprint, dribble, passing, shooting);
                        Player player = new Player(playerName, stat);
                        Team team = this.teams.First(x => x.Name == teamName);
                        team.AddPlayer(player);

                    }
                    else if (commandType == "Remove")
                    {
                        ValidateTeamName(teamName);

                        string playerName = commandTokens[2];
                        Team team = this.teams.First(x => x.Name == teamName);

                        team.RemovePlayer(playerName);
                    }
                    else if (commandType == "Rating")
                    {
                        ValidateTeamName(teamName);

                        Team team = this.teams.First(x => x.Name == teamName);

                        Console.WriteLine(team.ToString());
                    }
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }

                command = Console.ReadLine();
            }
        }

        private void ValidateTeamName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(string.Format(ExeptionMessages.MissingTeamExeption, name));
            }
        }
    }
}
