using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.DAL.Interfaces;
using BlackJack.Entities.Participant;
using BlackJack.DAL.Context;

namespace BlackJack.DAL.Repositories
{
    public class BotRepository : IBotRepository, IDisposable
    {
        private BJContext db;

        public BotRepository(BJContext context)
        {
            db = context;
        }


        public Bot Get(int id)
        {
            return db.Bots.Find(id);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

       
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                
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
