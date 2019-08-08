namespace PlayersAndMonsters.Core
{
    using System;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.Cards;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;

    public class ManagerController : IManagerController
    {
        private string result = string.Empty;
        private PlayerRepository playerRepository;
        private CardRepository cardRepository;

        public ManagerController()
        {
            playerRepository = new PlayerRepository();
            cardRepository = new CardRepository();
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player;

            if (type == "Beginner")
            {
                player = new Beginner(new CardRepository(), username);
                playerRepository.Add(player);
            }
            else if (type == "Advanced")
            {
                player = new Advanced(new CardRepository(), username);
                playerRepository.Add(player);
            }

            return result = string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            ICard card;

            if (type == "Magic")
            {
                card = new MagicCard(name);
                cardRepository.Add(card);
            }
            else if (type == "Trap")
            {
                card = new TrapCard(name);
                cardRepository.Add(card);
            }

            return result = string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = playerRepository.Find(username);
            ICard card = cardRepository.Find(cardName);
            player.CardRepository.Add(card);

            return result = string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attacker = playerRepository.Find(attackUser);
            IPlayer enemy = playerRepository.Find(enemyUser);

            BattleField battleField = new BattleField();
            battleField.Fight(attacker, enemy);

            return result = string.Format(ConstantMessages.FightInfo, attacker.Health, enemy.Health);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in playerRepository.Players)
            {
                sb.AppendLine(player.ToString());

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(card.ToString());
                }

                sb.AppendLine("###");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
