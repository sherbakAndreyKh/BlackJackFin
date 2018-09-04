//using System.Web.Mvc;
//using BlackJack.ViewModels;
//using BlackJack.Services.Interfaces;

//namespace BlackJack.UI.Controllers
//{
//    public class HistoryController : Controller
//    {
//        IHistoryService _historyService;

//        public HistoryController( IHistoryService historyService)
//        {
//            _historyService = historyService;
//        }

//        public ViewResult Index(RequestGameProcessGameView data)
//        {
//           _historyService.AddFirstDeal(data);

//            return View();
//        }
//    }
//}