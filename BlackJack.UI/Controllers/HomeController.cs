﻿using System.Web.Mvc;
using BlackJack.BusinessLogic.Interfaces;

namespace BlackJack.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return new FilePathResult("~/bundles/index.html","text/html");
        }
    }
}