using System.Data.Entity;
using BlackJack.Entities;
using BlackJack.Entities.History;

namespace BlackJack.DataAccessLayer.Interfaces
{
    public interface IBlackJackContext
    {
        DbSet<Card> CardDeck { get; set; }
        DbSet<Game> Games { get; set; }
        DbSet<Player> Players { get; set; }
        DbSet<PlayerProperties> Properties { get; set; }
        DbSet<Round> Rounds { get; set; }  

    }
}