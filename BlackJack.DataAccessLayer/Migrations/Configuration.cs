using BlackJack.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DataAccessLayer.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BlackJackContext>
    {
        public Configuration() : base()
        {
            AutomaticMigrationDataLossAllowed = false;
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BlackJackContext context)
        {
            
        }
    }
}
