using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingSite.DAL.Interfaces
{
    public interface IUserDAO
    {
        bool Add(User client);
        bool DeleteById(int id);
        bool UpdateById(int id);
        IEnumerable<User> GetAll();
        IEnumerable<string> GetRolesForUser(string login);
        User GetByLogin(string login);
    }
}
