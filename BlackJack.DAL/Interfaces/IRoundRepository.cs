using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.History;

namespace BlackJack.DAL.Interfaces
{
    public interface IRoundRepository
    {
        void Add(Round item);
        Round Round(int id);
        void Save();
    }
}
