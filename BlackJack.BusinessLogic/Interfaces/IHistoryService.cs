using BlackJack.ViewModels;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Interfaces
{
    public interface IHistoryService
    {
        Task<IndexHistoryView> GetAllPlayers();
        Task<GameListHistoryView> GetGamesByPlayerId(int playerId);
        Task<RoundListHistoryView> GetRoundsByGameId(int gameId);
        Task<DetailsRoundHistoryView> GetRoundsDetailsByRoundId(int roundId);
    }
}