using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.ViewModels;

namespace BlackJack.Services.Interfaces
{
    public interface IStartGame
    {
        GameViewModel Start();
    }
}
