using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.DataAccessLayer.Context;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.Entities.History;

namespace BlackJack.DataAccessLayer.Repositories
{
    public class RoundRepository : BaseRepository<Round>, IRoundRepository, IDisposable
    {
        // Fields
        private bool disposedValue = false;

        // Constructors
      
        public RoundRepository(BlackJackContext db) : base(db)
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
