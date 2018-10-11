using BlackJack.ViewModels;
using BlackJack.ViewModels.RequestModel;
using BlackJack.ViewModels.ResponseModel;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Interfaces
{
    public interface IGameService
    {
        Task<ResponseGameProcessGameView> StartGame(RequestGameStartOptionsGameView viewModel);
        Task SaveChanges(RequestGameProcessGameView viewModel);
        Task<NewRoundGameView> NewRound(RequestGameProcessGameView viewModel);
        Task<ViewModels.ResponseModel.ResponseGameStartOptionsGameView> GetPlayersStartOptions();
    }
}