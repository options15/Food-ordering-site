using Entities;
using System.Collections.Generic;

namespace FoodOrderingSite.DAL.Interfaces
{
    public interface IOrderDAO
    {
        int Add(Order order);
        IEnumerable<Order> GetAll();
        IEnumerable<Order> GetAllByUserId(int userId);
        IEnumerable<Order> GetByStatus(Status status);
        bool ChangeStatusById(int id, Status status);
    }
}
