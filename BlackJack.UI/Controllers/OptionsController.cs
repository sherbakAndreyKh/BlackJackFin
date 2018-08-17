using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlackJack.ViewModels;
using BlackJack.Services.Interfaces;
using BlackJack.Entities.History;

namespace BlackJack.UI.Controllers
{
    public class OptionsController : Controller
    {
        IGameStartService _gameStartService;
        ICreateGame _createGame;

        public OptionsController(IGameStartService service, ICreateGame createGame)
        {
            _gameStartService = service;
            _createGame = createGame;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(GameOptions item)
        {
            var game = _gameStartService.GetAndCreateGame(item);
            var gameViewModel = _createGame.DataGame(game.AmountPlayers);

            return View("Test", gameViewModel);
        } 
    }
}