using BlackJack.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IPlayerRoundHandCardsRepository : IBaseRepository<PlayerRoundHandCards>
    {
        void AddCommunicationCardsByHands(long PlayerRoundHandId, long CardsId);
        List<PlayerRoundHandCards> GetFieldsByPlayerPropertiesId(long PlayerRoundHandId);
    }
}