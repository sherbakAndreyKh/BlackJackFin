using BlackJack.ViewModels;
using BlackJack.ViewModels.RequestModel;
using BlackJack.ViewModels.ResponseModel;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Interfaces
{
    public interface IGameService
    {
        Task<ResponseGameProcessGameView> StartGame(RequestGameStartOptionsGameView viewModel);
        Task<ResponseGameStartOptionsGameView> GetPlayersStartOptions();
        Task<ResponseGetFirstDealGameView> GetFirstDeal(RequestGetFirstDealGameView model);
        Task<ResponseGetCardGameView> GetCard(RequestGetCardGameView model);
        Task<ResponseBotLogicGameView> BotLogic(RequestBotLogicGameView model);
        Task<ResponseFindWinnerGameView> FindWinner(RequestFindWinnerGameView item);
        //Task SaveChanges(RequestGameProcessGameView viewModel);
        //Task<NewRoundGameView> NewRound(RequestGameProcessGameView viewModel);
    }
}