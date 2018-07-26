using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.DataAccessLayer.Context;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.Entities.Participant;

namespace BlackJack.DataAccessLayer.Repositories
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository, IDisposable
    {
        // Fields
        private bool disposedValue = false;

        // Constructors
        public PlayerRepository()
        {
        }

        public PlayerRepository(BlackJackContext db) : base(db)
        {
        }

        // Methods
        public int CreateAndReturnId(Player item)
        {
            db.Players.Add(item);

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