using BlackJack.ViewModels.ResponseModel;

namespace BlackJack.Services.Interfaces
{
    public interface IHistoryService
    {
        ResponseIndexHistoryView ReturnPlayers();
        ResponseGameListHistoryView ReturnGames(int id);
        ResponseRoundListHistoryView ReturnRounds(int id);
        ResponseDetailsRoundHistoryView DetailsRound(int id);
    }
}