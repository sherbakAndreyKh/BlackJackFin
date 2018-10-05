using BlackJack.DataAccess.Context;
using BlackJack.DataAccess.Interfaces;
using BlackJack.Entities;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BlackJack.DataAccess.Repositories
{
    public class PlayerRoundHandRepository : BaseRepository<PlayerRoundHand>, IPlayerRoundHandRepository
    {
        public PlayerRoundHandRepository(BlackJackConnection connection) : base(connection)
        {
        }

        public PlayerRoundHand GetWithPlayerAndRoundId(long playerId, long roundId)
        {
            var query = $"SELECT * FROM PlayerRoundHand WHERE RoundId={roundId} AND PlayerId={playerId}";
            using (IDbConnection db = _connection.CreateConnection())
            {
                return db.Query<PlayerRoundHand>(query).SingleOrDefault();
            }
        }

        public IEnumerable<PlayerRoundHand> FindPLayerRoundHandWithRoundId(long roundId)
        {
            using (IDbConnection db = _connection.CreateConnection())
            {
                return db.Query<PlayerRoundHand>("SELECT * FROM PlayerRoundHand WHERE RoundId=@roundId", new { roundId });
            }
        }

       
    }
}
