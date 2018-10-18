using System.Collections.Generic;


namespace BlackJack.ViewModels.ResponseModel
{
    public class ResponseGetCardGameView
    {
       public PlayerRoundHandGetCardGameViewItem Hand { get; set; }
    }

    public class PlayerRoundHandGetCardGameViewItem
    {
        public long Id { get; set; }
        public List<CardGetCardGameViewItem> Hand { get; set; }
        public int Score { get; set; }
        public long PlayerId { get; set; }
        public PlayerRoundHandGetCardGameViewItem()
        {
            Hand = new List<CardGetCardGameViewItem>();
        }
    }

    public class CardGetCardGameViewItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Suit { get; set; }
        public string ImgPath { get; set; }
    }
}
