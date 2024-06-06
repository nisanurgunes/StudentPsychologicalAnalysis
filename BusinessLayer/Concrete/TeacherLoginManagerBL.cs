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
    public class TeacherLoginManagerBL : ITeacherLoginServiceBL
    {
        ITeacherDAL _teacherDal;

        public TeacherLoginManagerBL(ITeacherDAL teacherDal)
        {
            _teacherDal = teacherDal;
        }

        public Teacher GetTeacher(string username, string password)
        {
            return _teacherDal.Get(x => x.TeacherMail == username && x.TeacherPassword == password);
        }
    }
}
