namespace BlackJack.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPlayerRoundHandsCard : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlayerRoundHandCards",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PlayerRoundHandId = c.Long(nullable: false),
                        CardId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.PlayerRoundHandCards");
        }
    }
}
