using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete; // Student sınıfının bulunduğu namespace'i ekleyin
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
     public class StudentLoginManagerBL : IStudentLoginServiceBL
    {
        IStudentDAL _studentDal;

        public StudentLoginManagerBL(IStudentDAL studentDal)
        {
            _studentDal = studentDal;
        }

        public Student GetStudent(string username, string password)
        {
            return _studentDal.Get(x=>x.StudentUserName == username && x.StudentPassword == password);
        }
    }
}
