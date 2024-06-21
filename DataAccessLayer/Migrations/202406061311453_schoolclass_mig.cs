namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class schoolclass_mig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentTexts", "ClassID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentTexts", "ClassID");
        }
    }
}
