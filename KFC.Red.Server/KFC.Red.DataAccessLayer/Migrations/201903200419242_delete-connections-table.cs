namespace KFC.RED.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteconnectionstable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Connections", "User_ID", "dbo.Users");
            DropIndex("dbo.Connections", new[] { "User_ID" });
            DropTable("dbo.Connections");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.ConnectionID);
            
            CreateIndex("dbo.Connections", "User_ID");
            AddForeignKey("dbo.Connections", "User_ID", "dbo.Users", "ID");
        }
    }
}
