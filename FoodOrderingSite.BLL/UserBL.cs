using Entities;
using FoodOrderingSite.BLL.Interfaces;
using FoodOrderingSite.DAL.Interfaces;
using System.Collections.Generic;

namespace FoodOrderingSite.BLL
{
    public class UserBL : IUserBL
    {
        private readonly IUserDAO UserDAO;

        public UserBL(IUserDAO clientDAO)
        {
            this.UserDAO = clientDAO;
        }

        public int Add(User client)
        {
            return UserDAO.Add(client);
        }

        public bool AddProductToBasketById(int userId, int productId)
        {
            return UserDAO.AddProductToBasketById(userId, productId);
        }

        public bool DeleteById(int id)
        {
            return UserDAO.DeleteById(id);
        }

        public bool DeleteProductFromBasketById(int userId, int productId)
        {
            return UserDAO.DeleteProductFromBasketById(userId, productId);
        }

        public IEnumerable<User> GetAll()
        {
            return UserDAO.GetAll();
        }

        public IEnumerable<Product> GetBasketById(int id)
        {
            return UserDAO.GetBasketById(id);
        }

        public User GetById(int id)
        {
            return UserDAO.GetById(id);
        }

        public User GetByLogin(string login)
        {
            return UserDAO.GetByLogin(login);
        }

        public IEnumerable<string> GetRolesForUser(string login)
        {
            return UserDAO.GetRolesForUser(login);
        }

        public bool Registration(int id, User user)
        {
            return UserDAO.Registration(id, user);
        }

        public bool UpdateById(int id, User user)
        {
            return UserDAO.UpdateById(id, user);
        }
    }
}
