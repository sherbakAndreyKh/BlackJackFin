using System;
using System.Threading.Tasks;
using System.Web.Http;
using BlackJack.BusinessLogic.Exceptions;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.ViewModels.RequestModel;
using BlackJack.ViewModels.ResponseModel;
using System.Web.Http.Cors;
using BlackJack.UI.ExceptionFilters;

namespace BlackJack.UI.Controllers
{
    [RoutePrefix("Game")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [StandartExceptions]
    public class GameController : ApiController
    {
        IGameService _gameService;

        public GameController(IGameService gameStartService)
        {
            _gameService = gameStartService;
        }

        [Route("GameStartOptions")]
        [HttpGet]
        public async Task<ResponseGameStartOptionsGameView> GameStartOptions()
        {
            //TODO: вместо try catch везде, добавить фильтр в котором глобально будет обработка ошибок + 

            //TODO: наименование моделей '{method name}{ControllerName}View' +?
            ResponseGameStartOptionsGameView model = await _gameService.GetPlayersStartOptions();
            return model;
        }

        [Route("GameStartOptions")]
        [HttpPost]
        public async Task<ResponseGameProcessGameView> GameStartOptions(RequestGameStartOptionsGameView item)
        {
            ResponseGameProcessGameView startData = await _gameService.StartGame(item);
            return startData;
        }

        [HttpPost]
        [Route("GetFirstDeal")]
        public async Task<ResponseGetFirstDealGameView> GetFirstDeal(RequestGetFirstDealGameView item)
        {
            ResponseGetFirstDealGameView model = await _gameService.GetFirstDeal(item);
            return model;
        }

        [HttpPost]
        [Route("GetCard")]
        public async Task<ResponseGetCardGameView> GetCard(RequestGetCardGameView item)
        {
                ResponseGetCardGameView model = await _gameService.GetCard(item);
                return model;   
        }

        [HttpPost]
        [Route("BotAndDealerLogic")]
        public async Task<ResponseBotLogicGameView> BotAndDealerLogic(RequestBotLogicGameView item)
        {
            ResponseBotLogicGameView model = await _gameService.BotLogic(item);
            return model;
        }

        [HttpPost]
        [Route("FindWinner")]
        public async Task<ResponseFindWinnerGameView> FindWinner(RequestFindWinnerGameView item)
        {
            ResponseFindWinnerGameView model = await _gameService.FindWinner(item);
            return model;
        }

        [HttpPost]
        [Route("NewRound")]
        public async Task<ResponseNewRoundGameView> NewRound(RequestNewRoundGameView item)
        {
            ResponseNewRoundGameView model = await _gameService.NewRound(item);
            return model;
        }
    }
}