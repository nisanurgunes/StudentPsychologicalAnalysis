namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contents", "WriterID", "dbo.Writers");
            DropForeignKey("dbo.Headings", "WriterID", "dbo.Writers");
            DropForeignKey("dbo.Students", "WriterID", "dbo.Writers");
            DropIndex("dbo.Headings", new[] { "WriterID" });
            DropIndex("dbo.Contents", new[] { "WriterID" });
            DropIndex("dbo.Students", new[] { "WriterID" });
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherID = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(maxLength: 50),
                        TeacherSurname = c.String(maxLength: 50),
                        TeacherImage = c.String(maxLength: 500),
                        TeacherAbout = c.String(maxLength: 100),
                        TeacherMail = c.String(maxLength: 200),
                        TeacherPassword = c.String(maxLength: 200),
                        TeacherClass = c.String(maxLength: 50),
                        TeacherStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherID);
            
            AddColumn("dbo.Headings", "TeacherID", c => c.Int(nullable: false));
            AddColumn("dbo.Contents", "TeacherID", c => c.Int());
            AddColumn("dbo.Students", "TeacherID", c => c.Int());
            CreateIndex("dbo.Headings", "TeacherID");
            CreateIndex("dbo.Contents", "TeacherID");
            CreateIndex("dbo.Students", "TeacherID");
            AddForeignKey("dbo.Contents", "TeacherID", "dbo.Teachers", "TeacherID");
            AddForeignKey("dbo.Headings", "TeacherID", "dbo.Teachers", "TeacherID", cascadeDelete: true);
            AddForeignKey("dbo.Students", "TeacherID", "dbo.Teachers", "TeacherID");
            DropColumn("dbo.Headings", "WriterID");
            DropColumn("dbo.Contents", "WriterID");
            DropColumn("dbo.Students", "WriterID");
            DropTable("dbo.Writers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Writers",
                c => new
                    {
                        WriterID = c.Int(nullable: false, identity: true),
                        WriterName = c.String(maxLength: 50),
                        WriterSurname = c.String(maxLength: 50),
                        WriterImage = c.String(maxLength: 500),
                        WriterAbout = c.String(maxLength: 100),
                        WriterMail = c.String(maxLength: 200),
                        WriterPassword = c.String(maxLength: 200),
                        WriterTitle = c.String(maxLength: 50),
                        WriterStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.WriterID);
            
            AddColumn("dbo.Students", "WriterID", c => c.Int());
            AddColumn("dbo.Contents", "WriterID", c => c.Int());
            AddColumn("dbo.Headings", "WriterID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Students", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.Headings", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.Contents", "TeacherID", "dbo.Teachers");
            DropIndex("dbo.Students", new[] { "TeacherID" });
            DropIndex("dbo.Contents", new[] { "TeacherID" });
            DropIndex("dbo.Headings", new[] { "TeacherID" });
            DropColumn("dbo.Students", "TeacherID");
            DropColumn("dbo.Contents", "TeacherID");
            DropColumn("dbo.Headings", "TeacherID");
            DropTable("dbo.Teachers");
            CreateIndex("dbo.Students", "WriterID");
            CreateIndex("dbo.Contents", "WriterID");
            CreateIndex("dbo.Headings", "WriterID");
            AddForeignKey("dbo.Students", "WriterID", "dbo.Writers", "WriterID");
            AddForeignKey("dbo.Headings", "WriterID", "dbo.Writers", "WriterID", cascadeDelete: true);
            AddForeignKey("dbo.Contents", "WriterID", "dbo.Writers", "WriterID");
        }
    }
}
