using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Heading
    {
        [Key]
        public int HeadingID { get; set; }
        [StringLength(50)]
        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }

        // ilişki class için

        public bool HeadingStatus { get; set; }
        public int ClassID { get; set; }
        public virtual SchoolClass SchoolClass { get; set; } // sonsuz

        public ICollection<Content> Contents { get; set; } //1--

        // ilişki teacher için
        public int TeacherID { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
