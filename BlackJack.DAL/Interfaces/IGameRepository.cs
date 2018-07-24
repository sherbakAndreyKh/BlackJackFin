using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.History;


namespace BlackJack.DAL.Interfaces
{
    public interface IGameRepository
    {
        void Add(Game item);
        int AddWithReturnId(Game item);
        Game Get(int id);
        Game Find(Game item);
        void Save();
    }
}
