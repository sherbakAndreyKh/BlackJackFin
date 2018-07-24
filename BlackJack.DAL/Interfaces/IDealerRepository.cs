using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.Participant;

namespace BlackJack.DAL.Interfaces
{
    public interface IDealerRepository
    {
        Dealer Get();
        void Save();
    }
}
