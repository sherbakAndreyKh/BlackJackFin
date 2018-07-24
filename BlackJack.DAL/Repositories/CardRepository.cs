using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.DAL.Interfaces;
using BlackJack.Entities;
using BlackJack.DAL.Context;

namespace BlackJack.DAL.Repositories
{
    public class CardRepository : ICardRepository, IDisposable
    {
        private BJContext db;

        public CardRepository(BJContext context)
        {
            db = context;
        }

        public void Dispose()
        {
            ((IDisposable)db).Dispose();
        }

        public IEnumerable<Card> GetAll()
        {
            return db.CardDeck;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
