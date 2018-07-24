using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.DAL.Interfaces;
using BlackJack.DAL.Context;
using BlackJack.Entities.Participant;
using System.Data.Entity;

namespace BlackJack.DAL.Repositories
{
    public class PlayerRepository : IPlayerRepository, IDisposable
    {
        private BJContext db;

        public PlayerRepository(BJContext context)
        {
            db = context;
        }

        public void Create(Player item)
        {
            db.Players.Add(item);
        }

        
        public void Delete(int id)
        {
            Player player = db.Players.Find(id);
            if(player != null)
            {
                db.Players.Remove(player);
            }
        }

        public IEnumerable<Player> Find(Func<Player, bool> predicate)
        {
            return db.Players.Where(predicate);
        }

        public Player Get(int id)
        {
            return db.Players.Find(id);
        }

        public IEnumerable<Player> GetAll()
        {
            return db.Players;
        }

        public void Update(Player item)
        {
            db.Entry(item).State = EntityState.Modified;
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
