using System.Linq;
using BlackJack.DataAccessLayer.Context;
using BlackJack.Entities;
using BlackJack.DataAccessLayer.Interfaces;
using System.Data.Entity;

namespace BlackJack.DataAccessLayer.Repositories
{
    public class PlayerRoundHandRepository : BaseRepository<PlayerRoundHand>, IPlayerRoundHandRepository
    {
        public PlayerRoundHandRepository(BlackJackContext db) : base(db)
        {
        }

        public PlayerRoundHand GetWithPlayerAndRoundId(int playerId,int roundId)
        {            
            return db.Properties.Where(x => x.PlayerId == playerId && x.RoundId == roundId)
                                .Include(x => x.Hand)
                                .SingleOrDefault();             
        }
    }
}
