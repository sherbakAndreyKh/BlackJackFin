using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels.RequestModel
{
    public class RequestBotLogicGameView
    {
        public RoundRoundHandBotLogicGameViewItem Round { get; set; }
        public PlayerRoundHandBotLogicGameViewItem Hand { get; set; }
    }

    public class PlayerRoundHandBotLogicGameViewItem
    {
        public int Id { get; set; }
        public List<CardBotLogicGameViewItem> Hand { get; set; }
        public int Score { get; set; }
        public long PlayerId { get; set; }
        public PlayerRoundHandBotLogicGameViewItem()
        {
            Hand = new List<CardBotLogicGameViewItem>();
        }
    }

    public class CardBotLogicGameViewItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Suit { get; set; }
        public string ImgPath { get; set; }
    }
    public class RoundRoundHandBotLogicGameViewItem
    {
        public long Id { get; set; }
    }
}
