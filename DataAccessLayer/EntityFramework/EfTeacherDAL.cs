﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    //EfWriterDAL
    public class EfTeacherDAL : GenericRepositoryDAL<Teacher>, ITeacherDAL
    {
        public List<Teacher> GetList()
        {
            return _object.ToList();
        }
    }
}
