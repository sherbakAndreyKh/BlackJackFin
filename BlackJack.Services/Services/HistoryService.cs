using System.Collections.Generic;
using System.Linq;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.Entities;
using BlackJack.Entities.History;
using BlackJack.Entities.Enums;
using BlackJack.Services.Interfaces;
using BlackJack.BusinessLogicLayer.Mapping;
using BlackJack.ViewModels.RequestModel;
using BlackJack.ViewModels.ResponseModel;

namespace BlackJack.Services.Services
{
    public class HistoryService : IHistoryService
    {
        // Fields
        IPlayerLogic _playerLogic;
        IGameLogic _gameLogic;
        IRoundLogic _roundLogic;
        ICardLogic _cardLogic;
        IPlayerPropertiesLogic _playerPropertiesLogic;
        HistoryServiceMappProvider _mapp;

        //Constructors
        public HistoryService(IPlayerLogic playerLogic, IGameLogic gameLogic, IRoundLogic roundLogic, ICardLogic cardLogic, IPlayerPropertiesLogic playerPropertiesLogic, HistoryServiceMappProvider mapp)
        {
            _playerLogic = playerLogic;
            _gameLogic = gameLogic;
            _roundLogic = roundLogic;
            _cardLogic = cardLogic;
            _playerPropertiesLogic = playerPropertiesLogic;
            _mapp = mapp;
        }



        //Methods
        public ResponseIndexHistoryView ReturnPlayers()
        {
            List<Player> Players = _playerLogic.Find(x => x.Role == Roles.Player).ToList();
            ResponseIndexHistoryView data = new ResponseIndexHistoryView();
            data.Players = _mapp.HistoryView(Players);

            return data;

        }

        public ResponseGameListHistoryView ReturnGames(int id)
        {
            List<Game> Games = _gameLogic.Find(x => x.PlayerId == id).ToList();
            ResponseGameListHistoryView data = new ResponseGameListHistoryView();
            data.Player = _mapp.HistoryGamesPlayerView(_playerLogic.Get(id));
            data.Games = _mapp.HistoryGamesView(Games);
          

            return data;
        }


        public ResponseRoundListHistoryView ReturnRounds(int id)
        {
            List<Round> Rounds = _roundLogic.Find(x => x.GameId == id).ToList();
            ResponseRoundListHistoryView data = new ResponseRoundListHistoryView();
            data.AmountPlayers = _gameLogic.Get(id).AmountPlayers;
            data.Rounds = _mapp.HistoryGamesRoundView(_roundLogic.Find(x => x.GameId == id).ToList());

            return data;
        }

        public  ResponseDetailsRoundHistoryView DetailsRound(int id)
        {
            List<Player> players = new List<Player>();
            players.Add(_roundLogic.Get(id).Game.Player);
            players.Add(_playerLogic.GetQuantityWithRole(1, 1).SingleOrDefault());
            List<Player> bots = _playerLogic.GetQuantityWithRole(_roundLogic.Get(id).Game.AmountPlayers - 1, 2).ToList();
            foreach(var bot in bots)
            {
                players.Add(bot);
            }
            List<PlayerProperties> hands = _playerPropertiesLogic.GatAll().Where(x => x.Round_Id == id).ToList();
            
            foreach(var participant in players)
            {
                participant.Properties = hands.Where(x => x.PlayerId == participant.Id).ToList();
            }

            var data = new ResponseDetailsRoundHistoryView();
            data.Players = _mapp.HistoryRoundDetailsView(players);

            return data;

          
        }

       
    }
}
