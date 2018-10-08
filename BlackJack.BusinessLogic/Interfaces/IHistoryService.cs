using BlackJack.ViewModels;

namespace BlackJack.BusinessLogic.Interfaces
{
    public interface IHistoryService
    {
        IndexHistoryView GetAllPlayers();
        GameListHistoryView GetGamesByPlayerId(int playerId);
        RoundListHistoryView GetRoundsByGameId(int gameId);
        DetailsRoundHistoryView GetRoundsDetailsByRoundId(int roundId);
    }
}