using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.ViewModels;
using BlackJack.Entities.History;

namespace BlackJack.Services.Interfaces
{
    public interface IGameStartService
    {
        Game GetAndCreateGame(GameOptions options);
    }
}
