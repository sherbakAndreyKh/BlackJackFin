namespace BlackJack.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
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
                "dbo.PlayerRoundHand",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        PlayerId = c.Long(nullable: false),
                        RoundId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Player", t => t.PlayerId, cascadeDelete: true)
                .ForeignKey("dbo.Round", t => t.RoundId)
                .Index(t => t.PlayerId)
                .Index(t => t.RoundId);
            
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
                "dbo.Round",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Winner = c.String(),
                        WinnerScore = c.Int(nullable: false),
                        NumberRound = c.Long(nullable: false),
                        GameId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AmountPlayers = c.Int(nullable: false),
                        NumberGame = c.Long(nullable: false),
                        PlayerId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlayerRoundHandCards",
                c => new
                    {
                        PlayerRoundHand_Id = c.Long(nullable: false),
                        Card_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.PlayerRoundHand_Id, t.Card_Id })
                .ForeignKey("dbo.PlayerRoundHand", t => t.PlayerRoundHand_Id, cascadeDelete: true)
                .ForeignKey("dbo.Card", t => t.Card_Id, cascadeDelete: true)
                .Index(t => t.PlayerRoundHand_Id)
                .Index(t => t.Card_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayerRoundHand", "RoundId", "dbo.Round");
            DropForeignKey("dbo.PlayerRoundHand", "PlayerId", "dbo.Player");
            DropForeignKey("dbo.PlayerRoundHandCards", "Card_Id", "dbo.Card");
            DropForeignKey("dbo.PlayerRoundHandCards", "PlayerRoundHand_Id", "dbo.PlayerRoundHand");
            DropIndex("dbo.PlayerRoundHandCards", new[] { "Card_Id" });
            DropIndex("dbo.PlayerRoundHandCards", new[] { "PlayerRoundHand_Id" });
            DropIndex("dbo.PlayerRoundHand", new[] { "RoundId" });
            DropIndex("dbo.PlayerRoundHand", new[] { "PlayerId" });
            DropTable("dbo.PlayerRoundHandCards");
            DropTable("dbo.Game");
            DropTable("dbo.Round");
            DropTable("dbo.Player");
            DropTable("dbo.PlayerRoundHand");
            DropTable("dbo.Card");
        }
    }
}
