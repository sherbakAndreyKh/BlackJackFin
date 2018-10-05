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

        public int ReturnNewGameNumber(long id)
        {
            List<Game> games = new List<Game>();

            using (IDbConnection db = _connection.CreateConnection())
            {
                games = db.Query<Game>($"SELECT * FROM Game WHERE PlayerId=@id", new { id }).ToList();
            }
            return games.Count() + 1;
        }

        public List<Game> GetGamestWithPlayerId(long id)
        {

            using (IDbConnection db = _connection.CreateConnection())
            {
                return db.Query<Game>($"SELECT * FROM Game WHERE PlayerId=@id", new { id }).ToList();
            }
        }
    }
}
