using BlackJack.ViewModels;

namespace BlackJack.Services.Interfaces
{
    public interface IGameStartService
    {
        GameViewModel CreateGame(GameOptionsViewModel item);
    }
}