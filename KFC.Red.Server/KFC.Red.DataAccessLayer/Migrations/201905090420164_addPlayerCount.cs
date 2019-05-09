namespace KFC.RED.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPlayerCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameSessions", "PlayerCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameSessions", "PlayerCount");
        }
    }
}
