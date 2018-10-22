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
        private log4net.ILog logger = log4net.LogManager.GetLogger(typeof(HomeController));  //Declaring Log4Net 

        public GameController(IGameService gameStartService)
        {
            _gameService = gameStartService;
        }

        [HttpGet]
        public async Task<ActionResult> GameStartOptions()
        {
            try
            {
                ResponseGameStartOptionsGameView model = await _gameService.GetPlayersStartOptions();
                return View(model);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                ResponseGameStartOptionsGameView model = await _gameService.GetPlayersStartOptions();
                return View(model);
            }
        }

        [HttpPost]
        public async Task<ActionResult> GameStartOptions(RequestGameStartOptionsGameView item)
        {
            try
            {
                ResponseGameProcessGameView startData = await _gameService.StartGame(item);
                return View("GameProcess", startData);
            }
            catch(Exception ex)
            {
                logger.Error(ex.ToString());
                ResponseGameProcessGameView startData = await _gameService.StartGame(item);
                return View("GameProcess", startData);
            }
        }

        [HttpPost]
        public async Task<JsonResult> GetFirstDeal(RequestGetFirstDealGameView item)
        {
            try
            {
                ResponseGetFirstDealGameView model = await _gameService.GetFirstDeal(item);
                return Json(model);
            }
            catch(Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                string model = ex.Message;
                logger.Error(ex.ToString());
                return Json(model);
            }
        }

        [HttpPost]
        public async Task<JsonResult> GetCard(RequestGetCardGameView item)
        {
            try
            {
                ResponseGetCardGameView model = await _gameService.GetCard(item);
                return Json(model);
            }
            catch (WrongDataException ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string model = ex.Message;
                logger.Error(ex.ToString());
                return Json(model);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                string model = ex.Message;
                logger.Error(ex.ToString());
                return Json(model);
            }
        }
        [HttpPost]
        public async Task<JsonResult> BotAnbdDealerLogic(RequestBotLogicGameView item)
        {
            try { 
            ResponseBotLogicGameView model = await _gameService.BotLogic(item);
            return Json(model);
            }
            catch(Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                string model = ex.Message;
                logger.Error(ex.ToString());
                return Json(model);
            }
        }
        [HttpPost]
        public async Task<JsonResult> FindWinner(RequestFindWinnerGameView item)
        {
            try
            {
                ResponseFindWinnerGameView model = await _gameService.FindWinner(item);
                return Json(model);
            }
            catch(Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                string model = ex.Message;
                logger.Error(ex.ToString());
                return Json(model);
            }
        }
        public async Task<ActionResult> NewRound(RequestNewRoundGameView item)
        {
            try
            {
                ResponseNewRoundGameView model = await _gameService.NewRound(item);
                return View(model);
            }
            catch(Exception ex)
            {
                logger.Error(ex.ToString());
                ResponseNewRoundGameView model = await _gameService.NewRound(item);
                return View(model);
            }
        }
    }
}