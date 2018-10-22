using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.ViewModels;

namespace BlackJack.UI.Controllers
{
    public class HistoryController : Controller
    {
        private IHistoryService _historyService;
        private log4net.ILog logger = log4net.LogManager.GetLogger(typeof(HomeController));  //Declaring Log4Net 


        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                IndexHistoryView model = await _historyService.GetAllPlayers();
                return View(model);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                IndexHistoryView model = await _historyService.GetAllPlayers();
                return View(model);
            }
        }

        public async Task<ActionResult> GetGamesByPlayerId(int playerId)
        {
            try
            {
                GameListHistoryView model = await _historyService.GetGamesByPlayerId(playerId);
                return View(model);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                GameListHistoryView model = await _historyService.GetGamesByPlayerId(playerId);
                return View(model);
            }
        }

        public async Task<ActionResult> GetRoundsByGameId(int gameId)
        {
            try
            {
                RoundListHistoryView model = await _historyService.GetRoundsByGameId(gameId);
                return View(model);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                RoundListHistoryView model = await _historyService.GetRoundsByGameId(gameId);
                return View(model);
            }
        }

        public async Task<ActionResult> GetRoundsDetailsByRoundId(int roundId)
        {
            try
            {
                DetailsRoundHistoryView model = await _historyService.GetRoundsDetailsByRoundId(roundId);
                return View(model);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                DetailsRoundHistoryView model = await _historyService.GetRoundsDetailsByRoundId(roundId);
                return View(model);
            }
        }
    }
}