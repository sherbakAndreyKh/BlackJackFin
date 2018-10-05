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

    

        public Player FindPlayerWithPlayerName(string Name)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Player> GetQuantityWithRole(int quantity, int role)
        {
            return db.Player.Where(x => (int)x.Role == role).Take(quantity);
        }
    }
}