using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels.RequestModel
{
    public class RequestGetCardGameView
    {
        public RoundRoundHandGetCardGameViewItem Round { get; set; }
        public PlayerRoundHandGetCardGameViewItem Hand { get; set; }
    }

    public class PlayerRoundHandGetCardGameViewItem
    {
        public int Id { get; set; }
        public List<CardGetFirstDealGameViewItem> Hand { get; set; }
        public int Score { get; set; }
        public long PlayerId { get; set; }
        public PlayerRoundHandGetCardGameViewItem()
        {
            Hand = new List<CardGetFirstDealGameViewItem>();
        }
    }

    public class CardGetCardGameViewItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Suit { get; set; }
        public string ImgPath { get; set; }
    }
    public class RoundRoundHandGetCardGameViewItem
    {
        public long Id { get; set; }
    }
}
