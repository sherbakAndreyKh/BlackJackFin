using BlackJack.Entities;

namespace BlackJack.DataAccessLayer.Interfaces
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        int CreateAndReturnId(Game item);
        int ReturnNewGameNumber(int id);
    }
}
