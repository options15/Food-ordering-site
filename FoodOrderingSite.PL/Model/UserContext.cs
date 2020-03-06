using FoodOrderingSite.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Configuration;
using Entities;

namespace FoodOrderingSite.PL.Model
{
    public class UserContext
    {
        private static readonly UserContext userContext;
        private IUserBL userBL = DependencyResolver.UserBL;

        static UserContext()
        {
            userContext = new UserContext();
        }

        public UserContext GetInstance => userContext;

        public bool Authorization(string login, string password)
        {
            return userBL.GetByLogin(login).Password == password;
        }

        public bool AddNewUser(User user)
        {
            return userBL.Add(user);
        }
    }
}