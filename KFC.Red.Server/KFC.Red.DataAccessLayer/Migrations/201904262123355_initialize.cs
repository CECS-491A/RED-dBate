namespace KFC.RED.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClaimName = c.String(),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.GameSessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Token = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        DeleteTime = c.DateTime(nullable: false),
                        QuestionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionID, cascadeDelete: true)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        QuestionString = c.String(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.QuestionID);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Token = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        DeleteTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        UId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UId, cascadeDelete: true)
                .Index(t => t.UId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SsoId = c.Guid(nullable: false),
                        Username = c.String(),
                        Email = c.String(nullable: false),
                        PasswordHash = c.String(),
                        PasswordSalt = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        Role = c.String(),
                        IsAccountActivated = c.Boolean(nullable: false),
                        IsUserPlaying = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserGameStorages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GId = c.Int(nullable: false),
                        UId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameSessions", t => t.GId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UId, cascadeDelete: true)
                .Index(t => t.GId)
                .Index(t => t.UId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserGameStorages", "UId", "dbo.Users");
            DropForeignKey("dbo.UserGameStorages", "GId", "dbo.GameSessions");
            DropForeignKey("dbo.Sessions", "UId", "dbo.Users");
            DropForeignKey("dbo.Claims", "User_ID", "dbo.Users");
            DropForeignKey("dbo.GameSessions", "QuestionID", "dbo.Questions");
            DropIndex("dbo.UserGameStorages", new[] { "UId" });
            DropIndex("dbo.UserGameStorages", new[] { "GId" });
            DropIndex("dbo.Sessions", new[] { "UId" });
            DropIndex("dbo.GameSessions", new[] { "QuestionID" });
            DropIndex("dbo.Claims", new[] { "User_ID" });
            DropTable("dbo.UserGameStorages");
            DropTable("dbo.Users");
            DropTable("dbo.Sessions");
            DropTable("dbo.Questions");
            DropTable("dbo.GameSessions");
            DropTable("dbo.Claims");
        }
    }
}
