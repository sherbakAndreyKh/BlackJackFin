namespace BlackJack.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adjustmentmodels1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PlayerRoundHandCards", "PlayerRoundHand_Id", "dbo.PlayerRoundHand");
            DropForeignKey("dbo.PlayerRoundHandCards", "Card_Id", "dbo.Card");
            DropForeignKey("dbo.PlayerRoundHand", "PlayerId", "dbo.Player");
            DropForeignKey("dbo.PlayerRoundHand", "RoundId", "dbo.Round");
            DropIndex("dbo.PlayerRoundHand", new[] { "PlayerId" });
            DropIndex("dbo.PlayerRoundHand", new[] { "RoundId" });
            DropIndex("dbo.PlayerRoundHandCards", new[] { "PlayerRoundHand_Id" });
            DropIndex("dbo.PlayerRoundHandCards", new[] { "Card_Id" });
            AddColumn("dbo.Round", "RoundNumber", c => c.Long(nullable: false));
            AddColumn("dbo.Game", "PlayersAmount", c => c.Int(nullable: false));
            AddColumn("dbo.Game", "GameNumber", c => c.Long(nullable: false));
            AlterColumn("dbo.PlayerRoundHand", "RoundId", c => c.Long(nullable: false));
            DropColumn("dbo.Round", "NumberRound");
            DropColumn("dbo.Game", "AmountPlayers");
            DropColumn("dbo.Game", "NumberGame");
            DropTable("dbo.PlayerRoundHandCards");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PlayerRoundHandCards",
                c => new
                    {
                        PlayerRoundHand_Id = c.Long(nullable: false),
                        Card_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.PlayerRoundHand_Id, t.Card_Id });
            
            AddColumn("dbo.Game", "NumberGame", c => c.Long(nullable: false));
            AddColumn("dbo.Game", "AmountPlayers", c => c.Int(nullable: false));
            AddColumn("dbo.Round", "NumberRound", c => c.Long(nullable: false));
            AlterColumn("dbo.PlayerRoundHand", "RoundId", c => c.Long());
            DropColumn("dbo.Game", "GameNumber");
            DropColumn("dbo.Game", "PlayersAmount");
            DropColumn("dbo.Round", "RoundNumber");
            CreateIndex("dbo.PlayerRoundHandCards", "Card_Id");
            CreateIndex("dbo.PlayerRoundHandCards", "PlayerRoundHand_Id");
            CreateIndex("dbo.PlayerRoundHand", "RoundId");
            CreateIndex("dbo.PlayerRoundHand", "PlayerId");
            AddForeignKey("dbo.PlayerRoundHand", "RoundId", "dbo.Round", "Id");
            AddForeignKey("dbo.PlayerRoundHand", "PlayerId", "dbo.Player", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PlayerRoundHandCards", "Card_Id", "dbo.Card", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PlayerRoundHandCards", "PlayerRoundHand_Id", "dbo.PlayerRoundHand", "Id", cascadeDelete: true);
        }
    }
}
