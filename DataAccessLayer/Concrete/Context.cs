using EntityLayer.Concrete;
using System.Data.Entity;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
     
        public DbSet<About> Abouts { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentText> StudentTexts { get; set; }

    }
}
