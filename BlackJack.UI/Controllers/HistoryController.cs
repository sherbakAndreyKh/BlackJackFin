using System.Threading.Tasks;
using System.Web.Mvc;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.ViewModels;

namespace BlackJack.UI.Controllers
{
    public class HistoryController : Controller
    {
        private IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        public async Task<ActionResult> Index()
        {
            IndexHistoryView model = await _historyService.GetAllPlayers();
            return View(model);
        }

        public async Task<ActionResult> GetGamesByPlayerId(int playerId)
        {
            GameListHistoryView model = await _historyService.GetGamesByPlayerId(playerId);
            return View(model);
        }

        public async Task<ActionResult> GetRoundsByGameId(int gameId)
        {
            RoundListHistoryView model = await _historyService.GetRoundsByGameId(gameId);
            return View(model);
        }

        public async Task<ActionResult> GetRoundsDetailsByRoundId(int roundId)
        {
            DetailsRoundHistoryView model = await _historyService.GetRoundsDetailsByRoundId(roundId);
            return View(model);
        }
    }
}