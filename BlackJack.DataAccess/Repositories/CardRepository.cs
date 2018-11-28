using BlackJack.DataAccess.Context;
using BlackJack.Entities;
using BlackJack.DataAccess.Interfaces;
using System.Data;
using Dapper;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BlackJack.DataAccess.Repositories
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(string connectionString ) : base(connectionString)
        {
        }

        public async Task<Card> FindCardWithNameAndSuit(string cardName, string cardSuit)
        {
            var result = new Card();
			//TODO: add select top 1 because you use QueryFirstOrDefaultAsync +
			string query = $"SELECT TOP 1 * FROM Card WHERE Name=@Name AND Suit=@Suit";            
            using (IDbConnection db = CreateConnection(_connectionString))
            {
                result = await db.QueryFirstOrDefaultAsync<Card>(query, new { Name= cardName, Suit = cardSuit});
            }
            return  result;
        }

        public async Task<List<Card>> GetPlayerRoundHandCards(List<long> playerRoundHandId)
        {
            var result = new List<Card>();
			//TODO: форматировать запрос, не читаемый +
            var query = $@"SELECT * FROM Card WHERE PlayerRoundHandId IN @PlayerRoundHandId";

            using (IDbConnection db = CreateConnection(_connectionString))
            {
                result = (await db.QueryAsync<Card>(query, new { PlayerRoundHandId = playerRoundHandId})).ToList();
            }
            return result;
        }

        public async Task<List<Card>> GetPlayerRoundHandCards(long playerRoundHandId)
        {
            var result = new List<Card>();
            var query = $@"SELECT * FROM Card WHERE PlayerRoundHandId = @PlayerRoundHandId";

            using (IDbConnection db = CreateConnection(_connectionString))
            {
                result = (await db.QueryAsync<Card>(query, new { PlayerRoundHandId = playerRoundHandId })).ToList();
            }
            return result;
        }
    }
}
