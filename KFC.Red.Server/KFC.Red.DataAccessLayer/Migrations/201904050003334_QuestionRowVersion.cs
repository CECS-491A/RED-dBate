namespace KFC.red.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionRowVersion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "RowVersion");
        }
    }
}
