﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using FoodOrderingSite.BLL.Interfaces;
using FoodOrderingSite.BLL;
using FoodOrderingSite.DAL.Interfaces;
using FoodOrderingSite.DAL;

namespace Configuration
{
    public class DependencyResolver
    {
        private static readonly IUserBL userBL;
        private static readonly IOrderBL orderBL;
        private static readonly IProductBL productBL;

        private static readonly IUserDAO userDAO;
        private static readonly IOrderDAO orderDAO;
        private static readonly IProductDAO productDAO;

        public static  IUserBL UserBL => userBL;
        public static  IOrderBL OrderBL => orderBL;
        public static  IProductBL ProductBL => productBL;

        static DependencyResolver()
        {
            userDAO = new UserDAO();
            orderDAO = new OrderDAO();
            productDAO = new ProductDAO();

            userBL = new UserBL(userDAO);
            orderBL = new OrderBL(orderDAO);
            productBL = new ProductBL(productDAO);
        }
    }
}
