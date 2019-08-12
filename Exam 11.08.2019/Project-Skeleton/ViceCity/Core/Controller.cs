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

            return string.Format(OutputMessages.AddPlayer, name);
        }

        public string Fight()
        {
            MainPlayer mainPlayer = new MainPlayer();

            GangNeighbourhood gangNeighbourhood = new GangNeighbourhood();
            gangNeighbourhood.Action(mainPlayer, civilPlayers);

            StringBuilder sb = new StringBuilder();

            if (civilPlayers.Any(p => p.IsAlive == true) &&
                mainPlayer.LifePoints == 100)
            {
                sb.AppendLine("Everything is okay!");
            }
            else
            {
                sb.AppendLine("A fight happened:");
                sb.AppendLine($"Tommy live points: {mainPlayer.LifePoints}!");
                sb.AppendLine($"Tommy has killed: {civilPlayers.Where(p => p.IsAlive == false).Count()} players!");
                sb.AppendLine($"Left Civil Players: {civilPlayers.Where(p => p.IsAlive == true).Count()}!");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
