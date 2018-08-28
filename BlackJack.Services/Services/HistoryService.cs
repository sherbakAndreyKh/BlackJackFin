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


        public HistoryService(IRoundLogic roundLogic, IGameLogic gameLogic, IPlayerLogic playerLogic)
        {
            _roundLogic = roundLogic;
            _gameLogic = gameLogic;
            _playerLogic = playerLogic;
        }

        public HistoryViewModel AddAndReturnHistory(AddHistory item)
        {
            //round update
            Round Round = _roundLogic.Get(item.RoundId);
            Round.Winner = item.Winner;
            Round.WinnerScore = item.WinnerScore;
            Game Game = _gameLogic.Get((int)Round.GameId);
            Player Player = _playerLogic.Get(Game.PlayerId);


            _roundLogic.Update(Round);
            _roundLogic.Save();


        

            HistoryViewModel model = new HistoryViewModel()
            {
                PlayerName = Player.Name,
                GameNumber = Game.NumberGame,
                RoundNumber = Round.NumberRound,
                Winner = Round.Winner,
                WinnerScore = Round.WinnerScore,
                AmountPlayers = Game.AmountPlayers
            };

            return model;
        }
    }
}
