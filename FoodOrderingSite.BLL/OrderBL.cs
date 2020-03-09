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


        public IEnumerable<Order> GetAll()
        {
            return orderDAO.GetAll();
        }

        public IEnumerable<Order> GetByStatus(Status status)
        {
            return orderDAO.GetByStatus(status);
        }


        public IEnumerable<Order> GetAllByUserId(int userId)
        {
            return orderDAO.GetAllByUserId(userId);
        }

        public bool ChangeStatusById(int id, Status status)
        {
            return orderDAO.ChangeStatusById(id, status);
        }
    }
}
