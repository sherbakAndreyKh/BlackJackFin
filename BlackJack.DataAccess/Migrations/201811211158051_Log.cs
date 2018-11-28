namespace BlackJack.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Log : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Log", "StackTrace", c => c.String());
            AlterColumn("dbo.Card", "Suit", c => c.Int(nullable: false));
            CreateIndex("dbo.PlayerRoundHand", "PlayerId");
            AddForeignKey("dbo.PlayerRoundHand", "PlayerId", "dbo.Player", "Id", cascadeDelete: true);
            DropColumn("dbo.Log", "Message");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Log", "Message", c => c.String());
            DropForeignKey("dbo.PlayerRoundHand", "PlayerId", "dbo.Player");
            DropIndex("dbo.PlayerRoundHand", new[] { "PlayerId" });
            AlterColumn("dbo.Card", "Suit", c => c.String());
            DropColumn("dbo.Log", "StackTrace");
        }
    }
}
