using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using BlackJack.BusinessLogic.Exceptions;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.ViewModels;
using BlackJack.ViewModels.RequestModel;
using BlackJack.ViewModels.ResponseModel;

namespace BlackJack.UI.Controllers
{
    public class GameController : Controller
    {
        IGameService _gameService;

        public GameController(IGameService gameStartService)
        {
            _gameService = gameStartService;
        }

        [HttpGet]
        public async Task<ActionResult> GameStartOptions()
        {
            try
            {
            ResponseGameStartOptionsGameView model =  await _gameService.GetPlayersStartOptions();
            return View(model);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> GameStartOptions(RequestGameStartOptionsGameView item)
        {
            ResponseGameProcessGameView startData = await _gameService.StartGame(item);

            return View("GameProcess",  startData);
        }

        [HttpPost]
        public async Task<JsonResult> GetFirstDeal(RequestGetFirstDealGameView item)
        {
            ResponseGetFirstDealGameView model = await _gameService.GetFirstDeal(item);
            return Json(model);
        }

        [HttpPost]
        public async Task<JsonResult> GetCard(RequestGetCardGameView item)
        {
            try
            {
                ResponseGetCardGameView model = await _gameService.GetCard(item);
                return Json(model);
            }
            catch (IncorrectDataException ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var model = ex.Message;
                return Json(model);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var model = ex.Message;
                return Json(model);
            }
        }
        [HttpPost]
        public async Task<JsonResult> BotAnbdDealerLogic(RequestBotLogicGameView item)
        {
            ResponseBotLogicGameView model = await _gameService.BotLogic(item);
            return Json(model);
        }
        [HttpPost]
        public async Task<JsonResult> FindWinner(RequestFindWinnerGameView item)
        {
            ResponseFindWinnerGameView model = await _gameService.FindWinner(item);
            return Json(model);
        }
        public async Task<ActionResult> NewRound(RequestNewRoundGameView item)
        {
            ResponseNewRoundGameView model = await _gameService.NewRound(item);
            return View(model);
        }
    }
}