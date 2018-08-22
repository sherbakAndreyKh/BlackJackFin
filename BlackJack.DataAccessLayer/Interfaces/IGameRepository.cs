using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.History;

namespace BlackJack.DataAccessLayer.Interfaces
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        int CreateAndReturnId(Game item);
        int ReturnNewGameNumber(int id);
    }
}
