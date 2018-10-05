using BlackJack.DataAccess.Context;
using BlackJack.DataAccess.Interfaces;
using BlackJack.Entities;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BlackJack.DataAccess.Repositories
{
    public class PlayerRoundHandCardsRepository : BaseRepository<PlayerRoundHandCards>, IPlayerRoundHandCardsRepository
    {
        public PlayerRoundHandCardsRepository(BlackJackConnection connection) : base(connection)
        {
        }

        public void AddCommunicationCardsWithHands(long PlayerRoundHandId, long CardsId)
        {
            var query = $"INSERT INTO PlayerRoundHandCards(PLayerRoundHandId, CardId) VALUES({PlayerRoundHandId},{CardsId})";
            using (IDbConnection db = _connection.CreateConnection())
            {
                db.Execute(query);
            }
        }

        public List<PlayerRoundHandCards> GetFieldsWithPlayerPropertiesId(long PlayerRoundHandId)
        {
            var query = $"SELECT * FROM PlayerRoundHandCards WHERE PlayerRoundHandId = {PlayerRoundHandId}";

            using (IDbConnection db = _connection.CreateConnection())
            {
               return db.Query<PlayerRoundHandCards>(query).ToList();
            }
        }
        
        
    }
}
