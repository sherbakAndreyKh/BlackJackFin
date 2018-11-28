namespace BlackJack.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayerId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Card", "PlayerRoundHandId", c => c.Long(nullable: false));
            DropColumn("dbo.Card", "ImgPath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Card", "ImgPath", c => c.String());
            DropColumn("dbo.Card", "PlayerRoundHandId");
        }
    }
}
