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
    public abstract class BaseRepository<T>: IBaseRepository<T> where T :class
        {
        protected BlackJackContext db;

        public BaseRepository(BlackJackContext db)
        {
            this.db = db;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return db.Set<T>();
        }

        public virtual T Get(int id)
        {
            return db.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> Find(Func<T, Boolean> predicate)
        {
            return db.Set<T>().Where(predicate);
        }

        public virtual void Create(T item)
        {
            db.Set<T>().Add(item);
        }

        public virtual void Update(T item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public virtual void Delete(int id)
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
    }
}
