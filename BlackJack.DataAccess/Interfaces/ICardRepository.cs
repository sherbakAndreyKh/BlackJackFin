using BlackJack.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Interfaces
{
    public interface ICardRepository : IBaseRepository<Card>
    {
        Card FindCardWithNameAndSuit(string name, string suit);
        List<Card> GetPlayerRoundHandCards(long PlayerPropertiesId);
    }
}