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

        public int CreateAndReturnId(Game item)
        {
            db.Games.Add(item);

            db.SaveChanges();

            return item.Id;
        }

        public int ReturnNewGameNumber(int id)
        {
            return db.Games.Where(x => x.PlayerId == id).Count() + 1;
        }
    }
}
