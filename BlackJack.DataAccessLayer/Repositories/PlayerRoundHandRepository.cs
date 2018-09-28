using System.Linq;
using BlackJack.DataAccessLayer.Context;
using BlackJack.Entities;
using BlackJack.DataAccessLayer.Interfaces;
using System.Data.Entity;
using System.Collections.Generic;

namespace BlackJack.DataAccessLayer.Repositories
{
    public class PlayerRoundHandRepository : BaseRepository<PlayerRoundHand>, IPlayerRoundHandRepository
    {
        public PlayerRoundHandRepository(BlackJackContext db) : base(db)
        {
        }

        public IEnumerable<PlayerRoundHand> FindPLayerRoundHandWithRoundId(long roundId)
        {
            throw new System.NotImplementedException();
        }

        public PlayerRoundHand GetWithPlayerAndRoundId(long playerId,long roundId)
        {            
            return db.PlayerRoundHand.Where(x => x.PlayerId == playerId && x.RoundId == roundId)
                                .Include(x => x.Hand)
                                .SingleOrDefault();             
        }
    }
}
