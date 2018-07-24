using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.ViewModels;
using BlackJack.Entities.Participant;
using BlackJack.Entities.History;
using BlackJack.Services.Interfaces;
using BlackJack.BLL.Interfaces;


namespace BlackJack.Services.Services
{
    public class Options : IOptions
    {
        private ICreateGame _game;

        public Options(ICreateGame serv)
        {
            _game = serv;
        }

        public void Create(GameOptions options)
        {
            Player player = new Player()
            {
                Name = options.PlayerName
            };

            Game game = new Game()
            {
                AmountPlayers = options.Bots
            };

            _game.Add(game, player);
            
        }
    }

}

