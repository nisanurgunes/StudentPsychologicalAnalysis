using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    //Teacher
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }

        [StringLength(50)]
        public string TeacherName { get; set; }

        [StringLength(50)]
        public string TeacherSurname { get; set; }

        [StringLength(500)]
        public string TeacherImage { get; set; }

        [StringLength(100)]
        public string TeacherAbout { get; set; }

        [StringLength(200)]
        public string TeacherMail { get; set; }

        [StringLength(200)]
        public string TeacherPassword { get; set; }

        [StringLength(50)]
        public string TeacherClass { get; set; }

        public bool TeacherStatus { get; set; }

        // ilişkiler heading için

        public ICollection<Heading> Headings { get; set; } //1--

        // ilişkiler content için
        public ICollection<Content> Contents { get; set; } //1--
    }
}
