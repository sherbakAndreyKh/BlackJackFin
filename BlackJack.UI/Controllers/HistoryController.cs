using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.UI.ExceptionFilters;
using BlackJack.ViewModels;

namespace BlackJack.UI.Controllers
{
    [RoutePrefix("History")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [StandartExceptions]
    public class HistoryController : ApiController
    {
        private IHistoryService _historyService;
        private log4net.ILog logger = log4net.LogManager.GetLogger(typeof(HistoryController));

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IndexHistoryView> Index()
        {
            IndexHistoryView model = await _historyService.GetAllPlayers();
            return model;
        }
        [HttpGet]
        [Route("GetGames/{playerId}")]
        public async Task<GameListHistoryView> GetGamesByPlayerId(int playerId)
        {
            try
            {
                GameListHistoryView model = await _historyService.GetGamesByPlayerId(playerId);
                return model;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw;
            }
        }
        [HttpGet]
        [Route("GetRounds/{gameId}")]
        public async Task<RoundListHistoryView> GetRoundsByGameId(int gameId)
        {
            try
            {
                RoundListHistoryView model = await _historyService.GetRoundsByGameId(gameId);
                return model;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw;
            }
        }
        [HttpGet]
        [Route("GetRoundsDetail/{roundId}")]
        public async Task<DetailsRoundHistoryView> GetRoundsDetailsByRoundId(int roundId)
        {
            try
            {
                DetailsRoundHistoryView model = await _historyService.GetRoundsDetailsByRoundId(roundId);
                return model;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw;
            }
        }
    }
}