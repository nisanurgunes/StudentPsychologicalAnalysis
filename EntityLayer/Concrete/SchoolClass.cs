using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SchoolClass
    {
        [Key]
        public int ClassID { get; set; }
        [StringLength(50)]
        public string ClassList { get; set; }
        [StringLength(200)]
        public string ClassesTeacher { get; set; }
        public bool ClassStatus { get; set; }

        //ilişkiler
        // 1--ICollection (class)
        // sonsuz(cok)---virtual veya property ismi de olabilir (heading)

        public ICollection<Heading> Headings { get; set; }
        public ICollection<StudentText> StudentTexts { get; set; }
    }
}
