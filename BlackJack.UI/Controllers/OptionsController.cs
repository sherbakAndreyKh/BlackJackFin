using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlackJack.ViewModels;
using BlackJack.Services.Interfaces;

namespace BlackJack.UI.Controllers
{
    public class OptionsController : Controller
    {
        IGameStartService _gameStartService;
        public OptionsController(IGameStartService service)
        {
            _gameStartService = service;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult Index(GameOptions item)
        {
            var a = _gameStartService.GetAndCreateGame(item);

            GameViewModel i = new GameViewModel();
            i.DealerScore = a;

            return RedirectToAction("Test", i);
        }
        
        public ViewResult Test(GameViewModel model)
        {

            return View(model);
        }
    }
}