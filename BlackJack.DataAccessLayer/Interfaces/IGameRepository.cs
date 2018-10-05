using BlackJack.Entities;

namespace BlackJack.DataAccessLayer.Interfaces
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        int ReturnNewGameNumber(long id);
    }
}
