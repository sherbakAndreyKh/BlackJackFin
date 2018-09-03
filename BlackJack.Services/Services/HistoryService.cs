using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.Entities;
using BlackJack.Entities.History;
using BlackJack.Entities.Enums;
using BlackJack.ViewModels;
using BlackJack.Services.Interfaces;

namespace BlackJack.Services.Services
{
    public class HistoryService : IHistoryService
    {
        IRoundLogic _roundLogic { get; set; }
        IGameLogic _gameLogic { get; set; }
        IPlayerLogic _playerLogic { get; set; }
        IPlayerPropertiesLogic _playerPropertiesLogic { get; set; }
        ICardLogic _cardLogic { get; set; }

        public HistoryService(IRoundLogic roundLogic, IGameLogic gameLogic, IPlayerLogic playerLogic, IPlayerPropertiesLogic playerPropertiesLogic, ICardLogic cardLogic)
        {
            _roundLogic = roundLogic;
            _gameLogic = gameLogic;
            _playerLogic = playerLogic;
            _playerPropertiesLogic = playerPropertiesLogic;
            _cardLogic = cardLogic;
        }

        public void AddFirstDeal(RequestGameViewModel item)
        {
            var player = _playerLogic.Find(x => x.Name == item.Player.Name).SingleOrDefault();

            var playerProp = _playerPropertiesLogic.GetWithPlayerAndRoundId(player.Id, item.Round.Id);

            playerProp.Score = item.Player.Properties.SingleOrDefault().Score;

           
            //var Card = _cardLogic.Find(x => x.Name == item.Cards.FirstOrDefault().Name)
            //                     .Where(x => x.Suit == item.Cards.FirstOrDefault().Suit)
            //                     .SingleOrDefault();

            //playerProp.Hand.Add(Card);

            _playerPropertiesLogic.Update(playerProp);
            
            
        }
    
    }


}
