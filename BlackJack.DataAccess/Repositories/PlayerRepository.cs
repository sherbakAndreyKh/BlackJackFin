using BlackJack.DataAccess.Context;
using BlackJack.DataAccess.Interfaces;
using BlackJack.Entities;
using BlackJack.Entities.Enums;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BlackJack.DataAccess.Repositories
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(BlackJackConnection connection) : base(connection)
        {
        }

        public IEnumerable<Player> GetQuantityWithRole(int quantity, int role)
        {
            IEnumerable<Player> result;
            string query = $"SELECT TOP {quantity} * FROM Player WHERE Role={role} ";

            using (IDbConnection db = _connection.CreateConnection())
            {
                result = db.Query<Player>(query);
            }
            return result;
        }

        public Player FindPlayerWithPlayerName(string playerName)
        {
            Player result;
            string query = $"SELECT * FROM Player WHERE Name ='{playerName}'";

            using (IDbConnection db = _connection.CreateConnection())
            {
                result = db.Query<Player>(query).SingleOrDefault();
            }
            return result;
        }

        public List<Player> GetPlayersWithRole(Role role)
        {
            List<Player> result;
            string query = $"SELECT * FROM Player WHERE Role = {(int)role}";

            using (IDbConnection db = _connection.CreateConnection())
            {
                result = db.Query<Player>(query).ToList();
            }
            return result;
        }
    }
}
