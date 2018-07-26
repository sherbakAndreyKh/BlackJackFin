using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.Participant;

namespace BlackJack.BLL.Interfaces
{
    public interface IPlayerBL
    {
        int AddAndReturnId(Player playerName);
    }
}
