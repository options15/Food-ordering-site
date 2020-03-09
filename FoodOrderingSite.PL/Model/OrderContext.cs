using Configuration;
using Entities;
using FoodOrderingSite.BLL.Interfaces;
using System;
using System.Collections.Generic;

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
            try
            {
                return orderBL.Add(order);
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.StackTrace);
                return 0;
            }

        }

        public IEnumerable<Order> GetAll()
        {

            try
            {
                return orderBL.GetAll();
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.StackTrace);
                return null;
            }
        }

        public IEnumerable<Order> GetByStatus(Status status)
        {

            try
            {
                return orderBL.GetByStatus(status);
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.StackTrace);
                return null;
            }
        }
        public bool ChangeOrderStatusById(int id, Status status)
        {
            try
            {
                return orderBL.ChangeStatusById(id, status);
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.StackTrace);
                return false;
            }
        }
    }
}