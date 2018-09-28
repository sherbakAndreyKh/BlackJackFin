using BlackJack.DataAccessLayer.Context;
using BlackJack.Entities;
using BlackJack.DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;
using System;

namespace BlackJack.DataAccessLayer.ResitoriesDapper
{
    public class PlayerDapperRepository : BaseDapperRepository<Player>, IPlayerRepository
    {
        public PlayerDapperRepository(BlackJackConnection connection) : base(connection)
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
                return db.Query<Player>($"SELECT * FROM Player WHERE Name = @Name", new {Name}).SingleOrDefault();
            }
        }
    }
}
