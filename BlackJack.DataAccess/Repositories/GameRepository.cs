using BlackJack.DataAccess.Context;
using BlackJack.DataAccess.Interfaces;
using BlackJack.Entities;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace BlackJack.DataAccess.Repositories
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(BlackJackConnection connection) : base(connection)
        {
        }

        public long ReturnNewGameNumber(long playerId)
        {
            long result ;
            string query = $"SELECT COUNT (*) FROM Game WHERE PlayerId={playerId}";

            using (IDbConnection db = _connection.CreateConnection())
            {
                result = db.QuerySingle<long>(query);
            }
            return result + 1;
        }

        public List<Game> GetGamestWithPlayerId(long playerId)
        {
            List<Game> result;
            string query = $"SELECT * FROM Game WHERE PlayerId={playerId}";

            using (IDbConnection db = _connection.CreateConnection())
            {
               result = db.Query<Game>(query).ToList();
            }
            return result;
        }
    }
}
