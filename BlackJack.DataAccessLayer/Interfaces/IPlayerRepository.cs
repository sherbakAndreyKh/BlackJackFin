using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.Participant;

namespace BlackJack.DataAccessLayer.Interfaces
{
    public interface IPlayerRepository : IBaseRepository<Player>
    {
        int CreateAndReturnId(Player item);
    }
}
