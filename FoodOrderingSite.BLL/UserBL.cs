using Entities;
using FoodOrderingSite.BLL.Interfaces;
using FoodOrderingSite.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingSite.BLL
{
    public class UserBL : IUserBL
    {
        private readonly IUserDAO UserDAO;

        public UserBL(IUserDAO clientDAO)
        {
            this.UserDAO = clientDAO;
        }

        public bool Add(User client)
        {
            return UserDAO.Add(client);
        }

        public bool DeleteById(int id)
        {
            return UserDAO.DeleteById(id);
        }

        public IEnumerable<User> GetAll()
        {
            return UserDAO.GetAll();
        }

        public User GetByLogin(string login)
        {
            return UserDAO.GetByLogin(login);
        }

        public IEnumerable<string> GetRolesForUser(string login)
        {
            return UserDAO.GetRolesForUser(login);
        }

        public bool UpdateById(int id)
        {
            return UserDAO.UpdateById(id);
        }
    }
}
