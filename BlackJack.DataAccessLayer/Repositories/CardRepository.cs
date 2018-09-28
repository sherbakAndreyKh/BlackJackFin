﻿using BlackJack.DataAccessLayer.Context;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.Entities;

namespace BlackJack.DataAccessLayer.Repositories
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(BlackJackContext db) : base(db)
        {
        }

        public Card FindCardWithNameAndSuit(string name, string suit)
        {
            throw new System.NotImplementedException();
        }
    }
}
