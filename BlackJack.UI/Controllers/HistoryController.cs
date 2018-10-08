using System.Web.Mvc;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.ViewModels;

namespace BlackJack.UI.Controllers
{
    public class HistoryController : Controller
    {
        // Fields
        private IHistoryService _historyService;

        // Constructors
        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        //Methods
        public ActionResult Index()
        {
            IndexHistoryView model = _historyService.ReturnPlayers();
            return View(model);
        }

        public ActionResult GameList(int id)
        {
            GameListHistoryView model = _historyService.ReturnGames(id);
            return View(model);
        }

        public ActionResult RoundsList(int id)
        {
            RoundListHistoryView model = _historyService.ReturnRounds(id);
            return View(model);
        }

        public ActionResult DetailRound(int id)
        {
            DetailsRoundHistoryView model = _historyService.DetailsRound(id);
            return View(model);
        }
    }
}