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

        public void AddCommunicationCardsByHands(long playerRoundHandId, long cardsId)
        {
            var query = $"INSERT INTO PlayerRoundHandCards(PLayerRoundHandId, CardId) VALUES({playerRoundHandId},{cardsId})";

            using (IDbConnection db = _connection.CreateConnection())
            {
                db.Execute(query);
            }
        }

        public List<PlayerRoundHandCards> GetFieldsByPlayerPropertiesId(long playerRoundHandId)
        {
            List<PlayerRoundHandCards> result;
            var query = $"SELECT * FROM PlayerRoundHandCards WHERE PlayerRoundHandId = {playerRoundHandId}";

            using (IDbConnection db = _connection.CreateConnection())
            {
               result = db.Query<PlayerRoundHandCards>(query).ToList();
            }
            return result;
        }
    }
}
