namespace KFC.RED.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUGS : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserGameStorages", "ConnectionId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserGameStorages", "ConnectionId");
        }
    }
}
