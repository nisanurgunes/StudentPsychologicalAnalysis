namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Student_namesurname_add_mig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "StudentName", c => c.String(maxLength: 50));
            AddColumn("dbo.Students", "StudentSurname", c => c.String(maxLength: 50));
            AddColumn("dbo.Students", "StudentImage", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "StudentImage");
            DropColumn("dbo.Students", "StudentSurname");
            DropColumn("dbo.Students", "StudentName");
        }
    }
}
