namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentClassAdd_mig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "StudentClass", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "StudentClass");
        }
    }
}
