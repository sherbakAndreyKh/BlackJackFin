using BlackJack.Entities;

namespace BlackJack.DataAccessLayer.Interfaces
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        long CreateAndReturnId(Game item);
        int ReturnNewGameNumber(long id);
    }
}
