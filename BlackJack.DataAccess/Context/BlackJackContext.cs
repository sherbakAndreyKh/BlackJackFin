using BlackJack.Entities;
using BlackJack.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BlackJack.DataAccess.Context
{
    public class BlackJackContext : DbContext
    {
        public DbSet<Player> Player { get; set; }
        public DbSet<PlayerRoundHand> PlayerRoundHand { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Round> Round { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<Log> Log { get; set; }

        public BlackJackContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<BlackJackContext>(new BlackJackInitializer());
        }

        public BlackJackContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer<BlackJackContext>(new BlackJackInitializer());
        }
    }

    public class BlackJackInitializer : DropCreateDatabaseIfModelChanges<BlackJackContext>
    {
        protected override void Seed(BlackJackContext db)
        {
            db.Player.Add(new Player { Name = "Bot1", Role = PlayerRole.Bot });
            db.Player.Add(new Player { Name = "Bot2", Role = PlayerRole.Bot });
            db.Player.Add(new Player { Name = "Bot3", Role = PlayerRole.Bot });
            db.Player.Add(new Player { Name = "Bot4", Role = PlayerRole.Bot });
            db.Player.Add(new Player { Name = "Bot5", Role = PlayerRole.Bot });
            db.Player.Add(new Player { Name = "Dealer", Role = PlayerRole.Dealer });

			//TODO: generate cards runtime +
        }

     
    }




  
}
