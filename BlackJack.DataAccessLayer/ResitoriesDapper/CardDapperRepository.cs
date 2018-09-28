using BlackJack.DataAccessLayer.Context;
using BlackJack.Entities;
using BlackJack.DataAccessLayer.Interfaces;
using System.Data;
using Dapper;
using System.Linq;

namespace BlackJack.DataAccessLayer.ResitoriesDapper
{
    public class CardDapperRepository : BaseDapperRepository<Card>, ICardRepository
    {
        public CardDapperRepository(BlackJackConnection connection) : base(connection)
        {
        }

        public Card FindCardWithNameAndSuit(string name, string suit)
        {
            using (IDbConnection db = _connection.CreateConnection())
            {
                return db.Query<Card>($"SELECT * FROM Card WHERE Name=@name AND Suit=@suit", new { name, suit }).SingleOrDefault();
            }
        }
    }
}
