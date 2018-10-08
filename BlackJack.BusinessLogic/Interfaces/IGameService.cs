using BlackJack.ViewModels;
using BlackJack.ViewModels.RequestModel;
using BlackJack.ViewModels.ResponseModel;

namespace BlackJack.BusinessLogic.Interfaces
{
    public interface IGameService
    {
        ResponseGameProcessGameView StartGame(RequestGameStartOptionsGameView item);
        void SaveChanges(ViewModels.RequestModel.RequestGameProcessGameView item);
        NewRoundGameView NewRound(ViewModels.RequestModel.RequestGameProcessGameView item);
    }
}