using BlackJack.ViewModels.ResponseModel;
using BlackJack.ViewModels.RequestModel;

namespace BlackJack.BusinessLogicLayer.Interfaces
{
    public interface IGameService
    {
        ResponseGameProcessGameView StartGame(RequestGameStartOptionsGameView item);
        void SaveChanges(ViewModels.RequestModel.RequestGameProcessGameView item);
        ViewModels.ResponseModel.ResponseGameProcessGameView NewRound(ViewModels.RequestModel.RequestGameProcessGameView item);
    }
}