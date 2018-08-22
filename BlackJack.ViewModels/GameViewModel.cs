using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels
{
    public class GameViewModel
    {
        public int GameNumber { get; set; }

        public int RoundNumber { get; set; }

        public List<string> PlayerName { get; set; }
       
    }
}
