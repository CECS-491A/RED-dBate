namespace KFC.red.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chatrooms",
                c => new
                    {
                        ChatroomID = c.Int(nullable: false, identity: true),
                        QuestionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChatroomID)
                .ForeignKey("dbo.Questions", t => t.QuestionID, cascadeDelete: true)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        QuestionString = c.String(),
                    })
                .PrimaryKey(t => t.QuestionID);
            
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
                        ChatroomID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Chatrooms", t => t.ChatroomID, cascadeDelete: true)
                .Index(t => t.ChatroomID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sessions", "UId", "dbo.Users");
            DropForeignKey("dbo.Claims", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Users", "ChatroomID", "dbo.Chatrooms");
            DropForeignKey("dbo.Chatrooms", "QuestionID", "dbo.Questions");
            DropIndex("dbo.Users", new[] { "ChatroomID" });
            DropIndex("dbo.Sessions", new[] { "UId" });
            DropIndex("dbo.Claims", new[] { "User_ID" });
            DropIndex("dbo.Chatrooms", new[] { "QuestionID" });
            DropTable("dbo.Users");
            DropTable("dbo.Sessions");
            DropTable("dbo.Claims");
            DropTable("dbo.Questions");
            DropTable("dbo.Chatrooms");
        }
    }
}
