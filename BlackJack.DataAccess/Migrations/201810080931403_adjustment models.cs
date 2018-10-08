namespace BlackJack.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adjustmentmodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Card",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Suit = c.String(),
                        Value = c.Int(nullable: false),
                        ImgPath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PlayersAmount = c.Int(nullable: false),
                        GameNumber = c.Long(nullable: false),
                        PlayerId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlayerRoundHand",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        PlayerId = c.Long(nullable: false),
                        RoundId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Round",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Winner = c.String(),
                        WinnerScore = c.Int(nullable: false),
                        RoundNumber = c.Long(nullable: false),
                        GameId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Round");
            DropTable("dbo.PlayerRoundHand");
            DropTable("dbo.Player");
            DropTable("dbo.Game");
            DropTable("dbo.Card");
        }
    }
}
