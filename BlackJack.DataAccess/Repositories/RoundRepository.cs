using BlackJack.DataAccess.Context;
using BlackJack.DataAccess.Interfaces;
using BlackJack.Entities;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BlackJack.DataAccess.Repositories
{
    public class RoundRepository : BaseRepository<Round>, IRoundRepository
    {
        public RoundRepository(BlackJackConnection connection) : base(connection)
        {
        }

        public long ReturnNewRoundNumber(long id)
        {
            List<Round> games = new List<Round>();

            using (IDbConnection db = _connection.CreateConnection())
            {
                games = db.Query<Round>($"SELECT * FROM Round WHERE GameId=@id", new { id }).ToList();
            }
            return games.Count() + 1;
        }

        public List<Round> GetRoundtWithPlayerId(long id)
        {

            using (IDbConnection db = _connection.CreateConnection())
            {
                return db.Query<Round>($"SELECT * FROM Round WHERE GameId=@id", new { id }).ToList();
            }
        }
    }
}
