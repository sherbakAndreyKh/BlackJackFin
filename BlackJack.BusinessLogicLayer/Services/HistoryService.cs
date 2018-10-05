using System.Collections.Generic;
using System.Linq;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.Entities;
using BlackJack.Entities.Enums;
using BlackJack.BusinessLogicLayer.Maping;
using BlackJack.ViewModels.ResponseModel;
using BlackJack.DataAccess.Interfaces;

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
        public ResponseIndexHistoryView ReturnPlayers()
        {
            List<Player> Players = _playerRepository.GetPlayersWithRole(Role.Player);
            ResponseIndexHistoryView data = new ResponseIndexHistoryView();
            data.Players = _maping.MapListPlayerOnPlayerIndexHistoryViewItem(Players);
            return data;
        }

        public ResponseGameListHistoryView ReturnGames(int PlayerId)
        {
            List<Game> Games = _gameRepository.GetGamestWithPlayerId(PlayerId);
            ResponseGameListHistoryView data = new ResponseGameListHistoryView();
            data.Player = _maping.MapPlayerOnPlayerGameListHistoryViewItem(_playerRepository.Get(PlayerId));
            data.Games = _maping.MapListGameOnGameGameListHistoryViewItem(Games);

            return data;
        }

        public ResponseRoundListHistoryView ReturnRounds(int GameId)
        {
            List<Round> Rounds = _roundRepository.GetAll().Where(x => x.GameId == GameId).ToList();
            var data = new ResponseRoundListHistoryView();
            data.AmountPlayers = _gameRepository.Get(GameId).AmountPlayers;
            data.Rounds = _maping.MapListRoundOnRoundRoundListHistoryViewItem(_roundRepository.GetAll().Where(x => x.GameId == GameId).ToList());




            return data;
        }

        public ResponseDetailsRoundHistoryView DetailsRound(int RoundId)
        {
            Round round = _roundRepository.Get(RoundId);
            Game game = _gameRepository.Get(round.GameId);
            Player player = _playerRepository.Get(game.PlayerId);
            Player dealer = _playerRepository.GetPlayersWithRole(Role.Dealer).SingleOrDefault();
            List<Player> bots = _playerRepository.GetQuantityWithRole(game.AmountPlayers - 1, (int)Role.Bot).ToList();
            var players = new List<Player>();
            players.Add(player);
            players.Add(dealer);
            players.AddRange(bots);

            List<PlayerRoundHand> hands = _playerRoundHandRepository.FindPLayerRoundHandWithRoundId(round.Id).ToList();
            List<Card> cards = _cardRepository.ReturnPlayerpropertiesHand(round.Id);


            var data = new ResponseDetailsRoundHistoryView();
            data.Players = _maping.MapListPlayerOnPlayerDetailsRoundHistoryViewItem(players, hands,cards);
            return data;
        }
    }
}
