﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    //IWriterDAL
    public interface ITeacherDAL : IRepositoryDAL<Teacher>
    {
        List<Teacher> GetList();
    }
}
