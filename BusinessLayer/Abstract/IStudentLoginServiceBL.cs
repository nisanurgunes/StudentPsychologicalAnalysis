using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{

    //IStudenLogintServiceBL
    public interface IStudentLoginServiceBL
    {
        Student GetStudent(string username, string password);
    }
}
