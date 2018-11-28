using BlackJack.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Interfaces
{
    public interface ICardRepository : IBaseRepository<Card>
    {
        Task<Card> FindCardWithNameAndSuit(string cardName, string cardSuit);
        Task<List<Card>> GetPlayerRoundHandCards(List<long> roundId);
        Task<List<Card>> GetPlayerRoundHandCards(long playerRoundHandId);
    }
}