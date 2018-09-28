using System.Linq;
using BlackJack.DataAccessLayer.Context;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.Entities;

namespace BlackJack.DataAccessLayer.Repositories
{
    public class RoundRepository : BaseRepository<Round>, IRoundRepository
    {
        public RoundRepository(BlackJackContext db) : base(db)
        {
        }

        public long CreateAndReturnId(Round item)
        {
            db.Round.Add(item);

            db.SaveChanges();

            return item.Id;
        }

        public long ReturnNewRoundNumber(long id)
        {
            return db.Round.Where(x => x.GameId == id).Count() + 1;
        }
    }
}
