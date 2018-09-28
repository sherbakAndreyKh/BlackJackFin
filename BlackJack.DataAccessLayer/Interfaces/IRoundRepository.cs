using BlackJack.Entities;

namespace BlackJack.DataAccessLayer.Interfaces
{
    public interface IRoundRepository : IBaseRepository<Round>
    {
        long CreateAndReturnId(Round item);
        long ReturnNewRoundNumber(long id);
    }
}
