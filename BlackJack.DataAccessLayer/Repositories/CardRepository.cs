using BlackJack.DataAccessLayer.Context;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.Entities;

namespace BlackJack.DataAccessLayer.Repositories
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {

        // Constructors
        public CardRepository(BlackJackContext db) : base(db)
        {
        }

      
    }
}
