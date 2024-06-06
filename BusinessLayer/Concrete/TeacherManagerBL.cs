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
    //WriterManagerBL
    public class TeacherManagerBL : ITeacherServiceBL
    {
        ITeacherDAL _teacherDal; // DAL Katmanı

        public TeacherManagerBL(ITeacherDAL teacherDal)
        {
            _teacherDal = teacherDal;
        }

        public Teacher GetByID(int id)
        {
            return _teacherDal.Get(x => x.TeacherID == id);
        }

        public List<Teacher> GetList()
        {
            return _teacherDal.List();
        }

        public void TeacherAdd(Teacher teacher)
        {
            _teacherDal.Insert(teacher);
        }

        public void TeacherDelete(Teacher teacher)
        {
            _teacherDal.Delete(teacher);
        }

        public void TeacherUpdate(Teacher teacher)
        {
            _teacherDal.Update(teacher);
        }
       
    }
}
