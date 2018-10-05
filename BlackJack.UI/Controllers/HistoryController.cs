using System.Web.Mvc;
using BlackJack.BusinessLogic.Interfaces;

namespace BlackJack.UI.Controllers
{
    public class HistoryController : Controller
    {
        // Fields
        IHistoryService _historyService;

        // Constructors
        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        //Methods
        public ActionResult Index()
        {
            ViewModels.ResponseModel.IndexHistoryView model = _historyService.ReturnPlayers();
            return View(model);
        }

        public ActionResult GameList(int id)
        {
            ViewModels.ResponseModel.GameListHistoryView model = _historyService.ReturnGames(id);
            return View(model);
        }

        public ActionResult RoundsList(int id)
        {
            ViewModels.ResponseModel.RoundListHistoryView model = _historyService.ReturnRounds(id);
            return View(model);
        }

        public ActionResult DetailRound(int id)
        {
            ViewModels.ResponseModel.DetailsRoundHistoryView model = _historyService.DetailsRound(id);
            return View(model);
        }
    }
}