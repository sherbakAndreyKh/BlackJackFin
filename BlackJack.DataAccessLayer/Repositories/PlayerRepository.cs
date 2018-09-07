using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.DataAccessLayer.Context;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.Entities;
using BlackJack.Entities.Enums;
using System.Data.Entity;

namespace BlackJack.DataAccessLayer.Repositories
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        // Constructors
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

        public IEnumerable<Player> GetQuantityWithRole(int quantity, int role)
        {
            return db.Players.Where(x => (int)x.Role == role).Take(quantity);
        }
    }
}