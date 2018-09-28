using BlackJack.DataAccessLayer.Context;
using BlackJack.Entities;
using BlackJack.DataAccessLayer.Interfaces;
using System.Data;
using System.Collections.Generic;
using Dapper;
using System.Linq;

namespace BlackJack.DataAccessLayer.ResitoriesDapper
{
    public class GameDapperRepository : BaseDapperRepository<Game>, IGameRepository
    {
        public GameDapperRepository(BlackJackConnection connection) : base(connection)
        {
        }

        public int ReturnNewGameNumber(long id)
        {
            List<Game> games = new List<Game>();

            using (IDbConnection db = _connection.CreateConnection())
            {
               games =  db.Query<Game>($"SELECT * FROM Game WHERE PlayerId=@id", new { id }).ToList();
            }
            return games.Count();
        }
    }
}
