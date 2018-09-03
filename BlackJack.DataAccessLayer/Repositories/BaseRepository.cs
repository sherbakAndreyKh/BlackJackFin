using BlackJack.DataAccessLayer.Context;
using BlackJack.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BlackJack.DataAccessLayer.Repositories
{
    public class BaseRepository<T>:  IBaseRepository<T>, IDisposable where T :class
        {

        //Fields
        protected BlackJackContext db;

        private bool disposedValue = false;

        //Constructors
        public BaseRepository(BlackJackContext db)
        {
            this.db = db;
        }


        //Methods
        public T Get(int id)
        {
            return db.Set<T>().Find(id);
        }
        
        public IEnumerable<T> GetAll()
        {
            return db.Set<T>();
        }


        public IEnumerable<T> Find(Func<T, Boolean> predicate)
        {
            return db.Set<T>().Where(predicate);
        }

        public void Create(T item)
        {
            db.Set<T>().Add(item);
        }

        public void Update(T item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            T item = db.Set<T>().Find(id);
            if (item != null)
            {
                db.Set<T>().Remove(item);
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }


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
