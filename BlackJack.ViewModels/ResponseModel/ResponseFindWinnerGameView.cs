using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels.ResponseModel
{
    public class ResponseFindWinnerGameView
    {
        public RoundFindWinnerGameViewItem Round { get; set; }
    }
    
    public class RoundFindWinnerGameViewItem
    {
        public long Id { get; set; }
        public string Winner { get; set; }
        public int WinnerScore { get; set; }
        public long RoundNumber { get; set; }

        public long GameId { get; set; }
    } 
}
