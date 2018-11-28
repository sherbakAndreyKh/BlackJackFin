using BlackJack.DataAccess.Context;
using BlackJack.DataAccess.Interfaces;
using BlackJack.Entities;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories
{
    public class PlayerRoundHandRepository : BaseRepository<PlayerRoundHand>, IPlayerRoundHandRepository
    {
        public PlayerRoundHandRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<PlayerRoundHand> GetPlayerRoundHandByPlayerAndRoundId(long playerId, long roundId)
        {
            PlayerRoundHand result;
            var query = $"SELECT * FROM PlayerRoundHand WHERE RoundId = @RoundId AND PlayerId = @PlayerId";

            using (IDbConnection db = CreateConnection(_connectionString))
            {
                result = await db.QueryFirstOrDefaultAsync<PlayerRoundHand>(query, new {RoundId = roundId, PlayerId = playerId });
            }
            return result;
        }

        public async Task<List<PlayerRoundHand>> GetPLayerRoundHandListByRoundId(long roundId)
        {
            IEnumerable<PlayerRoundHand> result;
            string query = $"SELECT * FROM PlayerRoundHand WHERE RoundId=@RoundId";
            using (IDbConnection db = CreateConnection(_connectionString))
            {
                result = await db.QueryAsync<PlayerRoundHand>(query, new { RoundId = roundId });
            }
            return result.ToList();
        }
    }
}
