using System.Web.Mvc;
using BlackJack.Services.Interfaces;

namespace BlackJack.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}