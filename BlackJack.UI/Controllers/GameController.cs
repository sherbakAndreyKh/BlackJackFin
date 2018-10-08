﻿using System.Web.Mvc;
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
        public ActionResult GameStartOptions(RequestGameStartOptionsGameView item)
        {
            ResponseGameProcessGameView startData = _startService.StartGame(item);
            return View("GameProcess", startData);
        }
        
        public ActionResult NewRound(RequestGameProcessGameView item)
        {
            _startService.SaveChanges(item);
            NewRoundGameView roundData = _startService.NewRound(item);
            return View(roundData);
        }
        
        public ActionResult EndGame(RequestGameProcessGameView item)
        {
            _startService.SaveChanges(item);
            return View();
        }
    }
}