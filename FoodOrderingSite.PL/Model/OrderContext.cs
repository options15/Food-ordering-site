using FoodOrderingSite.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Configuration;
using Entities;

namespace FoodOrderingSite.PL.Model
{
    public class OrderContext
    {
        private static readonly OrderContext orderContext;
        private IOrderBL orderBL = DependencyResolver.OrderBL;

        static OrderContext()
        {
            orderContext = new OrderContext();
        }

        public static OrderContext GetInstance => orderContext;

        public int SentOrder(Order order)
        {
            return orderBL.Add(order);
        }

        public IEnumerable<Order> GetAll()
        {
            return orderBL.GetAll();
        }

        public IEnumerable<Order> GetByStatus(Status status)
        {
            return orderBL.GetByStatus(status);
        }
        public bool ChangeOrderStatusById(int id, Status status)
        {
            return orderBL.ChangeStatusById(id, status);
        }
    }
}