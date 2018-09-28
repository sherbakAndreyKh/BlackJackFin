using System.Linq;
using BlackJack.DataAccessLayer.Context;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.Entities;

namespace BlackJack.DataAccessLayer.Repositories
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(BlackJackContext db) : base(db)
        {
        }

        public long CreateAndReturnId(Game item)
        {
            db.Game.Add(item);

            db.SaveChanges();

            return item.Id;
        }

        public int ReturnNewGameNumber(long id)
        {
            return db.Game.Where(x => x.PlayerId == id).Count() + 1;
        }
    }
}
