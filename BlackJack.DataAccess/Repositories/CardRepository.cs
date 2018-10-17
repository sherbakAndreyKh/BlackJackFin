using BlackJack.DataAccess.Context;
using BlackJack.Entities;
using BlackJack.DataAccess.Interfaces;
using System.Data;
using Dapper;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(BlackJackConnection connection) : base(connection)
        {
        }

        public async Task<Card> FindCardWithNameAndSuit(string cardName, string cardSuit)
        {
            var result = new Card();
            string query = $"SELECT * FROM Card WHERE Name='{cardName}' AND Suit='{cardSuit}'";            
            using (IDbConnection db = _connection.CreateConnection())
            {
                result = await db.QueryFirstOrDefaultAsync<Card>(query);
            }
            return  result;
        }

        public async Task<List<Card>> GetPlayerRoundHandCards(long roundId)
        {
            var result = new List<Card>();
            var query = $"SELECT * FROM Card JOIN PlayerRoundHandCards ON Card.Id = PlayerRoundHandCards.CardId JOIN PlayerRoundHand ON PlayerRoundHand.Id = PlayerRoundHandCards.PlayerRoundHandId WHERE PlayerRoundHand.RoundId={roundId}";

            using (IDbConnection db = _connection.CreateConnection())
            {
                result = (await db.QueryAsync<Card>(query)).ToList();
            }
            return result;
        }
    }
}
