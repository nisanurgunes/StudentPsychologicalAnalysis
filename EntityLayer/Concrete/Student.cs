using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [StringLength(50)]
        public string StudentUserName { get; set; }
        [StringLength(50)]
        public string StudentPassword { get; set; }
        [StringLength(10)]
        public string StudentClass { get; set; }
        [StringLength(50)]
        public string StudentName { get; set; }
        [StringLength(50)]
        
        public string StudentSurname { get; set; }
        [StringLength(500)]
        public string StudentImage { get; set; }
        public virtual ICollection<StudentText> StudentTexts { get; set; }
        public int? TeacherID { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
