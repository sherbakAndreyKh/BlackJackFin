using System.ComponentModel.DataAnnotations;

namespace BlackJack.ViewModels.ResponseModel
{
    public class ResponseGameStartOptionsGameView
    {
        [Required(ErrorMessage = "Write your Name please")]
        public string PlayerName { get; set; }
        public int BotsAmount { get; set; }
    }
}
