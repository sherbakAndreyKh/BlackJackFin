using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.Participant;
using BlackJack.DAL.Context;


namespace BlackJack.DAL.Interfaces
{
   public interface IBotRepository
    {
        Bot Get(int id);
        void Save();
    }
}
