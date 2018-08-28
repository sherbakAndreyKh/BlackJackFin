using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlackJack.ViewModels;
using BlackJack.Services.Interfaces;

namespace BlackJack.UI.Controllers
{
    public class GameController : Controller
    {
        IGameStartService _startService;

        public GameController(IGameStartService gameStartService)
        {
            _startService = gameStartService;
        }

        [HttpGet]
        public ActionResult Options()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Options(GameOptionsViewModel item)
        {
            var StartData = _startService.CreateGame(item);

            return View("Game", StartData);
        }


    }
}