using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.DAL.Interfaces;
using BlackJack.Entities.History;
using BlackJack.Entities.Participant;
using BlackJack.BLL.Interfaces;
using System.Data.Entity;

namespace BlackJack.BLL.Logic
{
    public class CreateGame : ICreateGame
    {
        private IPlayerRepository _player;
        private IGameRepository _game;
        private IRoundRepository _round;

        public CreateGame(IPlayerRepository player, IGameRepository game, IRoundRepository round)
        {
            _player = player;
            _game = game;
            _round = round;
        }


        public void Add(Game GameItem, Player PlayerName)
        {
             _game.Add(GameItem);

            _round.Add(new Round { NumberRound = "1"});


            _player.Save();
        }
    }
}
