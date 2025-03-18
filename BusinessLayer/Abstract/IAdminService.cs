using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        Admin GetById(int id);

        Admin GetByAdminName(string username);
        Admin GetByAdmin(string username, string password);
        void AdminUpdate(Admin admin);
        void AdminAdd (Admin admin);
    }
}
