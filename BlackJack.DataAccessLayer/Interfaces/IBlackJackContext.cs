using System.Data.Entity;
using BlackJack.Entities;

namespace BlackJack.DataAccessLayer.Interfaces
{
    public interface IBlackJackContext
    {
        DbSet<Card> Card { get; set; }
        DbSet<Game> Game { get; set; }
        DbSet<Player> Player { get; set; }
        DbSet<PlayerRoundHand> PlayerRoundHand { get; set; }
        DbSet<Round> Round { get; set; }
    }
}