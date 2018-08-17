using BlackJack.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.Services.Interfaces;
using BlackJack.Entities.Participant;

namespace BlackJack.Services.Services
{
    //создать игру, создать раунд, передать данные в ViewModel игры 

    public class CreateGame : ICreateGame
    {
        private ICardLogic _cardLogic;
        private IDealerLogic _dealerLogic;
        private IPlayerLogic _playerLogic;
        private IBotLogic _botLogic;


        public CreateGame(ICardLogic cardLogic, IDealerLogic dealerLogic, IPlayerLogic playerLogic, IBotLogic botLogic)
        {
            _cardLogic = cardLogic;
            _dealerLogic = dealerLogic;
            _playerLogic = playerLogic;
            _botLogic = botLogic;
        }

        public void AddGame()
        {

        }

        public void AddRound()
        {

        }

        public GameViewModel DataGame(int amountBots)
        {
            GameViewModel data = new GameViewModel()
            {
                Cards = _cardLogic.GatAll().ToList(),
                Dealer = _dealerLogic.GatAll().FirstOrDefault(),
                Player = _playerLogic.GatAll().LastOrDefault(),
                Bots = new List<Bot>()
            };
            for (int i = 0; i < amountBots; i++)
            {
                data.Bots.Add(_botLogic.Get(i+1));
            }

            return data;
        }
    }
}
