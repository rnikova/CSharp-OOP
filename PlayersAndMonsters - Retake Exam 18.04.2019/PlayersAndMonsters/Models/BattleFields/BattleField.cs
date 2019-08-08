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

                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }

            if (enemyPlayer.GetType().Name == "Beginner")
            {
                enemyPlayer.Health += 40;

                foreach (var card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }

            var attackerBonusHealth = attackPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);
            attackPlayer.Health += attackerBonusHealth;

            var enemyBonusHealth = enemyPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);
            enemyPlayer.Health += enemyBonusHealth;

            var attackerDamage = attackPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);
            var enemyDamage = enemyPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);

            while (true)
            {
                enemyPlayer.TakeDamage(attackerDamage);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyDamage);

                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }
    }
}
