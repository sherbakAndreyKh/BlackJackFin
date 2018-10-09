using System.Threading.Tasks;
using System.Web.Mvc;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.ViewModels;
using BlackJack.ViewModels.RequestModel;
using BlackJack.ViewModels.ResponseModel;

namespace BlackJack.UI.Controllers
{
    public class GameController : Controller
    {
        IGameService _startService;

        public GameController(IGameService gameStartService)
        {
            _startService = gameStartService;
        }

        [HttpGet]
        public ActionResult GameStartOptions()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> GameStartOptions(RequestGameStartOptionsGameView item)
        {
            ResponseGameProcessGameView startData = await _startService.StartGame(item);

            return View("GameProcess",  startData);
        }

        public async Task<ActionResult> NewRound(RequestGameProcessGameView item)
        {
            await _startService.SaveChanges(item);
            NewRoundGameView roundData = await _startService.NewRound(item);
            return View(roundData);
        }

        public async Task<ActionResult> EndGame(RequestGameProcessGameView item)
        {
            await _startService.SaveChanges(item);
            return View();
        }
    }
}