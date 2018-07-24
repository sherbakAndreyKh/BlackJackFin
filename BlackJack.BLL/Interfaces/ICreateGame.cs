using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.History;
using BlackJack.Entities.Participant;

namespace BlackJack.BLL.Interfaces
{
    public interface ICreateGame
    {
       void Add(Game GameItem,Player PlayerName);
    }
}
