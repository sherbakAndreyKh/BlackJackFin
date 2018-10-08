using System.Collections.Generic;
using System.Linq;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.Entities;
using BlackJack.Entities.Enums;
using BlackJack.BusinessLogic.Maping;
using BlackJack.ViewModels;
using BlackJack.DataAccess.Interfaces;

namespace BlackJack.BusinessLogic.Services
{
    public class HistoryService : IHistoryService
    {
        IPlayerRepository _playerRepository;
        IGameRepository _gameRepository;
        IRoundRepository _roundRepository;
        ICardRepository _cardRepository;
        IPlayerRoundHandRepository _playerRoundHandRepository;
        HistoryServiceMapProvider _maping;

        public HistoryService(IPlayerRepository playerRepository,
                              IGameRepository gameRepository,
                              IRoundRepository roundRepository,
                              ICardRepository cardRepository,
                              IPlayerRoundHandRepository playerRoundHandRepository,
                              HistoryServiceMapProvider maping)
        {
            _playerRepository = playerRepository;
            _gameRepository = gameRepository;
            _roundRepository = roundRepository;
            _cardRepository = cardRepository;
            _playerRoundHandRepository = playerRoundHandRepository;
            _maping = maping;
        }

        public IndexHistoryView GetAllPlayers()
        {
            List<Player> players = _playerRepository.GetPlayersByRole(Role.Player);
            IndexHistoryView data = new IndexHistoryView();
            data.Players = _maping.MapListPlayerOnPlayerIndexHistoryViewItem(players);
            return data;
        }

        public GameListHistoryView GetGamesByPlayerId(int playerId)
        {
            List<Game> games = _gameRepository.GetGamesByPlayerId(playerId);
            GameListHistoryView data = new GameListHistoryView();
            data.Player = _maping.MapPlayerOnPlayerGameListHistoryViewItem(_playerRepository.Get(playerId));
            data.Games = _maping.MapListGameOnGameGameListHistoryViewItem(games);

            return data;
        }

        public RoundListHistoryView GetRoundsByGameId(int gameId)
        {
            List<Round> rounds = _roundRepository.GetAll().Where(x => x.GameId == gameId).ToList();
            var data = new RoundListHistoryView();
            data.PlayersAmount = _gameRepository.Get(gameId).PlayersAmount;
            data.Rounds = _maping.MapListRoundOnRoundRoundListHistoryViewItem(rounds);
            return data;
        }

        public DetailsRoundHistoryView GetRoundsDetailsByRoundId(int roundId)
        {
            Round round = _roundRepository.Get(roundId);
            Game game = _gameRepository.Get(round.GameId);
            Player player = _playerRepository.Get(game.PlayerId);
            Player dealer = _playerRepository.GetPlayersByRole(Role.Dealer).FirstOrDefault();
            List<Player> bots = _playerRepository.GetQuantityByRole(game.PlayersAmount - 1, (int)Role.Bot).ToList();
            var players = new List<Player>();
            players.Add(player);
            players.Add(dealer);
            players.AddRange(bots);

            List<PlayerRoundHand> hands = _playerRoundHandRepository.GetPLayerRoundHandListByRoundId(round.Id).ToList();
            List<Card> cards = _cardRepository.GetPlayerRoundHandCards(round.Id);

            var data = new DetailsRoundHistoryView();
            data.Players = _maping.MapListPlayerOnPlayerDetailsRoundHistoryViewItem(players, hands,cards);
            return data;
        }
    }
}
