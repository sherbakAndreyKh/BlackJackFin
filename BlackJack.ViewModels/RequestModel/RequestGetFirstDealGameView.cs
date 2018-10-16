using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels.RequestModel
{
    public class RequestGetFirstDealGameView
    {
        public RoundRoundHandGetFirstDealGameViewItem Round { get; set; }
        public List<PlayerRoundHandGetFirstDealGameViewItem> Hands { get; set; }
    }
    public class PlayerRoundHandGetFirstDealGameViewItem
    {
        public int Id { get; set; }
        public List<CardGetFirstDealGameViewItem> Hand { get; set; }
        public int Score { get; set; }
        public long PlayerId { get; set; }
        public PlayerRoundHandGetFirstDealGameViewItem()
        {
            Hand = new List<CardGetFirstDealGameViewItem>();
        }
    }

    public class CardGetFirstDealGameViewItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Suit { get; set; }
        public string ImgPath { get; set; }
    }

    public class RoundRoundHandGetFirstDealGameViewItem
    {
        public long Id { get; set; }
    }
}
