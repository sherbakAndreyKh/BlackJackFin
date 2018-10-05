using BlackJack.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;
using BlackJack.Entities.Enums;

namespace BlackJack.BusinessLogic.Services
{
    public class GameService
    {
        IPlayerRepository _playerRepository;
        IGameRepository _gameRepository;
        IRoundRepository _roundRepository;
        ICardRepository _cardRepository;
        IPlayerRoundHandRepository _playerRoundHandRepository;
        IPlayerRoundHandCardsRepository _playerRoundHandCardsRepository;

        public GameService(IPlayerRepository playerRepository,
                              IGameRepository gameRepository,
                              IRoundRepository roundRepository,
                              ICardRepository cardRepository,
                              IPlayerRoundHandRepository playerRoundHandRepository,
                              IPlayerRoundHandCardsRepository playerRoundHandCardsRepository)
        {
            _playerRepository = playerRepository;
            _gameRepository = gameRepository;
            _roundRepository = roundRepository;
            _cardRepository = cardRepository;
            _playerRoundHandRepository = playerRoundHandRepository;
            _playerRoundHandCardsRepository = playerRoundHandCardsRepository;
        }

        public ViewModels.ResponseModel.ResponseGameProcessGameView StartGame(ViewModels.RequestModel.RequestGameStartOptionsGameView item)
        {

        }
    }
}
