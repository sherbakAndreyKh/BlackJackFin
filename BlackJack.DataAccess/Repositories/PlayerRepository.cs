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
            string query = $"SELECT TOP {quantity} * FROM Player WHERE Role=@role ";

            using (IDbConnection db = _connection.CreateConnection())
            {
                return db.Query<Player>(query, new { role });
            }
        }

        public Player FindPlayerWithPlayerName(string Name)
        {
            using (IDbConnection db = _connection.CreateConnection())
            {
                return db.Query<Player>($"SELECT * FROM Player WHERE Name = @Name", new { Name }).SingleOrDefault();
            }
        }

        public List<Player> GetPlayersWithRole(Role role)
        {
            using (IDbConnection db = _connection.CreateConnection())
            {
                return db.Query<Player>($"SELECT * FROM Player WHERE Role = {(int)role}").ToList();
            }
        }
    }
}
