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
            using (IDbConnection db = _connection.CreateConnection())
            {
                return db.Query<Card>($"SELECT * FROM Card WHERE Name=@name AND Suit=@suit", new { name, suit }).SingleOrDefault();
            }
        }

        public List<Card> ReturnPlayerpropertiesHand(long RoundId)
        {
            var query = $"SELECT * FROM Card JOIN PlayerRoundHandCards ON Card.Id = PlayerRoundHandCards.CardId JOIN PlayerRoundHand ON PlayerRoundHand.Id = PlayerRoundHandCards.PlayerRoundHandId WHERE PlayerRoundHand.RoundId={RoundId}";

            using (IDbConnection db = _connection.CreateConnection())
            {
                return db.Query<Card>(query).ToList();
            }
        }
    }
}
