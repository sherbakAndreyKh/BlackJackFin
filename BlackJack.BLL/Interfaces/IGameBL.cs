using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.History;

namespace BlackJack.BLL.Interfaces
{
    public interface IGameBL
    {
        int Add(Game GameItem, int playerId);
    }
}
