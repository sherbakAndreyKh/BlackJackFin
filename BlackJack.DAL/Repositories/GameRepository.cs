using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.DAL.Interfaces;
using BlackJack.DAL.Context;
using BlackJack.Entities.History;
using System.Data.Entity;

namespace BlackJack.DAL.Repositories
{
    public class GameRepository : IGameRepository,IDisposable
    {
        private BJContext db;
        

        public GameRepository(BJContext context)
        {
            db = context;   
        }

        public void Add(Game item)
        {
            db.Games.Add(item);
        }

        public int AddWithReturnId(Game item)
        {
            int Id;
            db.Games.Add(item);
            db.SaveChanges();
            return Id = db.Games.Where(x => x.AmountPlayers == item.AmountPlayers).LastOrDefault().Id;
        }

       public Game Find(Game item)
        {
            return db.Games.Where(x => x.Id == item.Id).SingleOrDefault();
        }

        public void Dispose()
        {
            ((IDisposable)db).Dispose();
        }

        public Game Get(int id)
        {
            return db.Games.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
