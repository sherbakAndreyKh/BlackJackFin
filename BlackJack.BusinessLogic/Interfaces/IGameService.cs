using BlackJack.ViewModels;
using BlackJack.ViewModels.RequestModel;
using BlackJack.ViewModels.ResponseModel;

namespace BlackJack.BusinessLogic.Interfaces
{
    public interface IGameService
    {
        ResponseGameProcessGameView StartGame(RequestGameStartOptionsGameView viewModel);
        void SaveChanges(ViewModels.RequestModel.RequestGameProcessGameView viewModel);
        NewRoundGameView NewRound(ViewModels.RequestModel.RequestGameProcessGameView viewModel);
    }
}