using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels
{
    public class GameOptionsViewModel
    {
        private string _playerName;
        public string PlayerName
        {
            get
            {
                return _playerName;
            }
            set
            {
                if (value != null)
                {
                    _playerName = value;
                }
            }
        }
        public int AmountBots { get; set; }
    }
}
