using BlackJack.Entities;
using BlackJack.Entities.Enums;
using System.Collections.Generic;
using System.Data.Entity;

namespace BlackJack.DataAccess.Context
{
    public class BlackJackContext : DbContext
    {
        public DbSet<Player> Player { get; set; }
        public DbSet<PlayerRoundHand> PlayerRoundHand { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Round> Round { get; set; }
        public DbSet<Card> Card { get; set; }

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
            db.Player.Add(new Player { Name = "Bot1", Role = Role.Bot });
            db.Player.Add(new Player { Name = "Bot2", Role = Role.Bot });
            db.Player.Add(new Player { Name = "Bot3", Role = Role.Bot });
            db.Player.Add(new Player { Name = "Bot4", Role = Role.Bot });
            db.Player.Add(new Player { Name = "Bot5", Role = Role.Bot });
            db.Player.Add(new Player { Name = "Dealer", Role = Role.Dealer });


            List<Card> Cards = new List<Card>
            {
                new Card("2","Diamonds",2,"#"),
                new Card("3","Diamonds",3,"#"),
                new Card("4","Diamonds",4,"#"),
                new Card("5","Diamonds",5,"#"),
                new Card("6","Diamonds",6,"#"),
                new Card("7","Diamonds",7,"#"),
                new Card("8","Diamonds",8,"#"),
                new Card("9","Diamonds",9,"#"),
                new Card("10","Diamonds",10,"#"),
                new Card("Jack","Diamonds",10,"#"),
                new Card("Lady","Diamonds",10,"#"),
                new Card("King","Diamonds",10,"#"),
                new Card("Ace","Diamonds",11,"#"),

                new Card("2","Hearts",2,"#"),
                new Card("3","Hearts",3,"#"),
                new Card("4","Hearts",4,"#"),
                new Card("5","Hearts",5,"#"),
                new Card("6","Hearts",6,"#"),
                new Card("7","Hearts",7,"#"),
                new Card("8","Hearts",8,"#"),
                new Card("9","Hearts",9,"#"),
                new Card("10","Hearts",10,"#"),
                new Card("Jack","Hearts",10,"#"),
                new Card("Lady","Hearts",10,"#"),
                new Card("King","Hearts",10,"#"),
                new Card("Ace","Hearts",11,"#"),

                new Card("2","Spades",2,"#"),
                new Card("3","Spades",3,"#"),
                new Card("4","Spades",4,"#"),
                new Card("5","Spades",5,"#"),
                new Card("6","Spades",6,"#"),
                new Card("7","Spades",7,"#"),
                new Card("8","Spades",8,"#"),
                new Card("9","Spades",9,"#"),
                new Card("10","Spades",10,"#"),
                new Card("Jack","Spades",10,"#"),
                new Card("Lady","Spades",10,"#"),
                new Card("King","Spades",10,"#"),
                new Card("Ace","Spades",11,"#"),

                new Card("2","Clubs",2,"#"),
                new Card("3","Clubs",3,"#"),
                new Card("4","Clubs",4,"#"),
                new Card("5","Clubs",5,"#"),
                new Card("6","Clubs",6,"#"),
                new Card("7","Clubs",7,"#"),
                new Card("8","Clubs",8,"#"),
                new Card("9","Clubs",9,"#"),
                new Card("10","Clubs",10,"#"),
                new Card("Jack","Clubs",10,"#"),
                new Card("Lady","Clubs",10,"#"),
                new Card("King","Clubs",10,"#"),
                new Card("Ace","Clubs",11,"#")
            };
            db.Card.AddRange(Cards);
            db.SaveChanges();
        }
    }
}
