using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class StudentManagerBL
    {
        IStudentDAL _studentDal;

        public StudentManagerBL(IStudentDAL studentDal)
        {
            _studentDal = studentDal;
        }

        public Student GetByID(int id)
        {
            return _studentDal.Get(x => x.StudentID == id);
        }
        public List<Student> GetList()
        {
            return _studentDal.List();
        }
        public void StudentAdd(Student student)
        {
            _studentDal.Insert(student);
        }

        public void StudentDelete(Student student)
        {
            _studentDal.Delete(student);
        }

        public void StudentUpdate(Student student)
        {
            _studentDal.Update(student);
        }
    }
}
