using BlackJack.Entities;

namespace BlackJack.DataAccessLayer.Interfaces
{
    public interface ICardRepository : IBaseRepository<Card>
    {
        Card FindCardWithNameAndSuit(string name, string suit);
    }
}
