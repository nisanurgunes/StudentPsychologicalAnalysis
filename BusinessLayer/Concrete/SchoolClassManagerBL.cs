using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SchoolClassManagerBL : ISchoolClassServiceBL
    {
        ISchoolClassDAL _schoolClassDal;

        public SchoolClassManagerBL(ISchoolClassDAL schoolClassDal)
        {
            _schoolClassDal = schoolClassDal;
        }

        public void SchoolClassAdd(SchoolClass schoolClass)
        {
            _schoolClassDal.Insert(schoolClass);
        }

        public void SchoolClassDelete(SchoolClass schoolClass)
        {
            _schoolClassDal.Delete(schoolClass);
        }

        public void SchoolClassUpdate(SchoolClass schoolClass)
        {
            _schoolClassDal.Update(schoolClass);
        }

        public SchoolClass GetByID(int id)
        {
            return _schoolClassDal.Get(x => x.ClassID == id);
        }

        public List<SchoolClass> GetList()
        {
            return _schoolClassDal.List();
        }


    }
}
