using System.Data.Entity;
using BlackJack.Entities;
using BlackJack.Entities.History;
using BlackJack.Entities.Participant;

namespace BlackJack.DataAccessLayer.Interfaces
{
    public interface IBlackJackContext
    {
        DbSet<Bot> Bots { get; set; }
        DbSet<Card> CardDeck { get; set; }
        DbSet<Dealer> Dealers { get; set; }
        DbSet<Game> Games { get; set; }
        DbSet<Player> Players { get; set; }
        DbSet<Round> Rounds { get; set; }
    }
}