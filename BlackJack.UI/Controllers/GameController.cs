using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using BlackJack.BusinessLogic.Exceptions;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.ViewModels.RequestModel;
using BlackJack.ViewModels.ResponseModel;

namespace BlackJack.UI.Controllers
{
    [RoutePrefix("Game")]
    public class GameController : ApiController
    {
        IGameService _gameService;
        private log4net.ILog logger = log4net.LogManager.GetLogger(typeof(HomeController));

        public GameController(IGameService gameStartService)
        {
            _gameService = gameStartService;
        }

        [Route("GameStartOptions")]
        [HttpGet]
        public async Task<ResponseGameStartOptionsGameView> GameStartOptions()
        {
            try
            {
                ResponseGameStartOptionsGameView model = await _gameService.GetPlayersStartOptions();
                return model;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                ResponseGameStartOptionsGameView model = await _gameService.GetPlayersStartOptions();
                return model;
            }
        }
        [HttpPost]
        [Route("GameStartOptions")]
        public async Task<ResponseGameProcessGameView> GameStartOptions(RequestGameStartOptionsGameView item)
        {
            try
            {
                ResponseGameProcessGameView startData = await _gameService.StartGame(item);
                return startData;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                ResponseGameProcessGameView startData = await _gameService.StartGame(item);
                return startData;
            }
        }

        [HttpPost]
        [Route("GetFirstDeal")]
        public async Task<ResponseGetFirstDealGameView> GetFirstDeal(RequestGetFirstDealGameView item)
        {
            try
            {
                ResponseGetFirstDealGameView model = await _gameService.GetFirstDeal(item);
                return model;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                ResponseGetFirstDealGameView model = await _gameService.GetFirstDeal(item);
                return model;
            }
        }

        [HttpPost]
        [Route("GetCard")]
        public async Task<ResponseGetCardGameView> GetCard(RequestGetCardGameView item)
        {
            try
            {
                ResponseGetCardGameView model = await _gameService.GetCard(item);
                return model;
            }
            catch (WrongDataException ex)
            {
                logger.Error(ex.ToString());
                ResponseGetCardGameView model = await _gameService.GetCard(item);
                return model;
               
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                ResponseGetCardGameView model = await _gameService.GetCard(item);
                return model;
              
            }
        }
        [HttpPost]
        [Route("BotAndDealerLogic")]
        public async Task<ResponseBotLogicGameView> BotAndDealerLogic(RequestBotLogicGameView item)
        {
            try
            {
                ResponseBotLogicGameView model = await _gameService.BotLogic(item);
                return model;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                ResponseBotLogicGameView model = await _gameService.BotLogic(item);
                return model;
            }
        }
        [HttpPost]
        [Route("FindWinner")]
        public async Task<ResponseFindWinnerGameView> FindWinner(RequestFindWinnerGameView item)
        {
            try
            {
                ResponseFindWinnerGameView model = await _gameService.FindWinner(item);
                return model;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                ResponseFindWinnerGameView model = await _gameService.FindWinner(item);
                return model;
                
            }
        }
        [HttpPost]
        [Route("NewRound")]
        public async Task<ResponseNewRoundGameView> NewRound(RequestNewRoundGameView item)
        {
            try
            {
                ResponseNewRoundGameView model = await _gameService.NewRound(item);
                return model;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                ResponseNewRoundGameView model = await _gameService.NewRound(item);
                return model;
            }
        }
    }
}