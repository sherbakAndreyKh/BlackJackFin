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
    public class DealerRepository : IDealerRepository, IDisposable
    {
        private BJContext db;


        public DealerRepository(BJContext context)
        {
            db = context;
        }

        public Dealer Get()
        {
            return db.Dealers.FirstOrDefault();
        }
        
        public void Save()
        {
            db.SaveChanges();
        }
        

        private bool disposedValue = false; 

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.SaveChanges();
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
