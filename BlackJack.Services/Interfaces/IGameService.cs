using BlackJack.ViewModels.ResponseModel;
using BlackJack.ViewModels.RequestModel;

namespace BlackJack.Services.Interfaces
{
    public interface IGameService
    {
        ResponseGameProcessGameView StartGame(RequestGameStartOptionsGameView item);
        void SaveChanges(ViewModels.RequestModel.RequestGameProcessGameView item);
    }
}