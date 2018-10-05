using BlackJack.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IPlayerRoundHandCardsRepository : IBaseRepository<PlayerRoundHandCards>
    {
        void AddCommunicationCardsWithHands(long PlayerRoundHandId, long CardsId);
        List<PlayerRoundHandCards> GetFieldsWithPlayerPropertiesId(long PlayerRoundHandId);
    }
}