namespace KFC.RED.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isSessionUsed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameSessions", "isSessionUsed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameSessions", "isSessionUsed");
        }
    }
}
