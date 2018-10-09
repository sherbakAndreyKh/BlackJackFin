using BlackJack.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IPlayerRoundHandCardsRepository : IBaseRepository<PlayerRoundHandCards>
    {
        Task AddCommunicationCardsByHands(long playerRoundHandId, long cardId);
        Task<IEnumerable<PlayerRoundHandCards>> GetFieldsByPlayerPropertiesId(long playerRoundHandId);
    }
}