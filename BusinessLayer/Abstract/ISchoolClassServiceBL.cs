using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISchoolClassServiceBL
    {
        List<SchoolClass> GetList();
        void SchoolClassAdd(SchoolClass schoolClass);
        SchoolClass GetByID(int id);
        void SchoolClassDelete(SchoolClass schoolClass);
        void SchoolClassUpdate(SchoolClass schoolClass);
    }
}
