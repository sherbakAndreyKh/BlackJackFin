using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels
{
    public class GameOptionsViewModel
    {
        [Required(ErrorMessage ="Не указано имя пользователя")]
        public string PlayerName { get; set; }
      
        [Required(ErrorMessage ="Выберите количество ботов")]
        public int AmountBots { get; set; }
    }
}
