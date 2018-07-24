using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BlackJack.Entities;
using BlackJack.Entities.Participant;
using BlackJack.Entities.History;



namespace BlackJack.DAL.Interfaces
{
    public interface IBJContext
    {
        // Participant
        DbSet<Player> Players{ get; set; }
        DbSet<Dealer> Dealers { get; set; }
        DbSet<Bot> Bots { get; set; }

        // History
        DbSet<Game> Games { get; set; }
        DbSet<Round> Rounds { get; set; }

        // Card
        DbSet<Card> CardDeck { get; set; }
    }
}
