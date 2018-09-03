using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.DataAccessLayer.Context;
using BlackJack.Entities;
using BlackJack.DataAccessLayer.Interfaces;
using System.Data.Entity;

namespace BlackJack.DataAccessLayer.Repositories
{
    public class PlayerPropertiesRepository : BaseRepository<PlayerProperties>, IPlayerPropertiesRepository
    {
        //Constructors
        public PlayerPropertiesRepository(BlackJackContext db) : base(db)
        {
        }

        //Methods
        public PlayerProperties GetWithPlayerAndRoundId(int playerId,int roundId)
        {
            return db.Properties.Where(x => x.PlayerId == playerId && x.Round_Id == roundId)
                                .Include(x => x.Hand)
                                .SingleOrDefault();
                                
        }

        
    }
}
