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
    public class BasketBL : IBasketBL
    {
        private readonly IBasketDAO basketDAO;
        public BasketBL(IBasketDAO basketDAO)
        {
            this.basketDAO = basketDAO;
        }
        public bool Add(Basket basket)
        {
            return basketDAO.Add(basket);
        }

        public bool DeleteById(int id)
        {
            return basketDAO.DeleteById(id);
        }

        public bool UpdateById(int id)
        {
            return basketDAO.UpdateById(id);
        }
    }
}
