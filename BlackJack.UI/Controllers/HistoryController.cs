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

        public ActionResult Index()
        {
            IndexHistoryView model = _historyService.GetAllPlayers();
            return View(model);
        }

        public ActionResult GetGamesByPlayerId(int playerId)
        {
            GameListHistoryView model = _historyService.GetGamesByPlayerId(playerId);
            return View(model);
        }

        public ActionResult GetRoundsByGameId(int gameId)
        {
            RoundListHistoryView model = _historyService.GetRoundsByGameId(gameId);
            return View(model);
        }

        public ActionResult GetRoundsDetailsByRoundId(int roundId)
        {
            DetailsRoundHistoryView model = _historyService.GetRoundsDetailsByRoundId(roundId);
            return View(model);
        }
    }
}