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

        public static UserContext GetInstance => userContext;

        public User Authorization(string login, string password)
        {
            var user = userBL.GetByLogin(login);
            if(user.Password == password)
            {
                return user;
            }
            return null;
        }

        public string AddNotAuthUser()
        {
            return userBL.Add(new User()).ToString();
        }

        public User GetUserById(int id)
        {
            return userBL.GetById(id);
        }

        public bool Registration(int id, User user)
        {
            return userBL.Registration(id, user);
        }

        public IEnumerable<Order> GetUserOrdersById(int userId)
        {
            return new List<Order>();
        }

        public IEnumerable<Product> Basket(int id)
        {
            return userBL.GetBasketById(id);
        }
        public bool AddProductToBasketById(int userId, int productId)
        {
            return userBL.AddProductToBasketById(userId, productId);
        }

        public bool DeleteProductFromBasket(int userId, int productId)
        {
            return userBL.DeleteProductFromBasketById(userId, productId);
        }

        
    }
}