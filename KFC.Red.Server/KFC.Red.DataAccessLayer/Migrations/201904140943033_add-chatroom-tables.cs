namespace KFC.red.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addchatroomtables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Chatrooms", "QuestionID", "dbo.Questions");
            DropForeignKey("dbo.Users", "ChatroomID", "dbo.Chatrooms");
            DropIndex("dbo.Chatrooms", new[] { "QuestionID" });
            DropIndex("dbo.Users", new[] { "ChatroomID" });
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
            
            DropColumn("dbo.Users", "ChatroomID");
            DropTable("dbo.Chatrooms");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Chatrooms",
                c => new
                    {
                        ChatroomID = c.Int(nullable: false, identity: true),
                        QuestionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChatroomID);
            
            AddColumn("dbo.Users", "ChatroomID", c => c.Int(nullable: false));
            DropForeignKey("dbo.UserGameStorages", "UId", "dbo.Users");
            DropForeignKey("dbo.UserGameStorages", "GId", "dbo.GameSessions");
            DropForeignKey("dbo.GameSessions", "QuestionID", "dbo.Questions");
            DropIndex("dbo.UserGameStorages", new[] { "UId" });
            DropIndex("dbo.UserGameStorages", new[] { "GId" });
            DropIndex("dbo.GameSessions", new[] { "QuestionID" });
            DropTable("dbo.UserGameStorages");
            DropTable("dbo.GameSessions");
            CreateIndex("dbo.Users", "ChatroomID");
            CreateIndex("dbo.Chatrooms", "QuestionID");
            AddForeignKey("dbo.Users", "ChatroomID", "dbo.Chatrooms", "ChatroomID", cascadeDelete: true);
            AddForeignKey("dbo.Chatrooms", "QuestionID", "dbo.Questions", "QuestionID", cascadeDelete: true);
        }
    }
}
