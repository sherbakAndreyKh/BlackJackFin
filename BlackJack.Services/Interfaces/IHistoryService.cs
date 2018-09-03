using BlackJack.ViewModels;

namespace BlackJack.Services.Interfaces
{
    public interface IHistoryService
    {
        void AddFirstDeal(RequestGameViewModel item);
    }
}