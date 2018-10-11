using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.ViewModels.ResponseModel
{
    public class ResponseGameStartOptionsGameView
    {
        [Required(ErrorMessage = "Write your Name please")]
        public string PlayerName { get; set; }
        public int BotsAmount { get; set; }
        public List<PlayerGameStartOptionsGameViewItem> Players { get; set; }
        
        public ResponseGameStartOptionsGameView()
        {
            Players = new List<PlayerGameStartOptionsGameViewItem>();
        }
    }

    public class PlayerGameStartOptionsGameViewItem
    {
        public string PlayerName { get; set; }
    }
}
