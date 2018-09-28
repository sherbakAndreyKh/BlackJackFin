using System.Collections.Generic;
using System.Linq;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.Entities;
using BlackJack.Entities.Enums;
using BlackJack.BusinessLogicLayer.Maping;
using BlackJack.ViewModels.ResponseModel;
using BlackJack.DataAccessLayer.Interfaces;

namespace BlackJack.BusinessLogicLayer.Services
{
    public class HistoryService : IHistoryService
    {
        // Fields

        IPlayerRepository _playerRepository;
        IGameRepository _gameRepository;
        IRoundRepository _roundRepository;
        ICardRepository _cardRepository;
        IPlayerRoundHandRepository _playerRoundHandRepository;
        HistoryServiceMappProvider _maping;

        //Constructors
        public HistoryService(IPlayerRepository playerRepository,
                              IGameRepository gameRepository,
                              IRoundRepository roundRepository,
                              ICardRepository cardRepository,
                              IPlayerRoundHandRepository playerRoundHandRepository, 
                              HistoryServiceMappProvider maping)
        {
            _playerRepository = playerRepository;
            _gameRepository = gameRepository;
            _roundRepository = roundRepository;
            _cardRepository = cardRepository;
            _playerRoundHandRepository = playerRoundHandRepository;
            _maping = maping;
        }


        //Methods
        //public ResponseIndexHistoryView ReturnPlayers()
        //{
        //    List<Player> Players = _playerRepository.Find(x => x.Role == Role.Player).ToList();
        //    ResponseIndexHistoryView data = new ResponseIndexHistoryView();
        //    data.Players = _maping.MapListPlayerOnPlayerIndexHistoryViewItem(Players);

        //    return data;
        //}

        //public ResponseGameListHistoryView ReturnGames(int id)
        //{
        //    List<Game> Games = _gameRepository.Find(x => x.PlayerId == id).ToList();
        //    ResponseGameListHistoryView data = new ResponseGameListHistoryView();
        //    data.Player = _maping.MapPlayerOnPlayerGameListHistoryViewItem(_playerRepository.Get(id));
        //    data.Games = _maping.MapListGameOnGameGameListHistoryViewItem(Games);
          
        //    return data;
        //}

        //public ResponseRoundListHistoryView ReturnRounds(int id)
        //{
        //    List<Round> Rounds = _roundRepository.Find(x => x.GameId == id).ToList();
        //    ResponseRoundListHistoryView data = new ResponseRoundListHistoryView();
        //    data.AmountPlayers = _gameRepository.Get(id).AmountPlayers;
        //    data.Rounds = _maping.MapListRoundOnRoundRoundListHistoryViewItem(_roundRepository.Find(x => x.GameId == id).ToList());

        //    return data;
        //}

        //public ResponseDetailsRoundHistoryView DetailsRound(int id)
        //{
        //    List<Player> players = new List<Player>();
            
        //    players.Add(_playerRepository.Get((int)_roundRepository.Get(id).Game.PlayerId));
        //    players.Add(_playerRepository.GetQuantityWithRole(1, (int)Role.Dealer).SingleOrDefault());
        //    List<Player> bots = _playerRepository.GetQuantityWithRole(_roundRepository.Get(id).Game.AmountPlayers - 1, (int)Role.Bot).ToList();

        //    foreach(var bot in bots)
        //    {
        //        players.Add(bot);
        //    }

        //    List<PlayerRoundHand> hands = _playerRoundHandRepository.Find(x=>x.RoundId== id).ToList();
            
        //    foreach(var participant in players)
        //    {
        //        participant.PlayerRoundHands = hands.Where(x => (int)x.PlayerId == participant.Id).ToList();
        //    }

        //    var data = new ResponseDetailsRoundHistoryView();
        //    data.Players = _maping.MapListPlayerOnPlayerDetailsRoundHistoryViewItem(players);

        //    return data;
        //}
    }
}
