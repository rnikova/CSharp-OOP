using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private MainPlayer mainPlayer;
        private readonly List<IPlayer> civilPlayers;
        private readonly List<IGun> guns;
        private int civilPlayersCOunt = 0;

        public Controller()
        {
            this.mainPlayer = new MainPlayer();
            this.civilPlayers = new List<IPlayer>();
            this.guns = new List<IGun>();
        }

        public string AddGun(string type, string name)
        {
            if (type == "Pistol")
            {
                Pistol pistol = new Pistol(name);
                this.guns.Add(pistol);
            }
            else if (type == "Rifle")
            {
                Rifle rifle = new Rifle(name);
                this.guns.Add(rifle);
            }
            else
            {
                return string.Format(OutputMessages.InvalidGun);
            }

            return string.Format(OutputMessages.AddGun, name, type);
        }

        public string AddGunToPlayer(string name)
        {
            var n = this.guns.Count;

            var player = this.civilPlayers.FirstOrDefault(p => p.Name == name);

            if (n == 0)
            {
                return string.Format(OutputMessages.NoGun);
            }
            else
            {
                var gunToPlayer = this.guns.First();

                if (name == "Vercetti")
                {
                    //if (this.mainPlayer.GunRepository.Models.Contains(gunToPlayer))
                    //{
                    //    int index = this.guns.IndexOf(gunToPlayer);
                    //    gunToPlayer = this.guns.Skip(index).First();
                    //}

                    //if (gunToPlayer != null)

                    this.mainPlayer.GunRepository.Add(gunToPlayer);
                    this.guns.RemoveAt(0);

                    return string.Format(OutputMessages.MainPLayerAddGun, gunToPlayer.Name);


                }
                else if (player == null)
                {
                    return string.Format(OutputMessages.CivilPlayerDoesntExist);
                }

                player.GunRepository.Add(gunToPlayer);
                this.guns.RemoveAt(0);
                return string.Format(OutputMessages.CivilPlayerAddGun, gunToPlayer.Name, name);
            }
            
        }

        public string AddPlayer(string name)
        {
            CivilPlayer civilPlayer = new CivilPlayer(name);
            this.civilPlayers.Add(civilPlayer);
            this.civilPlayersCOunt++;

            return string.Format(OutputMessages.AddPlayer, name);
        }

        public string Fight()
        {
            var civilsAllPoints = this.civilPlayers.Sum(c => c.LifePoints);

            GangNeighbourhood gangNeighbourhood = new GangNeighbourhood();
            gangNeighbourhood.Action(mainPlayer, this.civilPlayers);


            if (civilsAllPoints != this.civilPlayers.Sum(c => c.LifePoints))
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("A fight happened:")
                    .AppendLine($"Tommy live points: {this.mainPlayer.LifePoints}!")
                    .AppendLine($"Tommy has killed: {this.civilPlayersCOunt - this.civilPlayers.Count} players!")
                    .AppendLine($"Left Civil Players: {this.civilPlayers.Count}!");

                return sb.ToString().TrimEnd();
            }

            return $"Everything is okay!";
        }

        //public void Exit()
        //{
        //    Environment.Exit(0);
        //}
    }
}
