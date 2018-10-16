﻿using System.Threading.Tasks;
using System.Web.Mvc;
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
            var model =  await _gameService.GetPlayersStartOptions();
            return View(model);
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
            ResponseGetCardGameView model = await _gameService.GetCard(item);
            return Json(model);
        }
        [HttpPost]
        public async Task<JsonResult> BotLogic(RequestBotLogicGameView item)
        {
            ResponseBotLogicGameView model = await _gameService.BotLogic(item);
            return Json(model);
        }

        public async Task<ActionResult> NewRound(RequestGameProcessGameView item)
        {
            await _gameService.SaveChanges(item);
            NewRoundGameView roundData = await _gameService.NewRound(item);
            return View(roundData);
        }

        public async Task<ActionResult> EndGame(RequestGameProcessGameView item)
        {
            await _gameService.SaveChanges(item);
            return View();
        }


    }
}