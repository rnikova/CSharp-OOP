namespace PlayersAndMonsters.Models.BattleFields
{
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using System;
    using System.Linq;

    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException(ExceptionMessages.DeadPlayer);
            }

            if (attackPlayer.GetType().Name == "Beginner")
            {
                attackPlayer.Health += 40;

                //increase damagePoints of all cards with 30
            }

            if (enemyPlayer.GetType().Name == "Beginner")
            {
                enemyPlayer.Health += 40;

                // increase damagePoints of all cards with 30
            }

            enemyPlayer.TakeDamage(attackPlayer.CardRepository.Cards.Sum(x=>x.DamagePoints));
            attackPlayer.TakeDamage(enemyPlayer.CardRepository.Cards.Sum(x => x.DamagePoints));
        }
    }
}
