using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels.ResponseModel
{
    public class ResponseDetailsRoundHistoryView
    {
        public List<PlayerDetailsRoundHistoryViewItem> Players { get; set; } 
    }



    public class PlayerDetailsRoundHistoryViewItem
    {
        public string Name { get; set; }
        public virtual List<PlayerPropertiesDetailsRoundHistoryViewItem> Properties { get; set; }

        public PlayerDetailsRoundHistoryViewItem()
        {
            Properties = new List<PlayerPropertiesDetailsRoundHistoryViewItem>();
        }
    }

    public class PlayerPropertiesDetailsRoundHistoryViewItem
    {
        public virtual List<CardDetailsRoundHistoryViewItem> Hand { get; set; }
        public int Score { get; set; }
        public int PlayerId { get; set; }
        public PlayerDetailsRoundHistoryViewItem player { get; set; }

        public int Round_Id { get; set; }

        public PlayerPropertiesDetailsRoundHistoryViewItem()
        {
            Hand = new List<CardDetailsRoundHistoryViewItem>();
        }
    }

    public class CardDetailsRoundHistoryViewItem
    {
        public string Name { get; set; }
        public string Suit { get; set; }
        public int Value { get; set; }

        public string ImgPath { get; set; }
    }
}
