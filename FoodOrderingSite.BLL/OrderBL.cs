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
    public class OrderBL : IOrderBL
    {
        private readonly IOrderDAO orderDAO;

        public OrderBL(IOrderDAO orderDAO)
        {
            this.orderDAO = orderDAO;
        }

        public int Add(Order order)
        {
            return orderDAO.Add(order);
        }

        public bool DeleteById(int id)
        {
            return orderDAO.DeleteById(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return orderDAO.GetAll();
        }

        public IEnumerable<Order> GetByCategory()
        {
            return orderDAO.GetByCategory();
        }

        public bool UpdateById(int id)
        {
            return orderDAO.UpdateById(id);
        }

        public IEnumerable<Order> GetAllByUserId(int userId)
        {
            return orderDAO.GetAllByUserId(userId);
        }
    }
}
