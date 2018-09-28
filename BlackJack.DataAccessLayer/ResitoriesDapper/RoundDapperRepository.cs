using BlackJack.DataAccessLayer.Context;
using BlackJack.Entities;
using BlackJack.DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;

namespace BlackJack.DataAccessLayer.ResitoriesDapper
{
    public class RoundDapperRepository : BaseDapperRepository<Round>, IRoundRepository
    {
        public RoundDapperRepository(BlackJackConnection connection) : base(connection)
        {
        }

        public long ReturnNewRoundNumber(long id)
        {
            List<Round> games = new List<Round>();

            using (IDbConnection db = _connection.CreateConnection())
            {
                games = db.Query<Round>($"SELECT * FROM Round WHERE GameId=@id", new { id }).ToList();
            }
            return games.Count();
        }
    }
}
