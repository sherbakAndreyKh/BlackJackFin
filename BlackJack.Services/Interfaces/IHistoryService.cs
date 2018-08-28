using BlackJack.ViewModels;

namespace BlackJack.Services.Interfaces
{
    public interface IHistoryService
    {
        HistoryViewModel AddAndReturnHistory(AddHistory item);
    }
}