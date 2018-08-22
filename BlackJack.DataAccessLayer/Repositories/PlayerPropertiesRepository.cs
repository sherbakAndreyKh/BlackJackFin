using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.DataAccessLayer.Context;
using BlackJack.Entities;
using BlackJack.DataAccessLayer.Interfaces;

namespace BlackJack.DataAccessLayer.Repositories
{
    public class PlayerPropertiesRepository : BaseRepository<PlayerProperties>, IPlayerPropertiesRepository
    {
        //Constructors
        public PlayerPropertiesRepository(BlackJackContext db) : base(db)
        {
        }

        //Methods


    }
}
