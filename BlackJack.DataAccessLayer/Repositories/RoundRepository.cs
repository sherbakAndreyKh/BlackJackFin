using System.Linq;
using BlackJack.DataAccessLayer.Context;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.Entities;

namespace BlackJack.DataAccessLayer.Repositories
{
    public class RoundRepository : BaseRepository<Round>, IRoundRepository
    {
        // Constructors
        public RoundRepository(BlackJackContext db) : base(db)
        {
        }

        // Methods
        public int CreateAndReturnId(Round item)
        {
            db.Rounds.Add(item);

            db.SaveChanges();

            return item.Id;
        }

        public int ReturnNewRoundNumber(int id)
        {
            return db.Rounds.Where(x => x.GameId == id).Count() + 1;
        }
    }
}
