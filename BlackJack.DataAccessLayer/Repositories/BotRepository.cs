using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.Participant;
using BlackJack.DataAccessLayer.Context;
using BlackJack.DataAccessLayer.Interfaces;

namespace BlackJack.DataAccessLayer.Repositories
{
    public class BotRepository : BaseRepository<Bot>, IBotRepository, IDisposable
    {
        // Fields
        private bool disposedValue = false;

        // Constructors
        public BotRepository()
        {
        }

        public BotRepository(BlackJackContext db) : base(db)
        {
        }

        // Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
           
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
