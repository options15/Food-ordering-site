using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingSite.DAL.Interfaces
{
    public interface IRoleDAO
    {
        bool Add(Role role);
        bool DeleteById(int id);
        bool UpdateById(int id);
        IEnumerable<Order> GetAll();
    }
}
