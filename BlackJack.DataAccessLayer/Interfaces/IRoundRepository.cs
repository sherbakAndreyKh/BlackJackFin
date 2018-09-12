using BlackJack.Entities;

namespace BlackJack.DataAccessLayer.Interfaces
{
    public interface IRoundRepository : IBaseRepository<Round>
    {
        int CreateAndReturnId(Round item);
        int ReturnNewRoundNumber(int id);
    }
}
