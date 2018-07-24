using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.ViewModels;
using BlackJack.Entities;
using BlackJack.Services.Interfaces;
using BlackJack.BLL.Interfaces;

namespace BlackJack.Services.Services
{
    public class StartGame : Interfaces.IStartGame
    {
        private BLL.Interfaces.IStartGame game;
        private GameViewModel model;
        public StartGame(BLL.Interfaces.IStartGame start,GameViewModel model)
        {
            game = start;
            this.model = model;
        }


       
        public GameViewModel Start()
        {
            model.CardDeck = game.AddDeck();

            return model;
        }

    }
}
