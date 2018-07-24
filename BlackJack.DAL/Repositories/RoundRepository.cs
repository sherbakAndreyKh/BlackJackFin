using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BlackJack.DAL.Context;
using BlackJack.DAL.Interfaces;
using BlackJack.Entities.History;

namespace BlackJack.DAL.Repositories
{
    public class RoundRepository : IRoundRepository, IDisposable
    {
        private BJContext db;

        public RoundRepository(BJContext context)
        {
            db = context;
        }

        public void Add(Round item)
        {
            db.Rounds.Add(item);
        }

        public void Dispose()
        {
            ((IDisposable)db).Dispose();
        }

        public Round Round(int id)
        {
            return db.Rounds.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
