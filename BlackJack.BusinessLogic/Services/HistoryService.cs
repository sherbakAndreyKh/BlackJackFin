using System.Collections.Generic;
using System.Linq;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.Entities;
using BlackJack.Entities.Enums;
using BlackJack.BusinessLogic.Maping;
using BlackJack.ViewModels;
using BlackJack.DataAccess.Interfaces;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Services
{
    public class HistoryService : IHistoryService
    {
        private IPlayerRepository _playerRepository;
        private IGameRepository _gameRepository;
        private IRoundRepository _roundRepository;
        private ICardRepository _cardRepository;
        private IPlayerRoundHandRepository _playerRoundHandRepository;
        private HistoryServiceMapProvider _maping;

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

        public async Task<IndexHistoryView> GetAllPlayers()
        {
            List<Player> players = await _playerRepository.GetAllPlayersByRole(PlayerRole.Player);
            IndexHistoryView data = new IndexHistoryView();
            data.Players = _maping.MapPlayersToPlayerIndexHistoryViewItem(players);
            return data;
        }

        public async Task<GameListHistoryView> GetGamesByPlayerId(int playerId)
        {
            List<Game> games = await _gameRepository.GetGamesByPlayerId(playerId);
            GameListHistoryView data = new GameListHistoryView();
            data.Player = _maping.MapPlayerToPlayerGameListHistoryViewItem(await _playerRepository.Get(playerId));
            data.Games = _maping.MapGamesToGameGameListHistoryViewItem(games);

            return data;
        }

        public async Task<RoundListHistoryView> GetRoundsByGameId(int gameId)
        {
            List<Round> rounds = await _roundRepository.GetAll();
            Game game = await _gameRepository.Get(gameId);
            var data = new RoundListHistoryView();
            data.PlayersAmount = game.PlayersAmount;
            data.Rounds = _maping.MapListRoundToRoundRoundListHistoryViewItem(rounds.Where(x => x.GameId == gameId).ToList());
            return data;
        }

        public async Task<DetailsRoundHistoryView> GetRoundsDetailsByRoundId(int roundId)
        {
            Round round = await _roundRepository.Get(roundId);
            Game game = await _gameRepository.Get(round.GameId);
            Player player =await _playerRepository.Get(game.PlayerId);
            Player dealer =await _playerRepository.GetFirstPlayerByRole(PlayerRole.Dealer);
            List<Player> bots =await _playerRepository.GetQuantityByRole(game.PlayersAmount - 1, (int)PlayerRole.Bot);
            var players = new List<Player>();
            players.Add(player);
            players.Add(dealer);
            players.AddRange(bots);

            List<PlayerRoundHand> hands = await _playerRoundHandRepository.GetPLayerRoundHandListByRoundId(round.Id);
            var playerRoundHandId = new List<long>();
            foreach(var hand in hands)
            {
                playerRoundHandId.Add(hand.Id);
            }

            List<Card> cards = await _cardRepository.GetPlayerRoundHandCards(playerRoundHandId);

            var data = new DetailsRoundHistoryView();
            data.Players = _maping.MapPlayersToPlayerDetailsRoundHistoryViewItem(players, hands, cards);
            return data;
        }
    }
}
