using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class StudentText
    {
        [Key]
        public int StudentTextID { get; set; }
        [StringLength(5000)]

        public string StudentTextContent { get; set; }
          
        public DateTime StudentTextDate { get; set; }
        public int ClassID { get; set; }
        [StringLength(50)]
        public virtual SchoolClass SchoolClass{ get; set; } // sonsuz
        public string ClassificationResult { get; set; }
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }

       

    }
}
