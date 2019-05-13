namespace KFC.RED.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactoring1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Questions", "RowVersion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
    }
}
