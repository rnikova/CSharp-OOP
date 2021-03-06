﻿using System.Collections.Generic;
using System.Linq;
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
            while (true)
            {
                IGun gun = mainPlayer.GunRepository.Models.FirstOrDefault(g => g.CanFire == true);
                IPlayer target = civilPlayers.FirstOrDefault(t => t.IsAlive == true);

                if (gun == null || target == null)
                {
                    break;
                }

                int damagePoints = gun.Fire();
                target.TakeLifePoints(damagePoints);
            }

            while (true)
            {
                IPlayer player = civilPlayers.FirstOrDefault(t => t.IsAlive == true);
                IGun gun = player.GunRepository.Models.FirstOrDefault(g => g.CanFire == true);

                if (player == null || gun == null)
                {
                    break;
                }

                int damagePoints = gun.Fire();
                mainPlayer.TakeLifePoints(damagePoints);

                if (mainPlayer.IsAlive == false)
                {
                    break;
                }
            }
        }
    }
}

