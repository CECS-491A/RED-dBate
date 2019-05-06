namespace KFC.RED.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteBirthdayUser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "DateOfBirth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
