namespace KFC.RED.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Connection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Connections",
                c => new
                    {
                        ConnectionID = c.String(nullable: false, maxLength: 128),
                        UserAgent = c.String(),
                        Connected = c.Boolean(nullable: false),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ConnectionID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.User_ID);
            
            DropColumn("dbo.Users", "IsUserPlaying");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "IsUserPlaying", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Connections", "User_ID", "dbo.Users");
            DropIndex("dbo.Connections", new[] { "User_ID" });
            DropTable("dbo.Connections");
        }
    }
}
