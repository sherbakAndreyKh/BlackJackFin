using System.Web.Mvc;
using BlackJack.Services.Interfaces;
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

        //rename create game
        [HttpPost]
        public ActionResult GameStartOptions(RequestGameStartOptionsGameView item)
        {
            ResponseGameProcessGameView startData = _startService.StartGame(item);
            return View("GameProcess", startData);
        }

        
        public ActionResult NewRound(RequestGameProcessGameView item)
        {
            _startService.SaveChanges(item);

            return View("GameProcess");
        }
        

        
    }
}