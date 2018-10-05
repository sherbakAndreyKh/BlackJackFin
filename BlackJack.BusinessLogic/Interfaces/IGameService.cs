using BlackJack.ViewModels.ResponseModel;
using BlackJack.ViewModels.RequestModel;

namespace BlackJack.BusinessLogic.Interfaces
{
    public interface IGameService
    {
        ResponseGameProcessGameView StartGame(RequestGameStartOptionsGameView item);
        void SaveChanges(ViewModels.RequestModel.RequestGameProcessGameView item);
        ViewModels.ResponseModel.NewRoundGameView NewRound(ViewModels.RequestModel.RequestGameProcessGameView item);
    }
}