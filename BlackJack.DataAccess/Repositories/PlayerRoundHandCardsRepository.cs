using BlackJack.DataAccess.Context;
using BlackJack.DataAccess.Interfaces;
using BlackJack.Entities;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories
{
    public class PlayerRoundHandCardsRepository : BaseRepository<PlayerRoundHandCards>, IPlayerRoundHandCardsRepository
    {
        public PlayerRoundHandCardsRepository(BlackJackConnection connection) : base(connection)
        {
        }

        public async Task AddCommunicationCardsByHands(long playerRoundHandId, long cardId)
        {
            var query = $"INSERT INTO PlayerRoundHandCards(PLayerRoundHandId, CardId) VALUES({playerRoundHandId},{cardId})";

            using (IDbConnection db = _connection.CreateConnection())
            {
               await db.ExecuteAsync(query);
            }
        }

        public async Task<IEnumerable<PlayerRoundHandCards>> GetFieldsByPlayerPropertiesId(long playerRoundHandId)
        {
            IEnumerable<PlayerRoundHandCards> result;
            var query = $"SELECT * FROM PlayerRoundHandCards WHERE PlayerRoundHandId = {playerRoundHandId}";

            using (IDbConnection db = _connection.CreateConnection())
            {
               result = await db.QueryAsync<PlayerRoundHandCards>(query);
            }
            return result;
        }
    }
}
