using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlackJack.ViewModels
{
    public class GameViewModel
    {
        public string PlayerName { get; set; }
        public int PlayerScore { get; set; }

        public string DealerName { get; set; }
        public int DealerScore { get; set; }

        public List<string> BotName { get; set; }
        public List<int> BotScore { get; set; }
    }
}
