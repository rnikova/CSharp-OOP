using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {
        public GangNeighbourhood()
        {

        }

        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            //List<IGun> mainPlayerGuns = mainPlayer.GunRepository.Models.ToList();
            IGun currentGun = null;

            var currentCivilPlayers = civilPlayers.ToList();
            var currentCivil = currentCivilPlayers[0];
            IGun civilGun = null;
            //currentCivilPlayers.RemoveAt(0);

            while (civilPlayers.Any() && mainPlayer.GunRepository.Models.Count > 0)
            {
                currentGun = mainPlayer.GunRepository.Models.First();
                // mainPlayerGuns.Remove(currentGun);
                currentCivil.TakeLifePoints(currentGun.Fire());

                if (currentGun.TotalBullets <= 0)
                {
                    mainPlayer.GunRepository.Remove(currentGun);
                    currentGun = mainPlayer.GunRepository.Models.First();
                }

                if (!currentCivil.IsAlive)
                {
                    currentCivilPlayers.RemoveAt(0);
                    currentCivil = currentCivilPlayers[0];
                }

                civilGun = currentCivil.GunRepository.Models.First();

                mainPlayer.TakeLifePoints(civilGun.Fire());

                if (civilGun.TotalBullets <= 0)
                {
                    currentCivil.GunRepository.Remove(civilGun);
                    civilGun = currentCivil.GunRepository.Models.First();
                }

                if (!mainPlayer.IsAlive)
                {
                    break;
                }
            }
        }
    }
}
