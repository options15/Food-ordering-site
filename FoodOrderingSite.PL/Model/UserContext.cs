using Configuration;
using Entities;
using FoodOrderingSite.BLL.Interfaces;
using System;
using System.Collections.Generic;

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
            if (user.Password == password)
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
            try
            {
                return userBL.GetById(id);
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.StackTrace);
                return null;
            }
        }

        public bool Registration(int id, User user)
        {
            try
            {
                return userBL.Registration(id, user);
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.StackTrace);
                return false;
            }
        }

        public IEnumerable<Order> GetUserOrdersById(int userId)
        {
            try
            {
                return new List<Order>();
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.StackTrace);
                return null;
            }
        }

        public IEnumerable<Product> Basket(int id)
        {
            try
            {
                return userBL.GetBasketById(id);
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.StackTrace);
                return null;
            }
        }
        public bool AddProductToBasketById(int userId, int productId)
        {
            try
            {
                return userBL.AddProductToBasketById(userId, productId);
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.StackTrace);
                return false;
            }
        }

        public bool DeleteProductFromBasket(int userId, int productId)
        {
            try
            {
                return userBL.DeleteProductFromBasketById(userId, productId);
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.StackTrace);
                return false;
            }
        }


    }
}