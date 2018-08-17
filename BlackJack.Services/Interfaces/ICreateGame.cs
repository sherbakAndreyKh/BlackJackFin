using BlackJack.ViewModels;

namespace BlackJack.Services.Interfaces
{
    public interface ICreateGame
    {
        void AddGame();
        void AddRound();
        GameViewModel DataGame(int amountBots);
    }
}