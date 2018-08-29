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

        public void AddFirstDeal(AddHistory item)
        {
            var player = _playerLogic.Find(x => x.Name == item.PlayerName).SingleOrDefault();

            var playerProp = _playerPropertiesLogic.GetWithPlayerAndRoundId(player.Id, item.RoundId);

            playerProp.Score = item.Score;

            playerProp.Hand = ReMapCards(item.Cards.ToList());

            _playerPropertiesLogic.Update(playerProp);
           
        }




        protected List<CardHistory> ReMapCards(IEnumerable<CardGameViewModelItem> cards)
        {
            var result = new List<CardHistory>();
            foreach (var a in cards)
            {
                var CardView = new CardHistory()
                {
                    Name = a.Name,
                    Suit = a.Suit,
                    Value = a.Value,
                    ImgPath = a.ImgPath
                };
                result.Add(CardView);
            }
            return result;
        }
    }


}
