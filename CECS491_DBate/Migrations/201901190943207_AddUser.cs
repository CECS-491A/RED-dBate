namespace CECS491_DBate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        Question1 = c.String(nullable: false),
                        Answer1 = c.String(nullable: false),
                        Question2 = c.String(nullable: false),
                        Answer2 = c.String(nullable: false),
                        Question3 = c.String(nullable: false),
                        Answer3 = c.String(nullable: false),
                        IsAccountActivated = c.Boolean(nullable: false),
                        ClaimID = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
