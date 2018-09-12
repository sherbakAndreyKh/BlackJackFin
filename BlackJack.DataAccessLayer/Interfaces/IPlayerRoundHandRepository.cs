using BlackJack.Entities;

namespace BlackJack.DataAccessLayer.Interfaces
{
    public interface IPlayerRoundHandRepository : IBaseRepository<PlayerRoundHand>
    {
       PlayerRoundHand GetWithPlayerAndRoundId(int playerId, int roundId);
    }
}
