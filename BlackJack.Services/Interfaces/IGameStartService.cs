using BlackJack.ViewModels;

namespace BlackJack.Services.Interfaces
{
    public interface IGameStartService
    {
        ResponseGameViewModel CreateGame(GameOptionsViewModel item);
    }
}