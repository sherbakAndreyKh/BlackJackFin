using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.Participant;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.DataAccessLayer.Context;

namespace BlackJack.DataAccessLayer.Repositories
{
    public class DealerRepository : BaseRepository<Dealer>, IDealerRepository, IDisposable
    {
        // Fields
        private bool disposedValue = false;

        // Constructors
        public DealerRepository()
        {
        }

        public DealerRepository(BlackJackContext db) : base(db)
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
