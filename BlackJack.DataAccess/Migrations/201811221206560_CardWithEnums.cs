namespace BlackJack.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CardWithEnums : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Card", "Name", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Card", "Name", c => c.String());
        }
    }
}
