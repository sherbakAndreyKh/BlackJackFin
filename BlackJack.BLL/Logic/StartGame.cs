using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.DAL.Interfaces;
using BlackJack.Entities.History;
using BlackJack.Entities.Participant;
using BlackJack.BLL.Interfaces;
using BlackJack.Entities;
namespace BlackJack.BLL.Logic
{
    public class StartGame : IStartGame
    {
        private ICardRepository _card;

        public StartGame(ICardRepository cardRepository)
        {
            _card = cardRepository;
        }

        public IEnumerable<Card> AddDeck()
        {
            return _card.GetAll();
        }
    }
}
