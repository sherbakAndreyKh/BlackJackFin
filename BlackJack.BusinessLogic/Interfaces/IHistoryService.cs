using BlackJack.ViewModels;

namespace BlackJack.BusinessLogic.Interfaces
{
    public interface IHistoryService
    {
        IndexHistoryView ReturnPlayers();
        GameListHistoryView ReturnGames(int id);
        RoundListHistoryView ReturnRounds(int id);
        DetailsRoundHistoryView DetailsRound(int id);
    }
}