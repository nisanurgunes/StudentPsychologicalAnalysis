using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IStudentServiceBL
    {
        List<Student> GetList();
        void StudentAdd(Student student);
        void StudentDelete(Student student);
        void StudentUpdate(Student student);
        Student GetByID(int id);
    }
}
