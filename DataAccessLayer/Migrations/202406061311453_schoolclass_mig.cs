namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class schoolclass_mig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        AboutID = c.Int(nullable: false, identity: true),
                        AboutDetails1 = c.String(maxLength: 1000),
                        AboutDetails2 = c.String(maxLength: 1000),
                        AboutImage1 = c.String(maxLength: 100),
                        AboutImage2 = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.AboutID);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        AdminUserName = c.String(maxLength: 50),
                        AdminPassword = c.String(maxLength: 50),
                        AdminRole = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        UserMail = c.String(maxLength: 50),
                        Subject = c.String(maxLength: 50),
                        ContactDate = c.DateTime(nullable: false),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.ContactID);
            
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        ContentID = c.Int(nullable: false, identity: true),
                        ContentValue = c.String(maxLength: 1000),
                        ContentDate = c.DateTime(nullable: false),
                        ContentStatus = c.Boolean(nullable: false),
                        HeadingID = c.Int(nullable: false),
                        TeacherID = c.Int(),
                    })
                .PrimaryKey(t => t.ContentID)
                .ForeignKey("dbo.Headings", t => t.HeadingID, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherID)
                .Index(t => t.HeadingID)
                .Index(t => t.TeacherID);
            
            CreateTable(
                "dbo.Headings",
                c => new
                    {
                        HeadingID = c.Int(nullable: false, identity: true),
                        HeadingName = c.String(maxLength: 50),
                        HeadingDate = c.DateTime(nullable: false),
                        HeadingStatus = c.Boolean(nullable: false),
                        ClassID = c.Int(nullable: false),
                        TeacherID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HeadingID)
                .ForeignKey("dbo.SchoolClasses", t => t.ClassID, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.ClassID)
                .Index(t => t.TeacherID);
            
            CreateTable(
                "dbo.SchoolClasses",
                c => new
                    {
                        ClassID = c.Int(nullable: false, identity: true),
                        ClassList = c.String(maxLength: 50),
                        ClassesTeacher = c.String(maxLength: 200),
                        ClassStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClassID);
            
            CreateTable(
                "dbo.StudentTexts",
                c => new
                    {
                        StudentTextID = c.Int(nullable: false, identity: true),
                        StudentTextContent = c.String(),
                        StudentTextDate = c.DateTime(nullable: false),
                        ClassID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentTextID)
                .ForeignKey("dbo.SchoolClasses", t => t.ClassID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.ClassID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        StudentUserName = c.String(maxLength: 50),
                        StudentPassword = c.String(maxLength: 50),
                        StudentClass = c.String(maxLength: 10),
                        StudentName = c.String(maxLength: 50),
                        StudentSurname = c.String(maxLength: 50),
                        StudentImage = c.String(maxLength: 500),
                        TeacherID = c.Int(),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Teachers", t => t.TeacherID)
                .Index(t => t.TeacherID);
            
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
            
            CreateTable(
                "dbo.ImageFiles",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 100),
                        ImagePath = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ImageID);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        SenderMail = c.String(maxLength: 50),
                        ReceiverMail = c.String(maxLength: 50),
                        Subject = c.String(maxLength: 100),
                        MessageContent = c.String(),
                        MessageDate = c.DateTime(nullable: false),
                        MessageStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MessageID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.Headings", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.Contents", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.StudentTexts", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentTexts", "ClassID", "dbo.SchoolClasses");
            DropForeignKey("dbo.Headings", "ClassID", "dbo.SchoolClasses");
            DropForeignKey("dbo.Contents", "HeadingID", "dbo.Headings");
            DropIndex("dbo.Students", new[] { "TeacherID" });
            DropIndex("dbo.StudentTexts", new[] { "StudentID" });
            DropIndex("dbo.StudentTexts", new[] { "ClassID" });
            DropIndex("dbo.Headings", new[] { "TeacherID" });
            DropIndex("dbo.Headings", new[] { "ClassID" });
            DropIndex("dbo.Contents", new[] { "TeacherID" });
            DropIndex("dbo.Contents", new[] { "HeadingID" });
            DropTable("dbo.Messages");
            DropTable("dbo.ImageFiles");
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.StudentTexts");
            DropTable("dbo.SchoolClasses");
            DropTable("dbo.Headings");
            DropTable("dbo.Contents");
            DropTable("dbo.Contacts");
            DropTable("dbo.Admins");
            DropTable("dbo.Abouts");
        }
    }
}
