using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels.RequestModel
{
    public class RequestNewRoundGameView
    {
        public GameNewRoundGameViewItem Game { get; set; }
        public RoundNewRoundGameViewItem Round { get; set; }
        public PlayerNewRoundGameViewItem Player { get; set; }
        public PlayerNewRoundGameViewItem Dealer { get; set; }
        public List<PlayerNewRoundGameViewItem> Bots { get; set; }

        public string Winner { get; set; }

        public RequestNewRoundGameView()
        {
            Bots = new List<PlayerNewRoundGameViewItem>();
        }
    }

    public class PlayerNewRoundGameViewItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Role { get; set; }
        public PlayerRoundHandGameProcessGameViewItem PlayerRoundHand { get; set; }
    }

    public class PlayerRoundHandNewRoundGameViewItem
    {
        public long Id { get; set; }
        public int Score { get; set; }
        public long PlayerId { get; set; }
        public long RoundId { get; set; }
        public PlayerRoundHandNewRoundGameViewItem()
        {
        }
    }

    public class GameNewRoundGameViewItem
    {
        public long Id { get; set; }
        public long GameNumber { get; set; }
    }

    public class RoundNewRoundGameViewItem
    {
        public long Id { get; set; }
        public long RoundNumber { get; set; }
        public string Winner { get; set; }
    }
}
