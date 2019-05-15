namespace KFC.RED.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class winner : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameSessions", "Winner", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameSessions", "Winner");
        }
    }
}
