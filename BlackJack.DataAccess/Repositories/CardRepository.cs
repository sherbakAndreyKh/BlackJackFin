using BlackJack.DataAccess.Context;
using BlackJack.Entities;
using BlackJack.DataAccess.Interfaces;
using System.Data;
using Dapper;
using System.Linq;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(BlackJackConnection connection) : base(connection)
        {
        }

        public Card FindCardWithNameAndSuit(string name, string suit)
        {
            Card result;
            string query = $"SELECT * FROM Card WHERE Name='{name}' AND Suit='{suit}'";            
            using (IDbConnection db = _connection.CreateConnection())
            {
                result = db.Query<Card>(query).FirstOrDefault();
            }
            return result;
        }

        public List<Card> GetPlayerRoundHandCards(long roundId)
        {
            List<Card> result;
            var query = $"SELECT * FROM Card JOIN PlayerRoundHandCards ON Card.Id = PlayerRoundHandCards.CardId JOIN PlayerRoundHand ON PlayerRoundHand.Id = PlayerRoundHandCards.PlayerRoundHandId WHERE PlayerRoundHand.RoundId={roundId}";

            using (IDbConnection db = _connection.CreateConnection())
            {
                result = db.Query<Card>(query).ToList();
            }
            return result;
        }
    }
}
