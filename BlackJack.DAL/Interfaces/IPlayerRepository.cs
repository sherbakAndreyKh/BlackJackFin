using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BlackJack.Entities.Participant;

namespace BlackJack.DAL.Interfaces
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetAll();
        Player Get(int id);
        IEnumerable<Player> Find(Func<Player, Boolean> predicate);
        void Create(Player item);
        void Update(Player item);
        void Delete(int id);
        void Save();
    }
}
