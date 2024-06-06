using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IStudentTextServiceBL
    {
        List<StudentText> GetList();
        List<StudentText> GetListByStudent(int id);
        void StudentTextAdd(StudentText studentText);
        StudentText GetByID(int id);
    }
}
