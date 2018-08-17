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
    public class GameRepository : BaseRepository<Game>, IGameRepository, IDisposable
    {
        // Fields
        private bool disposedValue = false;

        // Constructors
      

        public GameRepository(BlackJackContext db) : base(db)
        {
        }

        // Methods
        public int CreateAndReturnId(Game item)
        {
            db.Games.Add(item);

            db.SaveChanges();

            return item.Id;
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
