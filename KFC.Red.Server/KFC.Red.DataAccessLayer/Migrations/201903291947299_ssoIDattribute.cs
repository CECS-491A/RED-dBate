namespace KFC.RED.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ssoIDattribute : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        QuestionString = c.String(),
                    })
                .PrimaryKey(t => t.QuestionID);
            
            AddColumn("dbo.Users", "SsoId", c => c.Guid(nullable: false));
            AddColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Users", "PasswordHash", c => c.String());
            AddColumn("dbo.Users", "PasswordSalt", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String());
            DropColumn("dbo.Users", "Name");
            DropColumn("dbo.Users", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Name", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false));
            DropColumn("dbo.Users", "PasswordSalt");
            DropColumn("dbo.Users", "PasswordHash");
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Users", "SsoId");
            DropTable("dbo.Questions");
        }
    }
}
