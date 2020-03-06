using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingSite.BLL.Interfaces
{
    public interface IRoleBL
    {
        bool Add(Role role);
        bool DeleteById(int id);
        bool UpdateById(int id);
        Role GetById(int id);
        IEnumerable<Role> GetAll();
    }
}
