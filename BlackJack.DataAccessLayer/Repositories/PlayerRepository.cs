using System.Collections.Generic;
using System.Linq;
using BlackJack.DataAccessLayer.Context;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.Entities;
using System.Data.Entity;

namespace BlackJack.DataAccessLayer.Repositories
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(BlackJackContext db) : base(db)
        {
        }

        public int CreateAndReturnId(Player item)
        {
            db.Players.Add(item);
            db.SaveChanges();

            return item.Id;
        }

        public IEnumerable<Player> GetQuantityWithRole(int quantity, int role)
        {
            return db.Players.Where(x => (int)x.Role == role).Take(quantity);
        }
    }
}