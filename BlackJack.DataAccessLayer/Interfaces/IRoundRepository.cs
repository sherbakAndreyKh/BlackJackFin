using BlackJack.Entities.History;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DataAccessLayer.Interfaces
{
    public interface IRoundRepository : IBaseRepository<Round>
    {
        int CreateAndReturnId(Round item);
        int ReturnNewRoundNumber(int id);
        IQueryable<Round> Include();
    }
}
