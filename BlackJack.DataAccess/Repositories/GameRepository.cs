using BlackJack.DataAccess.Context;
using BlackJack.DataAccess.Interfaces;
using BlackJack.Entities;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(BlackJackConnection connection) : base(connection)
        {
        }

        public async Task<long> GetNewGameNumber(long playerId)
        {
            long result;
            string query = $"SELECT COUNT (*) FROM Game WHERE PlayerId={playerId}";

            using (IDbConnection db = _connection.CreateConnection())
            {
                result = await db.QueryFirstOrDefaultAsync<long>(query);
            }
            return result + 1;
        }

        public async Task<List<Game>> GetGamesByPlayerId(long playerId)
        {
            IEnumerable<Game> result;
            string query = $"SELECT * FROM Game WHERE PlayerId={playerId}";

            using (IDbConnection db = _connection.CreateConnection())
            {
               result = await db.QueryAsync<Game>(query);
            }
            return result.ToList();
        }
    }
}
