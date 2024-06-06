using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    //ITeacherServiceBL
    public interface ITeacherServiceBL
    {
        List<Teacher> GetList();
        void TeacherAdd(Teacher teacher);
        void TeacherDelete(Teacher teacher);
        void TeacherUpdate(Teacher teacher);
        Teacher GetByID(int id);
    }
}
