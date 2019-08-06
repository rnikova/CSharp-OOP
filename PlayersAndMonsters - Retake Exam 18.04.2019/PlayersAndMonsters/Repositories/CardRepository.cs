namespace PlayersAndMonsters.Repositories
{
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CardRepository : ICardRepository
    {
        private readonly List<ICard> cards;

        public int Count => this.Cards.Count;

        public IReadOnlyCollection<ICard> Cards => this.cards.AsReadOnly();

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException(ExceptionMessages.NullCard);
            }

            if (this.Cards.Any(x => x.Name == card.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistCard, card.Name));
            }

            this.cards.Add(card);
        }

        public ICard Find(string name)
        {
            ICard findedPlayer = this.cards.FirstOrDefault(p => p.Name == name);

            return findedPlayer;
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException(ExceptionMessages.NullCard);
            }

            return this.cards.Remove(card);
        }
    }
}
