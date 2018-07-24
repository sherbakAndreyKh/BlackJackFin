using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BlackJack.Entities;
using BlackJack.Entities.Participant;
using BlackJack.Entities.History;

using BlackJack.DAL.Interfaces;

namespace BlackJack.DAL.Context
{
    public class BJContext : DbContext, IBJContext
    {
        // Participant
        public DbSet<Player> Players { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Bot> Bots { get; set; }

        // History
        public DbSet<Game> Games { get; set; }
        public DbSet<Round> Rounds { get; set; }

        // Card
        public DbSet<Card> CardDeck { get; set; }

        public BJContext()
        {
        }

        static BJContext()
        {
            Database.SetInitializer<BJContext>(new BJInitializer());
        }

        public BJContext(string connectionString)
            : base(connectionString)
        { }
    }

    public class BJInitializer : DropCreateDatabaseIfModelChanges<BJContext>
    {
        protected override void Seed(BJContext db)
        {
            db.Bots.Add(new Bot { Name = "Bot1" });
            db.Bots.Add(new Bot { Name = "Bot2" });
            db.Bots.Add(new Bot { Name = "Bot3" });
            db.Bots.Add(new Bot { Name = "Bot4" });
            db.Bots.Add(new Bot { Name = "Bot5" });

            db.Dealers.Add(new Dealer { Name = "Dealer" });


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

            Cards.ForEach(a => db.CardDeck.Add(a));
            db.SaveChanges();
        }
    }
}
