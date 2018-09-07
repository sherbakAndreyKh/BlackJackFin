using System.Web.Mvc;
using BlackJack.Services.Interfaces;

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
        
        // Methods
        public ActionResult Index()
        {
            ViewModels.ResponseModel.ResponseIndexHistoryView model = _historyService.ReturnPlayers();
            return View(model);
        }


        public ActionResult GameList(int id)
        {
            ViewModels.ResponseModel.ResponseGameListHistoryView model = _historyService.ReturnGames(id);
            return View(model);
        }

        public ActionResult RoundsList(int id)
        {
            ViewModels.ResponseModel.ResponseRoundListHistoryView model = _historyService.ReturnRounds(id);
            return View(model);
        }

        public ActionResult DetailRound(int id)
        {
            ViewModels.ResponseModel.ResponseDetailsRoundHistoryView model = _historyService.DetailsRound(id);
            return View(model);
        }
    }
}