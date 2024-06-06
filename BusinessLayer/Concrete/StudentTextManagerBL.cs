using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class StudentTextManagerBL : IStudentTextServiceBL
    {
        IStudentTextDAL _studentTextDal;
        public StudentTextManagerBL(IStudentTextDAL studentTextDal)
        {
            _studentTextDal = studentTextDal;
        }
        public StudentText GetByID(int id)
        {
            return _studentTextDal.Get(x => x.StudentID == id);
        }

        public List<StudentText> GetList()
        {
            return _studentTextDal.List();
        }

        public List<StudentText> GetListByStudent(int id)
        {
            return _studentTextDal.List(x => x.StudentID == id);
        }

        public void StudentTextAdd(StudentText studentText)
        {
            _studentTextDal.Insert(studentText);
        }
    }
}
