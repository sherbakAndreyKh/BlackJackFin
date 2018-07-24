using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;

namespace BlackJack.BLL.Interfaces
{
    public interface IStartGame
    {
       IEnumerable<Card> AddDeck();
    }
}
