using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlackJack.ViewModels;
using BlackJack.Services.Interfaces;

namespace BlackJack.UI.Controllers
{
    public class HomeController : Controller
    {
        IOptions action;
        IStartGame start;

        public HomeController(IOptions test, IStartGame start)
        {
            action = test;
            this.start = start;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Options()
        {
            return View();
        }

       [HttpPost]
       public ActionResult Options(GameOptions item)
        {

          action.Create(item);

            return RedirectToAction("Game");
        }

        public ActionResult Game()
        {
            GameViewModel mod;
            mod = start.Start();
            return View(mod);
        }
    }
}