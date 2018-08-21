using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.ViewModels;
using BlackJack.Entities.Participant;
using BlackJack.Entities.History;
using BlackJack.Services.Interfaces;
using BlackJack.BusinessLogicLayer.Interfaces;


namespace BlackJack.Services.Services
{
    public class SaveGame
    {
        private ICardLogic _cardLogic;
        private IDealerLogic _dealerLogic;
        private IPlayerLogic _playerLogic;
        private IBotLogic _botLogic;

        public SaveGame(ICardLogic cardLogic, IDealerLogic dealerLogic, IPlayerLogic playerLogic, IBotLogic botLogic)
        {
            _cardLogic = cardLogic;
            _dealerLogic = dealerLogic;
            _playerLogic = playerLogic;
            _botLogic = botLogic;
        }

        public void Save(GameViewModel data)
        {

        }
    }
}
