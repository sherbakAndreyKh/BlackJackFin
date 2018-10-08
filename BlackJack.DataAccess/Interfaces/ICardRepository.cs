using BlackJack.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Interfaces
{
    public interface ICardRepository : IBaseRepository<Card>
    {
        Card FindCardWithNameAndSuit(string cardName, string cardSuit);
        List<Card> GetPlayerRoundHandCards(long playerPropertiesId);
    }
}