using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels.RequestModel
{
    public class RequestFindWinnerGameView
    {
        public PlayerRoundHandFindWinnerGameViewItem PlayerHand { get; set; }
        public PlayerRoundHandFindWinnerGameViewItem DealerHand { get; set; }
    }

    public class PlayerRoundHandFindWinnerGameViewItem
    {
        public long Id { get; set; }
        public int Score { get; set; }

        public long PlayerId { get; set; }
        public long RoundId { get; set; }
    }
}
