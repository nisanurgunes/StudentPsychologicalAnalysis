namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassificationResultToStudentText : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentTexts", "ClassificationResult", c => c.String(maxLength: 50));
        }

        public override void Down()
        {
            DropColumn("dbo.StudentTexts", "ClassificationResult");
        }
 
    }
}
