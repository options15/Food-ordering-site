using System;
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
        private static readonly IBasketBL basketBL;
        private static readonly IClientBL clientBL;
        private static readonly IOrderBL orderBL;
        private static readonly IProductBL productBL;
        private static readonly IRoleBL roleBL;

        private static readonly IBasketDAO basketDAO;
        private static readonly IClientDAO clientDAO;
        private static readonly IOrderDAO orderDAO;
        private static readonly IProductDAO productDAO;
        private static readonly IRoleDAO roleDAO;

        public static IBasketBL BasketBL => basketBL;
        public static  IClientBL ClientBL => clientBL;
        public static  IOrderBL OrderBL => orderBL;
        public static  IProductBL ProductBL => productBL;
        public static  IRoleBL RoleBL => roleBL;

        static DependencyResolver()
        {
            basketDAO = new BasketDAO();
            clientDAO = new ClientDAO();
            orderDAO = new OrderDAO();
            productDAO = new ProductDAO();
            roleDAO = new RoleDAO();

            basketBL = new BasketBL(basketDAO);
            clientBL = new ClientBL(clientDAO);
            orderBL = new OrderBL(orderDAO);
            productBL = new ProductBL(productDAO);
            roleBL = new RoleBL(roleDAO);
        }
    }
}
