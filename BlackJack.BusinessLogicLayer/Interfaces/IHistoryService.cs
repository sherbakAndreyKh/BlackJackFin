using BlackJack.ViewModels.ResponseModel;

namespace BlackJack.BusinessLogicLayer.Interfaces
{
    public interface IHistoryService
    {
        ResponseIndexHistoryView ReturnPlayers();
        ResponseGameListHistoryView ReturnGames(int id);
        ResponseRoundListHistoryView ReturnRounds(int id);
        ResponseDetailsRoundHistoryView DetailsRound(int id);
    }
}